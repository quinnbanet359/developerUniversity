using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DeveloperUniversity.Models;

namespace DeveloperUniversity.Mapping
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Title).IsRequired();
            Property(p => p.Credits).IsRequired();

            HasMany(p => p.Enrollments);
        }
    }
}