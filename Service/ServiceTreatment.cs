using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class ServiceTreatment :   Service<Treatment>, IServiceTreatment
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);

        public ServiceTreatment() : base(uow)
        {
        }

      

        public IEnumerable<Treatment> GetListTreatmentOrdered(int id)
        {
            return GetMany().OfType<Treatment>().Where(t=>t.PatientId.Equals(id)).OrderBy(t => t.TreatmentId);
        }
        public IEnumerable<Treatment> GetListTreatmentOrderedByDoctor(int id)
        {
            return GetMany().OfType<Treatment>().Where(t => t.DoctorId.Equals(id)).OrderBy(t => t.TreatmentId);
        }

        public int nbTotalTreatment(int id)
        {
            return GetAll().OfType<Treatment>().Where(t=>t.PatientId.Equals(id)).Count();
        }
    }
}
