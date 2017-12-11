using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser Create(ApplicationUser au);
        ApplicationUser Read(int id);
        IEnumerable<ApplicationUser> ReadAll();
        void Update(int id);
        void Delete(int id);
    }
}
