using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysDemo3_1.Models;

namespace SkysDemo3_1.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly NorthwindContext _context;

        public SuppliersModel(NorthwindContext context)
        {
            _context = context;
        }
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<Item> Items { get; set; }

        public void OnGet()
        {
            Items = _context.Suppliers.Select(r => new Item
            {
                Id = r.SupplierId,
                Name = r.CompanyName
            }).ToList();
        }
    }
}
