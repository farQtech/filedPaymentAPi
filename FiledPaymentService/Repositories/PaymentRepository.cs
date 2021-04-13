using AutoMapper;
using FiledPaymentService.DB;
using FiledPaymentService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model = FiledPaymentService.Models;

namespace FiledPaymentService.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private FiledDbContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(IMapper mapper, FiledDbContext filedDbContext)
        {
            _mapper = mapper;
            _context = filedDbContext;
        }

        public void DeletePayment(int paymentId)
        {
            Payment payment = _context.Payments.Find(paymentId);
            _context.Payments.Remove(payment);
        }

        public IEnumerable GetPayment()
        {
            return _mapper.Map<IEnumerable<Model.Payment>>(_context.Payments.ToList());
        }

        public Model.Payment GetPaymentByID(int paymentId)
        {
            return _mapper.Map<Model.Payment>(_context.Payments.Find(paymentId));
        }

        public void InsertPayment(Model.Payment payment)
        {
            _context.Payments.Add(_mapper.Map<Payment>(payment));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePayment(Model.Payment payment)
        {
            _context.Entry(_mapper.Map<Payment>(payment)).State = EntityState.Modified;
        }
    }
}
