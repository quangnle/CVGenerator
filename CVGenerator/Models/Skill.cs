using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Skill : IConvertibleModel<TSkill>
    {
        private TSkill _entity;

        public int Id { get; set; }
        public int IdProfile { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public void Bind(TSkill entity)
        {
            _entity = entity;
            Id = entity.Id;
            IdProfile = entity.IdProfile;
            Category = entity.Category;
            Name = entity.Name;
            Score = entity.Score;
        }

        public void Update(TSkill entity)
        {
            entity.Name = Name;
            entity.Score = Score;
            entity.Category = Category;         
        }

        public TSkill GetEntity()
        {
            if (_entity == null)
            {
                _entity = new TSkill();
                _entity.IdProfile = IdProfile;
                _entity.Category = Category;
                _entity.Name = Name;
                _entity.Score = Score;                
            }
            _entity.IdProfile = IdProfile;
            return _entity;
        }
    }
}