using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MAS_Core.Context;
using MAS_Core.Models;

namespace MAS_Core.Pages.Employees.E1
{
    public class DetailsModel : PageModel
    {
        private readonly MAS_Core.Context.CargoDatabaseContext _context;

        public DetailsModel(MAS_Core.Context.CargoDatabaseContext context)
        {
            _context = context;
        }

      public CustomerService CustomerService { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerServices == null)
            {
                return NotFound();
            }

            var customerservice = await _context.CustomerServices.FirstOrDefaultAsync(m => m.CustomerServiceID == id);
            if (customerservice == null)
            {
                return NotFound();
            }
            else 
            {
                CustomerService = customerservice;
            }
            return Page();
        }
    }
}
