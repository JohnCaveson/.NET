using BMITracker.Models.Entities;
using BMITracker.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMITracker.Models
{
    public class DbFirstBmiData : IBmiData
    {
        private HealthProfileDbContext _db;
        /// <summary>
        /// ctor with dependency injection
        /// </summary>
        /// <param name="db"></param>
        public DbFirstBmiData(HealthProfileDbContext db)
        {
            _db = db;
        }
    /*Crud operations
     * inside of 
     * region
     * */
    #region Crud Operations
        public HealthProfile Create(HealthProfile bmi)
        {
            _db.HealthProfile.Add(bmi);
            _db.SaveChanges();
            return bmi;
        }

        public void Delete(int id)
        {
            HealthProfile healthprofile = _db.HealthProfile.Find(id);
            _db.HealthProfile.Remove(healthprofile);
            _db.SaveChanges();
        }

        public HealthProfile Read(int id)
        {
            if (_db.HealthProfile.ToList().Contains(_db.HealthProfile.Find(id)))
                return _db.HealthProfile.FirstOrDefault(h => h.Id == id);
            else
                return null;
        }

        public ICollection<HealthProfile> ReadAll()
        {
            return _db.HealthProfile.ToList();
        }

        public void Update(int id, HealthProfile bmi)
        {
            _db.Entry(bmi).State = EntityState.Modified;
            _db.SaveChanges();
        }
#endregion
    }
}
