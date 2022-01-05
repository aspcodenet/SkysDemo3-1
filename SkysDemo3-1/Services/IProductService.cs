using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll(int categoryId,string sortColumn, string sortOrder, int page);
}