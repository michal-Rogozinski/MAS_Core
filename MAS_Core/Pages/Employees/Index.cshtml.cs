using MAS_Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MAS_Core.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Context.CargoDatabaseContext _context;

        public IndexModel(Context.CargoDatabaseContext context)
        {
            _context = context;
        }

        public IList<CustomerService> CustomerServiceList { get; set; } = default!;
        public IList<Dispatcher> DispatcherList { get; set; } = default!;
        public IList<Warehouseman> WarehousemanList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CustomerServices != null)
            {
                CustomerServiceList = await _context.CustomerServices.ToListAsync();
                DispatcherList = await _context.Dispatchers.ToListAsync();
                WarehousemanList = await _context.Warehousemen.ToListAsync();
            }
        }
    }
}
