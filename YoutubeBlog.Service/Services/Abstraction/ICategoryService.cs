using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDTO>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryDTO>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
    }
}
