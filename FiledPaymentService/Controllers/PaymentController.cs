using AutoMapper;
using FiledPaymentService.DB;
using FiledPaymentService.Repositories.Interfaces;
using FiledPaymentService.Services.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FiledPaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IInvoker _invoker;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<PaymentController> _logger;
        public PaymentController(IInvoker invoker, IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentController> logger)
        {
            _invoker = invoker;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
                Message= "Api is up, make a Post req to : api/Payment/ProcessPayment",
                SamplePayload = "{\"CreditCardNumber\":\"5105105105105100\",\"CardHolder\":\"Peter Pan\",\"ExpirationDate\":\"2025-04-07T00:00:00.000Z\",\"SecurityCode\":\"fha\",\"Amount\":21.3}"
            });
        }

        [HttpPost]
        [Route("ProcessPayment")]
        public IActionResult ProcessPayment(Models.Payment payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ps = new PaymentStatus();
                    ps.Payment = _mapper.Map<DB.Payment>(payment);
                    ps.Status = DB.Enums.PaymentStatuses.Pending;
                    _unitOfWork.PaymentStatuses.InsertPaymentStatus(ps);

                    ICommand cmd = _invoker.GetCommand((double)payment.Amount);
                    bool isSuccess = cmd.Execute();
                    if (isSuccess)
                    {
                        ps.Status = DB.Enums.PaymentStatuses.Processed;
                        _unitOfWork.Commit();
                        return Ok(new { Message = "Payment succeeded" });
                    }
                    else
                    {
                        ps.Status = DB.Enums.PaymentStatuses.Failed;
                        _unitOfWork.Commit();
                        return Problem("Internal Server Error!");
                    }
                }
                return ValidationProblem("The request is invalid!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in Payment/ProcessPayment : " + ex.Message);
            }
            return Problem();
        }
    }
}
