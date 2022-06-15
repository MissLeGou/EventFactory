#define FIRST
#if FIRST
#region snippet_first
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsFactory.Models
{
    public enum Availability
    {
        Available, Booked, FullyBooked
    }
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }
        public string Location { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }

        [Display(Name = "Number Of People Required")]
        public int NumberOfPeopleRequired { get; set; }

        [Display(Name = "Participant Names")]
        [DisplayFormat(NullDisplayText = "")]
        public ICollection<Participant> Participants { get; set; }

        [DisplayFormat(NullDisplayText = "Available")]
        public Availability? Availability { get; set; }

    }
}
#endregion
#elif LAST
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
#region snippet_last
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
#endregion
#endif