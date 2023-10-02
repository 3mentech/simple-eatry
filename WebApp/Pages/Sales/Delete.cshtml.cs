using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Persistence;

namespace WebApp.Pages.Sales
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public DeleteModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SalesTransaction SalesTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.SalesTransactions == null)
            {
                return NotFound();
            }

            var salestransaction = await _context.SalesTransactions.FirstOrDefaultAsync(m => m.Id == id);

            if (salestransaction == null)
            {
                return NotFound();
            }
            else 
            {
                SalesTransaction = salestransaction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.SalesTransactions == null)
            {
                return NotFound();
            }
            var salestransaction = await _context.SalesTransactions.FindAsync(id);

            if (salestransaction != null)
            {
                SalesTransaction = salestransaction;
                _context.SalesTransactions.Remove(SalesTransaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
