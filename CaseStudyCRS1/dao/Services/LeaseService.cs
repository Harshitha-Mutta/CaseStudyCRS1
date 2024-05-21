using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.dao.Services
{
    public class LeaseService
    {
        private readonly ILease _LeaseRepo;
        public LeaseService(ILease leaseRepo)
        {
            _LeaseRepo = leaseRepo;
        }
        public Lease createLease(int cusId, int carId, DateTime sd, DateTime ed, string type)
        {
            return _LeaseRepo.createLease(cusId, carId, sd, ed, type);
        }
        public void returnCar(int lid)
        {
            _LeaseRepo.returnCar(lid);
        }
        public List<Lease> ListActiveLeases()
        {
            return _LeaseRepo.ListActiveLeases();
        }
        public List<Lease> listLeaseHistory()
        {
            return _LeaseRepo.listLeaseHistory();
        }
        public Lease findLeaseByID(int lid)
        {
            return _LeaseRepo.findLeaseByID(lid);
        }


    }
}
