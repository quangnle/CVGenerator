using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Education : IConvertibleModel<TEducation>
    {
        public int Id { get; set; }
        public int IdProfile { get; set; }
        public string University { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public string Degree { get; set; }

        public string Description { get; set; }

        

        public void Update(TEducation entity)
        {
            entity.University = University;
            entity.FromYear = FromYear;
            entity.ToYear = ToYear;
            entity.Degree = Degree;
        }

        public TEducation GetEntity()
        {
            var entity = new TEducation();
            Update(entity);
            return entity;
        }
    }
}