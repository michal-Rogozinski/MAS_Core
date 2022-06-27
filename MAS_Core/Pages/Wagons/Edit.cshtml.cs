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

namespace MAS_Core.Pages.Wagons
{
    public class EditModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public EditModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wagon Wagon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wagons == null)
            {
                return NotFound();
            }

            var wagon =  await _context.Wagons.FirstOrDefaultAsync(m => m.WagonID == id);
            if (wagon == null)
            {
                return NotFound();
            }
            Wagon = wagon;
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

            _context.Attach(Wagon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WagonExists(Wagon.WagonID))
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

        private bool WagonExists(int id)
        {
          return (_context.Wagons?.Any(e => e.WagonID == id)).GetValueOrDefault();
        }
    }
}
