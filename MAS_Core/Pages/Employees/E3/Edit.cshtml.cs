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

namespace MAS_Core.Pages.Employees.E3
{
    public class EditModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public EditModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Warehouseman Warehouseman { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Warehousemen == null)
            {
                return NotFound();
            }

            var warehouseman =  await _context.Warehousemen.FirstOrDefaultAsync(m => m.WarehousemanID == id);
            if (warehouseman == null)
            {
                return NotFound();
            }
            Warehouseman = warehouseman;
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

            _context.Attach(Warehouseman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehousemanExists(Warehouseman.WarehousemanID))
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

        private bool WarehousemanExists(int id)
        {
          return (_context.Warehousemen?.Any(e => e.WarehousemanID == id)).GetValueOrDefault();
        }
    }
}
