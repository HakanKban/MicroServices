using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<ResponseDTO<List<CourseDto>>> GetAllAsync();

        Task<ResponseDTO<CourseDto>> GetByIdAsync(string id);

        Task<ResponseDTO<List<CourseDto>>> GetAllByUserIdAsync(string userId);

        Task<ResponseDTO<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);

        Task<ResponseDTO<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);

        Task<ResponseDTO<NoContent>> DeleteAsync(string id);
    }
}
