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
    public class IndexModel : PageModel
    {
        private readonly WebApp.Persistence.SimpleEatryDbContext _context;

        public IndexModel(WebApp.Persistence.SimpleEatryDbContext context)
        {
            _context = context;
        }

        public IList<Branch> Branch { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Branches != null)
            {
                Branch = await _context.Branches.ToListAsync();
            }
        }
    }
}
