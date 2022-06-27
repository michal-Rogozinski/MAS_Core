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
        ViewData["FormID"] = new SelectList(_context.Set<Company>(), "ClientsID", "Type");
        ViewData["CustomerServiceID"] = new SelectList(_context.CustomerServices, "CustomerServiceID", "CustomerServiceID");
        ViewData["DispatcherID"] = new SelectList(_context.Dispatchers, "DispatcherID", "DispatcherID");
        ViewData["FormID"] = new SelectList(_context.Set<Individual>(), "ClientsID", "Type");
            return Page();
        }

        [BindProperty]
        public Form FormRef { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyForm = new Form();
            if (await TryUpdateModelAsync<Form>(
                emptyForm, "Form", s => s.FormID,s => s.PaymentID,s => s.CustomerServiceID, s=> s.DispatcherID, s=> s.ClientsID, s=> s.Distance, s=> s.DepartureName,s => s.DepartureName, s=> s.PayloadType))
            {
                _context.Forms.Add(emptyForm);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
