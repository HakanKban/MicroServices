using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Catalog.Services;
public interface ICategoryService
{
    Task<ResponseDTO<List<CategoryDto>>> GetAllAsync();
    Task<ResponseDTO<CategoryDto>> CreateAsync(CategoryDto category);
    Task<ResponseDTO<CategoryDto>> GetByIdAsync(string id);
}
