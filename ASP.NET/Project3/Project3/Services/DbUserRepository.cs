using Project3.Data;
using Project3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3.Models;

namespace Project3.Services
{
    public class DbUserRepository : IUserRepository
    {
        #region Ctor and Dependency Injection
        ApplicationDbContext _db;

        public DbUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Crud Ops
        public ApplicationUser Create(ApplicationUser au)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> ReadAll()
        {
            return _db.Users.ToList();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
