using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Employees.E2
{
    public class EditModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public EditModel(MAS_Core.Context.CargoDatabaseContext context)
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

            var dispatcher =  await _context.Dispatchers.FirstOrDefaultAsync(m => m.DispatcherID == id);
            if (dispatcher == null)
            {
                return NotFound();
            }
            Dispatcher = dispatcher;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dispatcher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispatcherExists(Dispatcher.DispatcherID))
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

        private bool DispatcherExists(int id)
        {
          return (_context.Dispatchers?.Any(e => e.DispatcherID == id)).GetValueOrDefault();
        }
    }
}
