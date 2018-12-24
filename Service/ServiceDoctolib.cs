using Data.Infrastructure;
using Domain;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   
    public class ServiceDoctolib : Service<Doctor>, IServiceDoctolib
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);

        public ServiceDoctolib() : base(uow)
        {
        }
        public IEnumerable<Doctor> GetListUser()
        {
            return GetAll();
        }


        public int nbTotalTreatment(int id)
        {
            return GetAll().OfType<Doctor>().Count();
        }


    }
}
