using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Employees.E3
{
    public class DetailsModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public DetailsModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

      public Warehouseman Warehouseman { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Warehousemen == null)
            {
                return NotFound();
            }

            var warehouseman = await _context.Warehousemen.FirstOrDefaultAsync(m => m.WarehousemanID == id);
            if (warehouseman == null)
            {
                return NotFound();
            }
            else 
            {
                Warehouseman = warehouseman;
            }
            return Page();
        }
    }
}
