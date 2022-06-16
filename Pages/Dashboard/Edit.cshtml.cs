using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsFactory.Models;
using EventsFactory.Models.EventPlannerViewModels;

namespace EventsFactory.Pages.DashboardEvents
{
    public class EditModel : PageModel
    {
        private readonly Data.EventPlannerContext _context;

        public EditModel(Data.EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.Include(p => p.ParticipantAssignments).AsNoTracking().FirstOrDefaultAsync(m => m.EventId == id);

            if (Event == null)
            {
                return NotFound();
            }

            PopulateAssignedParticipantData(Event);


            return Page();
        }

        private void PopulateAssignedParticipantData(Event Event)
        {
            var allParticipants = _context.Participants;
            var eventParticipants = new HashSet<int>(Event.ParticipantAssignments.Select(p => p.ParticipantId));
            var viewModel = new List<AssignedParticipantData>();

            foreach (var participant in allParticipants)
            {
                if (eventParticipants.Contains(participant.ParticipantId))
                {

                    viewModel.Add(new AssignedParticipantData
                    {
                        ParticipantId = participant.ParticipantId,
                        Name = participant.Name,
                        Assigned = true
                    });
                }
            }
            ViewData["Participants"] = viewModel;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedParticipants, Event @event)
        {
            if (id == null)
            {
                return NotFound();
            }


            var eventToUpdate = await _context.Events.Include(e => e.ParticipantAssignments).ThenInclude(p => p.Participant).FirstOrDefaultAsync(m => m.EventId == id);
            eventToUpdate.Location = @event.Location;
            eventToUpdate.EventDate = @event.EventDate;
            eventToUpdate.EventTime = @event.EventTime;
            eventToUpdate.NumberOfPeopleRequired = @event.NumberOfPeopleRequired;

            if (await TryUpdateModelAsync(
                eventToUpdate,
                "",
                e => e.Location, e => e.EventDate, e => e.EventTime, e => e.NumberOfPeopleRequired))
            {
                UpdateEventParticipants(selectedParticipants, eventToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }


            UpdateEventParticipants(selectedParticipants, eventToUpdate);
            PopulateAssignedParticipantData(eventToUpdate);
            return RedirectToPage("./Index");
        }

        private void UpdateEventParticipants(string[] selectedParticipants, Event eventToUpdate)
        {
            if (selectedParticipants == null)
            {
                eventToUpdate.ParticipantAssignments = new List<ParticipantAssignment>();
                return;
            }

            var selectedParticipantsHS = new HashSet<string>(selectedParticipants);
            var eventParticipants = new HashSet<int>
                (eventToUpdate.ParticipantAssignments.Select(p => p.Participant.ParticipantId));

            foreach (var participant in _context.Participants)
            {
                if (selectedParticipantsHS.Contains(participant.ParticipantId.ToString()))
                {
                    if (!eventParticipants.Contains(participant.ParticipantId))
                    {
                        eventToUpdate.ParticipantAssignments.Add(new ParticipantAssignment { EventId = eventToUpdate.EventId, ParticipantId = participant.ParticipantId});
                    }
                }
                else
                {

                    if (eventParticipants.Contains(participant.ParticipantId))
                    {
                        ParticipantAssignment participantToRemove = eventToUpdate.ParticipantAssignments.FirstOrDefault(e => e.ParticipantId == participant.ParticipantId);
                        _context.Remove(participantToRemove);
                    }
                }
            }
        }
    }
}
