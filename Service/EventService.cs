using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EventService : Service<Event>, EventIservice
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public EventService():base(unit)
        {

        }
        public IEnumerable<Event> eventGetAll(int id)
        {
            
            return (IEnumerable<Event>)GetAll().Where(t=>t.DoctorId==id);
        }
    }
}
