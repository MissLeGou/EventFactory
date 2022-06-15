using System.ComponentModel.DataAnnotations;

namespace EventsFactory.Models
{
    public class ParticipantAssignment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        
        public Participant Participant { get; set; }
        public Event Event { get; set; }
    }
}
