using SkysDemo3_1.Models;
using SkysDemo3_1.Pages;
using Microsoft.Data.SqlClient;
using SkysDemo3_1.Infrastructure.Paging;

namespace SkysDemo3_1.Services;

public class SupplierService : ISupplierService
{
    private readonly NorthwindContext _context;

    public SupplierService(NorthwindContext context)
    {
        _context = context;
    }
    public List<Supplier> GetSuppliers(string sortColumn, ExtensionMethods.QuerySortOrder sortOrder)
    {
        var query = _context.Suppliers.AsQueryable();
        if (string.IsNullOrEmpty(sortColumn))
            sortColumn = nameof(Supplier.CompanyName);

        
        query = query.OrderBy(sortColumn, sortOrder);
        return query.ToList();
    }
}