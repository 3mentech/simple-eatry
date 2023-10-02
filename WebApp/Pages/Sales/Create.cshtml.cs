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
    public class CreateModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;
        public List<SelectListItem> BranchesLookup { get; set; }
        public List<SelectListItem> MenuItemsLookup { get; set; }
        public List<SelectListItem> PortionSizeLookup { get; set; }

        public CreateModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
            
            return Page();
        }

        [BindProperty]
        public SalesTransaction SalesTransaction { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (SalesTransaction == null)
          {
              return Page();
          }

          _context.SalesTransactions.Add(SalesTransaction);
          await _context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}
