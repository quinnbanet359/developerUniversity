using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DeveloperUniversity.Models;

namespace DeveloperUniversity.Mapping
{
    public class EnrollmentMapping : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.CourseId).IsRequired();
            Property(p => p.Grade).IsOptional();
            Property(p => p.StudentId).IsRequired();

            HasRequired(p => p.Course);
            HasRequired(p => p.Student);
        }
    }
}