using BMITracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMITracker.Services
{
    /// <summary>
    /// BmiData repository Interface
    /// </summary>
    public interface IBmiData
    {
        HealthProfile Create(HealthProfile bmi);

        HealthProfile Read(int id);

        ICollection<HealthProfile> ReadAll();

        void Update(int id, HealthProfile bmi);

        void Delete(int id);
    }
}
