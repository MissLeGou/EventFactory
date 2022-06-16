#define FIRST // FIRST
#if FIRST
#region snippet_first
namespace EventsFactory.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string Name { get; set; }

        public IList<ParticipantAssignment> ParticipantAssignments { get; set; }
        public IList<Event> Events { get; set; }
    }
}
#endregion
#elif PERSON
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
#endif