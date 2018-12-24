using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IServiceStepRequest:IService<StepRequest>
    {
         IEnumerable<StepRequest> GetListStepRequestOrdered(int id);

    }
}
