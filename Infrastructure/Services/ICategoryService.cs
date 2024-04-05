using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<Response<List<Category>>> GetAllCategoriesAsync();
        Task<Response<Category>> GetCategoryByIdAsync(int id);
        Task<Response<string>> AddCategoryAsync(Category category); 
        Task<Response<string>> UpdateCategoryAsync(Category category);
        Task<Response<bool>> DeleteCategoryAsync(int id);
    }
}
