using AutoMapper;
using FiledPaymentService.DB;
using FiledPaymentService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace FiledPaymentService.Repositories
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        private FiledDbContext _context;
        private readonly IMapper _mapper;

        public PaymentStatusRepository(IMapper mapper, FiledDbContext filedDbContext)
        {
            _mapper = mapper;
            _context = filedDbContext;
        }

        public void DeletePaymentStatus(int paymentId)
        {
            PaymentStatus payment = _context.PaymentStatuses.Find(paymentId);
            _context.PaymentStatuses.Remove(payment);
        }

        public IEnumerable GetPaymentStatus()
        {
            return _context.PaymentStatuses.ToList();
        }

        public PaymentStatus GetPaymentStatusByID(int paymentId)
        {
            return _context.PaymentStatuses.Find(paymentId);
        }

        public void InsertPaymentStatus(PaymentStatus payment)
        {
            _context.PaymentStatuses.Add(payment);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePaymentStatus(PaymentStatus payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
        }
    }
}
