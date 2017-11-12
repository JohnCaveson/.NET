using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> ReadAll();
        Person Create(Person person);
        Person Read(int id);
        void Update(int id, Person person);
        void Delete(int id);
        void AssignProject(int id, ProjectRole pr);
    }
}
