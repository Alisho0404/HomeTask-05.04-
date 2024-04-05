using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Response;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/postComment")]
    public class PostCommentsController(IPostCommentService postCommentService):ControllerBase
    { 
        private readonly IPostCommentService _postCommentService=postCommentService;

        [HttpGet]
        public async Task<Response<List<PostComments>>> GetPostCommentsAsync()
        {
            return await _postCommentService.GetAllPostCommentsAsync();
        }

        [HttpGet("{postCommentId:int}")] 
        public async Task<Response<PostComments>> GetPostCommentsByIdAsync(int postCommentId)
        {
            return await _postCommentService.GetPostCommentsByIdAsync(postCommentId);
        }

        [HttpPost]
        public async Task<Response<string>>AddPostCommentAsync(PostComments postComment)
        {
            return await _postCommentService.AddPostCommentsAsync(postComment);
        }

        [HttpPut]
        public async Task<Response<string>>UpdatePostCommentAsync(PostComments postComment)
        {
            return await _postCommentService.UpdatePostCommentsAsync(postComment);
        }

        [HttpDelete("{pcId:int}")] 
        public async Task<Response<bool>>DeletePostCommentAsync(int pcId)
        {
            return await _postCommentService.DeletePostCommentsAsync(pcId);
        }
    }
}
