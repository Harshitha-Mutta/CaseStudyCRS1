using CaseStudyCRS1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.dao.ICarLeaseRepository
{
    public interface IPayment
    {
        public void recordPayment(Lease lease, double amount);
        public List<Payment> ListPaymentHistory();
    }
}
