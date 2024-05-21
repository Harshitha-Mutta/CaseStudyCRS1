using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.Entities;
namespace CaseStudyCRS1.dao.ICarLeaseRepository
{
    public interface ILease
    {
        public Lease createLease(int cusId, int carId, DateTime sd, DateTime ed,string type);
        public void returnCar(int lid);
        public List<Lease> ListActiveLeases();
        public List<Lease> listLeaseHistory();
        public Lease findLeaseByID(int lid);

    }
}
