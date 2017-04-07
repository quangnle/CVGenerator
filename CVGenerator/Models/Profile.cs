using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Degree { get; set; }
        public string Occupation { get; set; }
        public int YearsOfExp { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }

        internal object Extract()
        {
            throw new NotImplementedException();
        }

        public string Email { get; set; }
        public string Address { get; set; }
        public string AboutMe { get; set; }
        public string Website { get; set; }
        public string PhotoPath { get; set; }
        public List<Education> Educations { get; set; }
        public List<Reference> References { get; set; }
        public List<WorkExperience> WorkExps { get; set; }
        public List<Skill> Skills { get; set; }

        private TProfile _entity;
        public void Bind(TProfile entity)
        {
            _entity = entity;
            Id = _entity.Id;
            UserId = _entity.IdUser.HasValue ? _entity.IdUser.Value : -1;
            FirstName = _entity.FirstName;
            LastName = _entity.LastName;
            Age = _entity.Age;
            Gender = _entity.Gender == "Male" ? true : false;
            Degree = _entity.Degree;
            Occupation = _entity.Occupation;
            YearsOfExp = _entity.YearOfExp;
            Nationality = _entity.Nationality;
            PhoneNumber = _entity.PhoneNo;
            Email = _entity.Email;
            Address = _entity.Address;
            AboutMe = _entity.AboutMe;
            PhotoPath = _entity.Photo;
            Website = _entity.Website;
        }

        public TProfile GetNew()
        {
            _entity = new TProfile();

            if (UserId == -1) _entity.IdUser = null;
            else _entity.IdUser = UserId;

            _entity.LastName = LastName;
            _entity.FirstName = FirstName;
            _entity.Nationality = Nationality;
            _entity.Gender = Gender ? "Male" : "Female";
            _entity.Occupation = Occupation;
            _entity.PhoneNo = PhoneNumber;
            _entity.Website = Website;
            _entity.YearOfExp = YearsOfExp;
            _entity.Photo = PhotoPath;

            return _entity;
        }

        public void LoadSkill()
        {
            //
            // Skills = LoadSkill();
        }
    }
}