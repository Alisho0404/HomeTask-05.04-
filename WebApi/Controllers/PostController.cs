using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Response;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController(IPostService postService) : ControllerBase
    {
        private readonly IPostService _postService = postService; 

        [HttpGet]
        public async Task<Response<List<Post>>> GetPostAsync()
        {
            return await _postService.GetAllPostAsync();
        }

        [HttpGet("{postId:int}")]
        public async Task<Response<Post>> GetPosByIdAsync(int postId)
        {
            return await _postService.GetPostByIdAsync(postId);
        }

        [HttpPost]
        public async Task<Response<string>> AddPostAsync(Post post)
        {
            return await _postService.AddPostAsync(post);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatePostAsync(Post post)
        {
            return await _postService.UpdatePostAsync(post);
        }

        [HttpDelete("{postId}:int")]
        public async Task<Response<bool>> DeletePostAsync(int postId)
        {
            return await _postService.DeletePostAsync(postId);
        }
    }
}
