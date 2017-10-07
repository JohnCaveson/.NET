using System;
using System.Collections.Generic;

namespace Lab05Recommendation.Models.Entities
{
    public partial class Recommendation
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Narrative { get; set; }
        public string RecommenderName { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
