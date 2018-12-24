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
    public class ServiceStep : Service<Step>, IServiceStep
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);

        public ServiceStep() : base(uow)
        {
        }
        public IEnumerable<Step> GetListStepOrdered(int idTreatment)
        {
            return GetMany().OfType<Step>().Where(t => t.TreatmentId.Equals(idTreatment)).OrderBy(t => t.StepDate);
        }


        public int nbTotalTreatment(int id)
        {
            return GetAll().OfType<Step>().Count();
        }
    }
}
