﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoboEval.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RoboEvalEntities : DbContext
    {
        public RoboEvalEntities()
            : base("name=RoboEvalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Transcript> Transcripts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
