using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysDemo3_1.Infrastructure.Paging;
using SkysDemo3_1.Models;
using SkysDemo3_1.Services;

namespace SkysDemo3_1.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public SuppliersModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }  
            public string City { get; set; }
        }

        public List<Item> Items { get; set; }

        //? sortOrder=desc&sort
        public void OnGet(string sortColumn, ExtensionMethods.QuerySortOrder sortOrder)
        {
            Items = _supplierService.GetSuppliers(sortColumn, sortOrder)
                .Select(r => new Item
                {
                    Id = r.SupplierId,
                    City = r.City,
                    Country = r.Country,
                    Name = r.CompanyName
                }).ToList();
        }
    }
}
