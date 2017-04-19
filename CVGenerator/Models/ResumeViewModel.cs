using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class ResumeViewModel
    {
        public TTemplate Template { get; set; }
        public TProfile PersonalInformation { get; set; }
        public List<TEducation> Educations { get; set; }
        public List<TReference> References { get; set; }
        public List<TWorkExperience> WorkExps { get; set; }
        public List<TSkill> Skills { get; set; }
    }
}