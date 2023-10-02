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

namespace WebApp.Pages.Sales
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;
        
        public List<SelectListItem> BranchesLookup { get; set; }
        public List<SelectListItem> MenuItemsLookup { get; set; }
        public List<SelectListItem> PortionSizeLookup { get; set; }

        public EditModel(WebApp.Persistence.SimpleEatryDbContext context)
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
            
            BranchesLookup = _context.Branches.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
            }).AsNoTracking().ToList();
            
            MenuItemsLookup = _context.MenuItems.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
            }).AsNoTracking().ToList();
            
            PortionSizeLookup = Enum.GetValues(typeof(Size)).Cast<Size>().Select(v => new SelectListItem {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            var salestransaction =  await _context.SalesTransactions.FirstOrDefaultAsync(m => m.Id == id);
            if (salestransaction == null)
            {
                return NotFound();
            }
            SalesTransaction = salestransaction;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (SalesTransaction == null)
            {
                return Page();
            }

            _context.Attach(SalesTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesTransactionExists(SalesTransaction.Id))
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

        private bool SalesTransactionExists(Guid id)
        {
          return (_context.SalesTransactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
