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
   public class VisitReasonService : Service<VisitReason>, VisitReasonIService
    {

        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public VisitReasonService():base(unit)
        {

        }
        /*public bool test(int id)
        {
            VisitReason r = new VisitReason();
            if (r.DoctorId == id)
            { return true; }
            else
            { return false; }
          //  return GetAll().Where(t => t.DoctorId == id);
        }*/
        public IEnumerable<VisitReason> VRGetId(int id )
        {
            return (IEnumerable<VisitReason>) GetAll().Where(t => t.DoctorId == id);


        }
    }
}
