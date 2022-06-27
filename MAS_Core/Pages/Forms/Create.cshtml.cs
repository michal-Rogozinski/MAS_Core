using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Forms
{
    public class CreateModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public CreateModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Company"] = new SelectList(_context.Set<Company>(), "ClientsID", "Type");
            return Page();
        }

        [BindProperty]
        public Form FormRef { get; set; } = default!;
        public Payment PaymentRef { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Forms == null || FormRef == null)
            {
                return Page();
            }

            _context.Forms.Add(FormRef);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
