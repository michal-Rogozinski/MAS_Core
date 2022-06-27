using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Employees.E2
{
    public class DeleteModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public DeleteModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Dispatcher Dispatcher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dispatchers == null)
            {
                return NotFound();
            }

            var dispatcher = await _context.Dispatchers.FirstOrDefaultAsync(m => m.DispatcherID == id);

            if (dispatcher == null)
            {
                return NotFound();
            }
            else 
            {
                Dispatcher = dispatcher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dispatchers == null)
            {
                return NotFound();
            }
            var dispatcher = await _context.Dispatchers.FindAsync(id);

            if (dispatcher != null)
            {
                Dispatcher = dispatcher;
                _context.Dispatchers.Remove(Dispatcher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
