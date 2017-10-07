using Lab03Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03Models.Services
{
    public interface IRecommendationData
    {
        Recommendation Create(Recommendation recommendation);

        Recommendation Read(int id);

        ICollection<Recommendation> ReadAll();

        void Update(int id, Recommendation recommendation);

        void Delete(int id);
    }
}
