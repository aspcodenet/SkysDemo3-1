using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public class ProductService : IProductService
{
    private readonly NorthwindContext _context;

    public ProductService(NorthwindContext context)
    {
        _context = context;
    }
    public IEnumerable<Product> GetAll(int categoryId, string sortColumn, string sortOrder, int page)
    {
        // ProductName, UnitPrice och UnitsInStock
        var query = _context.Products.Where(r=>r.Category.CategoryId == categoryId  );
        
        if (string.IsNullOrEmpty(sortColumn))
        {
            sortColumn = "ProductName";
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            sortOrder = "asc";
        }

        if (sortColumn == "ProductName")
        {
            if (sortOrder == "desc")
                query = query.OrderByDescending(r => r.ProductName);
            else
                query = query.OrderBy(r => r.ProductName);
        }

        if (sortColumn == "UnitPrice")
        {
            if (sortOrder == "desc")
                query = query.OrderByDescending(r => r.UnitPrice);
            else
                query = query.OrderBy(r => r.UnitPrice);
        }

        if (sortColumn == "UnitsInStock")
        {
            if (sortOrder == "desc")
                query = query.OrderByDescending(r => r.UnitsInStock);
            else
                query = query.OrderBy(r => r.UnitsInStock);
        }

        return query.ToList();

    }
}