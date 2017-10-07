using Lab05Recommendation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab05Recommendation.Models.Entities;
using Lab05Recommendation.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Lab05Recommendation.Services
{
    public class DbPersonRepository : IPersonRepository
    {
        private RecommendationDbContext _db;
        public DbPersonRepository(RecommendationDbContext db)
        {
            _db = db;
        }
        public Person Create(Person person)
        {
            _db.Person.Add(person);
            _db.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            Person person = _db.Person.Find(id);
            _db.Person.Remove(person);
            _db.SaveChanges();
        }

        public Person Read(int id)
        {
            return _db.Person.Include(p => p.Recommendation).FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Person> ReadAll()
        {
            return _db.Person.Include(p => p.Recommendation).ToList();
        }

        public void Update(int id, Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
