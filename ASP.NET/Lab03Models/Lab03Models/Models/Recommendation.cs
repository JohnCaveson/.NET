using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03Models.Models
{
    public class Recommendation
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public String Narrative { get; set; }

        public String RecommenderName { get; set; }
    }
}
