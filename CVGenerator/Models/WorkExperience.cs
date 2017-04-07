using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class WorkExperience
    {
        private TWorkExperience _entity;

        public int Id { get; set; }
        public int IdProfile { get; set; }
        public string Company { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

        public void Bind(TWorkExperience entity)
        {
            _entity = entity;
            Id = _entity.Id;
            IdProfile = _entity.IdProfile;
            Company = _entity.Company;
            FromTime = string.Format("{0}/{1}", _entity.FromMonth, _entity.FromYear);
            ToTime = string.Format("{0}/{1}", _entity.ToMonth, _entity.ToYear);
            Position = _entity.Position;
            Description = _entity.Description;
        }
    }
}