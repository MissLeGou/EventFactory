using System.ComponentModel.DataAnnotations;

namespace EventsFactory.Models.EventPlannerViewModels
{
    public class AssignedParticipantData
    {
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}