using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperUniversity.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}