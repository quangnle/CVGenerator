using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }

        public int YearsOfExp { get; set; }
        public string Nationality { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public List<Education> Educations { get; set; }
    }
}