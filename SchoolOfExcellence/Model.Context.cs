﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolOfExcellence
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolOfExcellenceEntities : DbContext
    {
        public SchoolOfExcellenceEntities()
            : base("name=SchoolOfExcellenceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Cabinet> Cabinet { get; set; }
        public virtual DbSet<DayOfWeek> DayOfWeek { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Headmaster> Headmaster { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<SkipVisit> SkipVisit { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentActivity> StudentActivity { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeacherActivity> TeacherActivity { get; set; }
    }
}
