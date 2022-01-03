using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public interface ISupplierService
{
    List<Supplier> GetSuppliers(string sortColumn, string sortOrder);
}