using CVGenerator.Entities;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Profile : TProfile
    {
        internal object Extract()
        {
            throw new NotImplementedException();
        }



        private TProfile _entity;
        //public void Bind(TProfile entity)
        //{
        //    _entity = entity;
        //    Id = _entity.Id;
        //    UserId = _entity.IdUser.HasValue ? _entity.IdUser.Value : -1;
        //    FirstName = _entity.FirstName;
        //    LastName = _entity.LastName;
        //    Age = _entity.Age;
        //    Gender = _entity.Gender == "Male" ? true : false;
        //    Degree = _entity.Degree;
        //    Occupation = _entity.Occupation;
        //    YearsOfExp = _entity.YearOfExp;
        //    Nationality = _entity.Nationality;
        //    PhoneNumber = _entity.PhoneNo;
        //    Email = _entity.Email;
        //    Address = _entity.Address;
        //    AboutMe = _entity.AboutMe;
        //    PhotoPath = _entity.Photo;
        //    Website = _entity.Website;
        //}

        public TProfile GetNew()
        {
            //_entity = new TProfile();

            //if (UserId == -1) _entity.IdUser = null;
            //else _entity.IdUser = UserId;

            //_entity.LastName = LastName;
            //_entity.FirstName = FirstName;
            //_entity.Nationality = Nationality;
            //_entity.Gender = Gender ? "Male" : "Female";
            //_entity.Occupation = Occupation;
            //_entity.PhoneNo = PhoneNumber;
            //_entity.Website = Website;
            //_entity.YearOfExp = YearsOfExp;
            //_entity.Photo = PhotoPath;
            // this.IdProfile = Guid.NewGuid();

            var _entity = new TProfile();
            _entity.InjectFrom(this);
            if (_entity.Id == 0)
            {
                _entity.IdProfile = Guid.NewGuid();
            }

            return _entity;
        }

        public void LoadSkill()
        {
            //
            // Skills = LoadSkill();
        }
    }
}