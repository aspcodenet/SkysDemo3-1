using SkysDemo3_1.Infrastructure.Paging;
using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public interface IProductService
{
    PagedResult<Product> GetAll(int categoryId,string sortColumn, 
        string sortOrder, int page, string searchWord);
}