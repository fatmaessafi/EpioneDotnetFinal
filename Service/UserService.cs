using Data;
using Data.Infrastructure;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        IUnitOfWork utwk;
        private Contexte _db;


        public UserService()
        {
            _db = new Contexte();
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(User => User.Id == id);
        }

        public User GetUserByEmail(String Email)
        {
            return _db.Users.FirstOrDefault(User => User.Email == Email);
        }

        public IEnumerable<User> GetAll()
        {
            return utwk.getRepository<User>().GetAll();
        }

        
    }
}
