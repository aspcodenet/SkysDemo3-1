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
            public string Country { get; set; }  
            public string City { get; set; }
        }

        public List<Item> Items { get; set; }

        public void OnGet(string sortColumn)
        {
            var query = _context.Suppliers.Select(r => new Item
            {
                Id = r.SupplierId,
                Name = r.CompanyName,
                City = r.City,
                Country = r.Country
            });
            if (sortColumn == "Country")
                query = query.OrderBy(r => r.Country);
            else if(sortColumn == "Namn")
                query = query.OrderBy(r => r.Name);
            else if (sortColumn == "City")
                query = query.OrderBy(r => r.City);

            Items = query.ToList();
        }
    }
}
