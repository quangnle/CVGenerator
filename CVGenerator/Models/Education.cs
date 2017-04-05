using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Education
    {
        public string University { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public string Degree { get; set; }

        public string Description { get; set; }     
    }
}