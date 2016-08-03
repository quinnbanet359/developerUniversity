﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DeveloperUniversity.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
    }
}