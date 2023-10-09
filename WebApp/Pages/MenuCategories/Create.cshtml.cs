using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Entities;
using WebApp.Persistence;

namespace WebApp.Pages.MenuCategories
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public CreateModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MenuCategory MenuCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MenuCategories == null || MenuCategory == null)
            {
                return Page();
            }

            _context.MenuCategories.Add(MenuCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
