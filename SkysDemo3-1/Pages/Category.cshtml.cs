using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysDemo3_1.Services;

namespace SkysDemo3_1.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProductService _productService;

        public class Item
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public decimal ?UnitPrice { get; set; }
            public int ?UnitsInStock { get; set; }
        }
        public List<Item> Items { get; set; }
        public CategoryModel(IProductService productService)
        {
            _productService = productService;
        }
        public void OnGet(int categoryId)
        {
            Items = _productService.GetAll(categoryId, null, null, 0)
                .Select(e => new Item
                {
                    Id = e.ProductId,
                    Namn = e.ProductName,
                    UnitPrice = e.UnitPrice,
                    UnitsInStock = e.UnitsInStock
                }).ToList();
        }
    }
}
