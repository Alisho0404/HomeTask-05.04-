using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPostCategoryService
    {
        Task<Response<List<PostCategory>>> GetAllPostCategoryAsync();
        Task<Response<PostCategory>> GetPostCategoryByIdAsync(int id);
        Task<Response<string>> AddPostCategoryAsync(PostCategory postCategory);
        Task<Response<string>> UpdatePostCategoryAsync(PostCategory postCategory);
        Task<Response<bool>> DeletePostCategoryAsync(int id);
    }
}
