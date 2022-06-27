using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Wagons
{
    public class DetailsModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public DetailsModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

      public Wagon Wagon { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wagons == null)
            {
                return NotFound();
            }

            var wagon = await _context.Wagons.FirstOrDefaultAsync(m => m.WagonID == id);
            if (wagon == null)
            {
                return NotFound();
            }
            else 
            {
                Wagon = wagon;
            }
            return Page();
        }
    }
}
