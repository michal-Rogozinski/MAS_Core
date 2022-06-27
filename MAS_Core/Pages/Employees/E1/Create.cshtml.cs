using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Employees.E1
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
            return Page();
        }

        [BindProperty]
        public CustomerService CustomerService { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CustomerServices == null || CustomerService == null)
            {
                return Page();
            }

            _context.CustomerServices.Add(CustomerService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
