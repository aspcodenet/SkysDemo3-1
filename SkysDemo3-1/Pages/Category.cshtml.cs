using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysDemo3_1.Services;

namespace SkysDemo3_1.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public class Item
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public decimal ?UnitPrice { get; set; }
            public int ?UnitsInStock { get; set; }
        }
        public string CategoryName { get; set; }
        public string SortOrder { get; set; }
        public string SortColumn { get; set; }
        public int CategoryId { get; set; }
        public List<Item> Items { get; set; }
        public int CurrentPage { get; set; }
        public string SearchWord { get; set; }
        public CategoryModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public void OnGet(int categoryId, string sortColumn, string sortOrder, 
            int pageno, string searchWord)
        {
            CategoryName = _categoryService.GetCategory(categoryId).CategoryName;
            SearchWord = searchWord;
            SortOrder = sortOrder;
            SortColumn = sortColumn;
            if (pageno == 0)
                pageno = 1;
            CurrentPage = pageno;

            CategoryId = categoryId;
            Items = _productService.GetAll(categoryId, sortColumn, sortOrder, CurrentPage, searchWord)
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
