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

namespace MAS_Core.Pages.Employees.E1
{
    public class EditModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public EditModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerService CustomerService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerServices == null)
            {
                return NotFound();
            }

            var customerservice =  await _context.CustomerServices.FirstOrDefaultAsync(m => m.CustomerServiceID == id);
            if (customerservice == null)
            {
                return NotFound();
            }
            CustomerService = customerservice;
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

            _context.Attach(CustomerService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerServiceExists(CustomerService.CustomerServiceID))
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

        private bool CustomerServiceExists(int id)
        {
          return (_context.CustomerServices?.Any(e => e.CustomerServiceID == id)).GetValueOrDefault();
        }
    }
}
