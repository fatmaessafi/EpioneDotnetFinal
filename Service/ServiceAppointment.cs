using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Service
{
    public class ServiceAppointment : Service<Appointment>, IserviceAppointment //il prend la signiature de la methode (pour la structure de travail)
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public ServiceAppointment() : base(uow)
        {

        }


    }
}
