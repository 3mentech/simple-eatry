using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Persistence;

namespace WebApp.Pages.Branches
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public DetailsModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

      public Branch Branch { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Branches == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches.FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }
            else 
            {
                Branch = branch;
            }
            return Page();
        }
    }
}
