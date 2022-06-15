using System.ComponentModel.DataAnnotations;

namespace EventsFactory.Models.EventPlannerViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Location { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public int NumberOfPeopleRequired { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public Availability? Availability { get; set; }
    }
}