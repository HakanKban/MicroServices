using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using MongoDB.Driver;
using System.Net;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings )
        {
            var client = new  MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoriesCollectionName);
            _mapper = mapper;
        }

        public async Task<ResponseDTO<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(ca => true).ToListAsync();
            return ResponseDTO<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories),(int)HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<CategoryDto>> CreateAsync(CategoryDto category)
        {
            await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(category));
            return ResponseDTO<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), (int)HttpStatusCode.OK);
        }
        public async Task<ResponseDTO<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category is null)
            {
                return ResponseDTO<CategoryDto>.Fail("Category bulunamadı", (int)HttpStatusCode.NotFound);
            }

            return ResponseDTO<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), (int)HttpStatusCode.OK);
        }



    }
}
