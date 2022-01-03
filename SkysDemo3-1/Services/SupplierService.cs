using SkysDemo3_1.Models;
using SkysDemo3_1.Pages;
using Microsoft.Data.SqlClient;

namespace SkysDemo3_1.Services;

public class SupplierService : ISupplierService
{
    private readonly NorthwindContext _context;

    public SupplierService(NorthwindContext context)
    {
        _context = context;
    }
    public List<Supplier> GetSuppliers(string sortColumn, string sortOrder)
    {
        var query = _context.Suppliers.AsQueryable();

        if (sortColumn == "Country")
            if (sortOrder == "asc")
                query = query.OrderBy(r => r.Country);
            else
                query = query.OrderByDescending(r => r.Country);

        else if (sortColumn == "Namn" || string.IsNullOrEmpty(sortColumn))
            if (sortOrder == "desc")
                query = query.OrderByDescending(r => r.CompanyName);
            else
                query = query.OrderBy(r => r.CompanyName);


        else if (sortColumn == "City")
            if (sortOrder == "asc")
                query = query.OrderBy(r => r.City);
            else
                query = query.OrderByDescending(r => r.City);

        return query.ToList();
    }
}