﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVGenerator.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GvGenEntities : DbContext
    {
        public GvGenEntities()
            : base("name=GvGenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TEducation> TEducations { get; set; }
        public virtual DbSet<TProfile> TProfiles { get; set; }
        public virtual DbSet<TReference> TReferences { get; set; }
        public virtual DbSet<TResume> TResumes { get; set; }
        public virtual DbSet<TSkill> TSkills { get; set; }
        public virtual DbSet<TTemplate> TTemplates { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }
        public virtual DbSet<TWorkExperience> TWorkExperiences { get; set; }
    }
}