using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsFactory.Models;
using EventsFactory.Models.EventPlannerViewModels;

namespace EventsFactory.Pages.Events
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

            return Page();
        }

        [BindProperty]
        public Participant Participant { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var selectedEvent = Event;

            Participant.Events = new List<Event>
            {
                _context.Events.First(e => e.EventId == selectedEvent.EventId)
            };


            Participant.ParticipantAssignments = new List<ParticipantAssignment> {
                new ParticipantAssignment
                {
                    EventId = selectedEvent.EventId,
                    Participant = Participant,
                }
            };

            _context.Participants.Add(Participant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}
