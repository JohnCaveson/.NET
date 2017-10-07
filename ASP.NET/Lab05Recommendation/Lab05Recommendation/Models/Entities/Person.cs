using System;
using System.Collections.Generic;

namespace Lab05Recommendation.Models.Entities
{
    public partial class Person
    {
        public Person()
        {
            Recommendation = new HashSet<Recommendation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Recommendation> Recommendation { get; set; }
    }
}
