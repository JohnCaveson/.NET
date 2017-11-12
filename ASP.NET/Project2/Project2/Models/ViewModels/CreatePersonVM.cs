using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class CreatePersonVM
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person CreatePerson()
        {
            return new Person { FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, Email = Email };
        }
    }
}
