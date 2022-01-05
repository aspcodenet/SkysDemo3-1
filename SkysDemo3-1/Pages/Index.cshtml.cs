using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysDemo3_1.Services;

namespace SkysDemo3_1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;

        public class Item
        {
            public int Id { get; set; }
            public string Namn { get; set; }
        }
        public List<Item> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public void OnGet()
        {
            Items = _categoryService.List().Select(c =>new Item
            {
                Id = c.CategoryId,
                Namn = c.CategoryName
            }).ToList();
        }
    }
}