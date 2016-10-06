using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;

namespace DeveloperUniversity.Models
{
    public class Event
    {
        [Required]
        [Display(Name = "Event ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Attendence Cost")]
        [DataType(DataType.Currency, ErrorMessage = "Please Provide a Currency Value")]
        public decimal? AttendenceCost { get; set; }

        [Required]
        [Display(Name = "Type of Event")]
        public string EventType { get; set; }


        [Display(Name = "Starting Date")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a Valid Date")]
        public DateTime? EventStartDate { get; set; }

        [Display(Name = "Ending Date")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a Valid Date")]
        public DateTime? EventEndDate { get; set; }

        [Required]
        [DataType(DataType.Time, ErrorMessage = "Please Enter a Valid Time")]
        public TimeSpan? EventTime { get; set; }
    }
}