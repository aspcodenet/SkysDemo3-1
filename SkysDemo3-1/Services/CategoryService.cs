using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public class CategoryService : ICategoryService
{
    private readonly NorthwindContext _context;

    public CategoryService(NorthwindContext context)
    {
        _context = context;
    }
    public IEnumerable<Category> List()
    {
        return _context.Categories;
    }
}