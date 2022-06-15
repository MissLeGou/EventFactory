using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsFactory.Data;
using EventsFactory.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsFactory.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public IndexModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.Include(e => e.ParticipantAssignments).ThenInclude(e => e.Participant).AsNoTracking().OrderBy(e => e.EventDate).ToListAsync();
            
        }
    }
}
