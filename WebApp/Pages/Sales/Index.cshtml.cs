using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Models.ViewModels;
using WebApp.Persistence;

namespace WebApp.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public IndexModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }
        public IList<SalesListViewModel> Sales { get; set; } = default;

        public async Task OnGetAsync()
        {
            if (_context.SalesTransactions != null)
            {
                Sales = await _context.SalesTransactions.
                    Include(x=> x.Branch).
                    Include(x=> x.Item).
                    AsNoTracking().Select( s => new SalesListViewModel
                    {
                        Id =  s.Id,
                        Date = s.Date,
                        FromTime = s.FromTime,
                        ToTime = s.ToTime,
                        BranchName = s.Branch.Name,
                        PortionSize = s.Size.ToString(),
                        MenuItemName = s.Item.Name,
                        Quantity = s.Quantity
                    }).ToListAsync();
            }
        }
    }
}
