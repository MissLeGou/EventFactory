#define FIRST
#if FIRST  // First DbInitializer used
#region snippet
using EventsFactory.Models;

namespace EventsFactory.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EventPlannerContext context)
        {
            // Look for any events.
            if (context.Events.Any())
            {
                return;   // DB has been seeded
            }

            var events = new Event[]
            {
                new Event{EventId= 1, Location="London", EventDate="22/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available},
                new Event{EventId= 2, Location="London", EventDate="12/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available},
                new Event{EventId= 3, Location="London", EventDate="15/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available},
                new Event{EventId= 4, Location="London", EventDate="18/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available},
                new Event{EventId= 5, Location="London", EventDate="20/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available},
                new Event{EventId= 6, Location="London", EventDate="25/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available},
                new Event{EventId= 7, Location="London", EventDate="19/07/2022", EventTime="10:00 - 12:00", NumberOfPeopleRequired= 2, Availability= Availability.Available}
            };

            context.Events.AddRange(events);
            context.SaveChanges();

        }
    }
}
#endregion
#endif