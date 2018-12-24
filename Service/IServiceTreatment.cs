using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceTreatment : IService<Treatment>
    {
        IEnumerable<Treatment> GetListTreatmentOrdered(int id);
         int nbTotalTreatment(int id);
        IEnumerable<Treatment> GetListTreatmentOrderedByDoctor(int id);
    }
}
