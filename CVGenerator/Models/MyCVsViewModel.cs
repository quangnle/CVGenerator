using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class MyCvsViewModel
    {
        public string UserEmail { get; set; }        
        public List<TProfile> PersonalInformations { get; set; }
    }
}