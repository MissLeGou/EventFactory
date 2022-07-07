using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsFactory.Models;

namespace EventsFactory.Pages.DashboardEvents
{
    public class CreateModel : PageModel
    {
        private readonly Data.EventPlannerContext _context;

        public CreateModel(Data.EventPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Event = new Event { EventId = 1, Location = "London", EventDate = "22/07/2022", EventTime = "10:00 - 12:00", NumberOfPeopleRequired = 2 };
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
