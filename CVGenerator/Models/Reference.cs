using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Reference : IConvertibleModel<TReference>
    {
        private TReference _entity;

        public int Id { get; set; }

        public int IdProfile { get; set; }
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Relationship { get; set; }

        public void Bind(TReference entity)
        {
            _entity = entity;

            Initial = entity.Initial;
            LastName = entity.LastName;
            FirstName = entity.FirstName;
            Email = entity.Email;
            Phone = entity.Phone;
            Relationship = entity.Relationship;

            IdProfile = entity.IdProfile;
        }

        public TReference GetEntity()
        {
            _entity = new TReference();

            _entity.Initial = Initial;
            _entity.LastName = LastName;
            _entity.FirstName = FirstName;
            _entity.Email = Email;
            _entity.Phone = Phone;
            _entity.Relationship = Relationship;
            _entity.IdProfile = IdProfile;

            return _entity;
        }
        
        public void Update(TReference entity)
        {
            entity.Initial = Initial;
            entity.LastName = LastName;
            entity.FirstName = FirstName;
            entity.Email = Email;
            entity.Phone = Phone;
            entity.Relationship = Relationship;
        }
    }
}