using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SkysDemo3_1.Infrastructure.Paging;
using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public class ProductService : IProductService
{
    private readonly NorthwindContext _context;

    public ProductService(NorthwindContext context)
    {
        _context = context;
    }
    public PagedResult<Product> GetAll(int categoryId, string sortColumn, 
        string sortOrder, int page, string searchWord) 
    {
        // ProductName, UnitPrice och UnitsInStock
        var query = _context.Products.Where(r=>r.Category.CategoryId == categoryId  );
        if (!string.IsNullOrEmpty(searchWord))
        {
            query = query
                    .Where(r=>r.ProductName.Contains(searchWord) || 
                                   r.Supplier.CompanyName.Contains(searchWord) );
        }

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


        return  query.GetPaged(page,5); // 5:an är ju pagesize - parameter kanske?
    }
}