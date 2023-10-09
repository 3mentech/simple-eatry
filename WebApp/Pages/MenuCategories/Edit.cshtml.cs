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

namespace WebApp.Pages.MenuCategories
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public EditModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MenuCategory MenuCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.MenuCategories == null)
            {
                return NotFound();
            }

            var menucategory =  await _context.MenuCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (menucategory == null)
            {
                return NotFound();
            }
            MenuCategory = menucategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MenuCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCategoryExists(MenuCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MenuCategoryExists(Guid id)
        {
          return (_context.MenuCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
