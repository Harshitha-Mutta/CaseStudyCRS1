using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.Entities
{
    public class Payment
    {
        public int paymentId { get; set; }
        public int leaseId { get; set; }
        public DateTime paymentDate { get; set; }
        public double amount { get; set; }
        public Payment() { }
        public Payment(int paymentId, int leaseId, DateTime paymentDate, double amount)
        {
            this.paymentId = paymentId;
            this.leaseId = leaseId;
            this.paymentDate = paymentDate;
            this.amount = amount;
        }
    }
}
