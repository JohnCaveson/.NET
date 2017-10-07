using Lab05Recommendation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05Recommendation.Services.Interfaces
{
    public interface IPersonRepository
    {
        Person Create(Person person);

        Person Read(int id);

        ICollection<Person> ReadAll();

        void Update(int id, Person person);

        void Delete(int id);
    }
}
