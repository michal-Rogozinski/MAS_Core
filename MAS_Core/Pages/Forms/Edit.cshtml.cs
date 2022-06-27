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

namespace MAS_Core.Pages.Forms
{
    public class EditModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public EditModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Form Form { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Forms == null)
            {
                return NotFound();
            }

            var form =  await _context.Forms.FirstOrDefaultAsync(m => m.FormID == id);
            if (form == null)
            {
                return NotFound();
            }
            Form = form;
           ViewData["FormID"] = new SelectList(_context.Set<Company>(), "ClientsID", "Type");
           ViewData["CustomerServiceID"] = new SelectList(_context.CustomerServices, "CustomerServiceID", "CustomerServiceID");
           ViewData["DispatcherID"] = new SelectList(_context.Dispatchers, "DispatcherID", "DispatcherID");
           ViewData["FormID"] = new SelectList(_context.Set<Individual>(), "ClientsID", "Type");
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

            _context.Attach(Form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(Form.FormID))
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

        private bool FormExists(int id)
        {
          return (_context.Forms?.Any(e => e.FormID == id)).GetValueOrDefault();
        }
    }
}
