using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Wagons
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
        public Wagon Wagon { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Wagons == null || Wagon == null)
            {
                return Page();
            }

            _context.Wagons.Add(Wagon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
