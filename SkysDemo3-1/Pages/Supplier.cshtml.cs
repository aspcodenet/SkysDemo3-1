using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysDemo3_1.Models;

namespace SkysDemo3_1.Pages
{
    public class SupplierModel : PageModel
    {
        private readonly NorthwindContext _context;
        public string SupplierName { get; set; }

        public SupplierModel(NorthwindContext context)
        {
            _context = context;
        }
        public void OnGet(int bajskorv)
        {
            SupplierName = _context.Suppliers.First(r => r.SupplierId == bajskorv).CompanyName;
        }
    }
}
