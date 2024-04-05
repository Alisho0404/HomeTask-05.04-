using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController(ICategoryService categoryService):ControllerBase
    { 
        private readonly ICategoryService _categoryService=categoryService;

        [HttpGet]
        public async Task<Response<List<Category>>> GetCategoryAsync()
        {
            return await _categoryService.GetAllCategoriesAsync();
        }

        [HttpGet("{CategoryId:int}")]
        public async Task<Response<Category>> GetCategoryByIdAsync(int CategoryId)
        {
            return await _categoryService.GetCategoryByIdAsync(CategoryId);
        }

        [HttpPost]
        public async Task<Response<string>> AddCategoryAsync(Category Category)
        {
            return await _categoryService.AddCategoryAsync(Category);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateCategoryAsync(Category Category)
        {
            return await _categoryService.UpdateCategoryAsync(Category);
        }

        [HttpDelete("{CategoryId}:int")]
        public async Task<Response<bool>> DeleteCategoryAsync(int CategoryId)
        {
            return await _categoryService.DeleteCategoryAsync(CategoryId);
        }
    }
}
