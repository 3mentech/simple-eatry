using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Persistence;

namespace WebApp.Pages.MenuCategories
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public DetailsModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

      public MenuCategory MenuCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.MenuCategories == null)
            {
                return NotFound();
            }

            var menucategory = await _context.MenuCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (menucategory == null)
            {
                return NotFound();
            }
            else 
            {
                MenuCategory = menucategory;
            }
            return Page();
        }
    }
}
