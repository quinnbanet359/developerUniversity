using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using DeveloperUniversity.Models;

namespace DeveloperUniversity.DAL
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext() : base("name=DbConnectionString")
        {
        }

        //Note: Must initialized all DbSets here before setting up mapping below, if you choose
        //      to do it this way. Like so.
        //public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Note: Could do mapping here for each DbSet instead of creating separate mapping files.
            //modelBuilder.Entity<Student>().HasKey(p => p.Id);

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<DeveloperUniversity.Models.Student> Student { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Course> Course { get; set; }

    }
}