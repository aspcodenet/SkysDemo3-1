using SkysDemo3_1.Models;

namespace SkysDemo3_1.Services;

public interface ICategoryService
{
    IEnumerable<Category> List();
}