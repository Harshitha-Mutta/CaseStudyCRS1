using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.Entities
{
    public class Lease
    {
        public int leaseId { get; set; }
        public int vehicleId { get; set; }
        public int customerId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string type { get; set; }
        public Lease() { }
        public Lease(int vehicleId, int customerId,
            DateTime startDate, DateTime endDate, string type)
        {
            this.leaseId = leaseId;
            this.vehicleId = vehicleId;
            this.customerId = customerId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.type = type;
        }
    }
}
