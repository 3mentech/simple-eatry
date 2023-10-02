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
    public class IndexModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public IndexModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        public IList<SalesTransaction> SalesTransaction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SalesTransactions != null)
            {
                SalesTransaction = await _context.SalesTransactions.
                    Include(x=> x.Branch).
                    Include(x=> x.Item).
                    AsNoTracking().ToListAsync();
            }
        }
    }
}
