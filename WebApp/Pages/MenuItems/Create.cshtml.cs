using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Persistence;

namespace WebApp.Pages.MenuItems
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;
        public List<SelectListItem> CategoryLookup { get; set; }

        public CreateModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CategoryLookup = _context.MenuCategories.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
            }).AsNoTracking().ToList();
            return Page();
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if ( MenuItem == null)
            {
                return Page();
            }

            _context.MenuItems.Add(MenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
