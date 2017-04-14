using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class WorkExperience : IConvertibleModel<TWorkExperience>
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
            if (_entity.ToMonth == -1 && _entity.ToYear == -1)
            {
                ToTime = "now";
            }
            else
            {
                ToTime = string.Format("{0}/{1}", _entity.ToMonth, _entity.ToYear);
            }
            Position = _entity.Position;
            Description = _entity.Description;
        }

        public void Update(TWorkExperience entity)
        {
            entity.Company = Company;
            entity.Position = Position;

            entity.FromMonth = int.Parse(FromTime.Split('/')[0]);
            entity.FromYear = int.Parse(FromTime.Split('/')[1]);

            if (ToTime.ToLower() == "now")
            {
                entity.ToMonth = -1;
                entity.ToYear = -1;
            }
            else
            {
                entity.ToMonth = int.Parse(ToTime.Split('/')[0]);
                entity.ToYear = int.Parse(ToTime.Split('/')[1]);
            }

            entity.Description = Description;
        }

        public TWorkExperience GetEntity()
        {
            TWorkExperience entity = new TWorkExperience();
            Update(entity);
            return entity;
        }
    }
}