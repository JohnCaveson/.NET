using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03Models.Models;

namespace Lab03Models.Services
{
    public class InMemoryRecommendationData : IRecommendationData
    {
        private static ICollection<Recommendation> _recommendations = new List<Recommendation>();

        public Recommendation Create(Recommendation recommendation)
        {
            var lastRecommendation = _recommendations.LastOrDefault();
            if(lastRecommendation != null)
            {
                recommendation.Id = lastRecommendation.Id + 1;
            }
            else
            {
                recommendation.Id = 1;
            }
            _recommendations.Add(recommendation);
            return recommendation;
        }

        public void Delete(int id)
        {
            var recommendation = _recommendations.FirstOrDefault(r => r.Id == id);
            if (recommendation != null)
            {
                _recommendations.Remove(recommendation);
            }
        }

        public Recommendation Read(int id)
        {
            return _recommendations.FirstOrDefault(r => r.Id == id);
        }

        public ICollection<Recommendation> ReadAll()
        {
            return _recommendations;
        }

        public void Update(int id, Recommendation recommendation)
        {
            var oldRecommendation = _recommendations.FirstOrDefault(r => r.Id == id);
            if(oldRecommendation != null)
            {
                oldRecommendation.Rating = recommendation.Rating;
                oldRecommendation.Narrative = recommendation.Narrative;
                oldRecommendation.RecommenderName = recommendation.RecommenderName;
            }
        }
    }
}
