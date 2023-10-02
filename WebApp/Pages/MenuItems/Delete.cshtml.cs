using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Persistence;

namespace WebApp.Pages.MenuItems
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public DeleteModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);

            if (menuitem == null)
            {
                return NotFound();
            }
            else 
            {
                MenuItem = menuitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }
            var menuitem = await _context.MenuItems.FindAsync(id);

            if (menuitem != null)
            {
                MenuItem = menuitem;
                _context.MenuItems.Remove(MenuItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
