using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using CaseStudyCRS1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.dao.Services
{
    public class PaymentService
    {
        private readonly IPayment _PaymentRepo;
        public PaymentService(IPayment pRepo)
        {
            _PaymentRepo = pRepo;
        }
        public void recordPayment(Lease lease, double amount)
        {
            _PaymentRepo.recordPayment(lease, amount);
        }
        public List<Payment> ListPaymentHistory()
        {
            return _PaymentRepo.ListPaymentHistory();
        }

    }
}
