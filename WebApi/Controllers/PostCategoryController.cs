using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Response;
using Microsoft.VisualBasic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/postCategory")]
    public class PostCategoryController(IPostCategoryService postCategoryService):ControllerBase 
    { 
        private readonly IPostCategoryService _postCategoryService=postCategoryService;

        [HttpGet]
        public async Task<Response<List<PostCategory>>> GetPostCategoryAsync()
        {
            return await _postCategoryService.GetAllPostCategoryAsync();
        }

        [HttpGet("{postCategoryId:int}")]
        public async Task<Response<PostCategory>> GetPostCategoryByIdAsync(int postCategoryId)
        {
            return await _postCategoryService.GetPostCategoryByIdAsync(postCategoryId);
        }

        [HttpPost]
        public async Task<Response<string>>AddPOstCategoryAsync(PostCategory postCategory)
        {
            return await _postCategoryService.UpdatePostCategoryAsync(postCategory);
        }

        [HttpPut] 
        public async Task<Response<string>>UpdatePostCategoryAsync(PostCategory postCategory)
        {
            return await _postCategoryService.UpdatePostCategoryAsync(postCategory);
        }

        [HttpDelete("{postCategoryId:int}")] 
        public async Task<Response<bool>>DeletePostCategoryAsync(int postCategoryId)
        {
            return await _postCategoryService.DeletePostCategoryAsync(postCategoryId);
        }

    }
}
