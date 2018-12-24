using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Service
{
    public class ServiceStepRequest : Service<StepRequest>, IServiceStepRequest
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public ServiceStepRequest() : base(uow)
        {
        }
        public IEnumerable<StepRequest> GetListStepRequestOrdered(int id)
        {   
            return GetMany().OfType<StepRequest>().Where(t=>t.NewTreatmentId.Equals(id)).OrderBy(t => t.NewStepDate);
        }
    }
}
