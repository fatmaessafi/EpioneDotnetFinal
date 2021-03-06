﻿using Domain.Entities;
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
    public class ServiceUser : Service<User>, IUserService
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbfactory);
        public ServiceUser() : base(uow)
        {
        }

        public IEnumerable<User> GetAllPatients()
        {

            return GetAll().OfType<Patient>();
        
        }
    }
}
