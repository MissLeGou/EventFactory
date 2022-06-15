using System.ComponentModel.DataAnnotations;

namespace EventsFactory.Models
{
    public class ParticipantAssignment
    {
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
        public Participant Participant { get; set; }
        public Event Event { get; set; }
    }
}
