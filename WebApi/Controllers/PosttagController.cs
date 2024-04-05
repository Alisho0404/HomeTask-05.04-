using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/postTag")]
    public class PosttagController(IPostTagService postTagService):ControllerBase
    { 
        private readonly IPostTagService _posttagService=postTagService;

        [HttpGet]
        public async Task<Response<List<Posttag>>> GePosttagtAsync()
        {
            return await _posttagService.GetAllPosttagAsync();
        }

        [HttpGet("{PosttagtId:int}")]
        public async Task<Response<Posttag>> GetPosttagByIdAsync(int PosttagId)
        {
            return await _posttagService.GetPosttagByIdAsync(PosttagId);
        }

        [HttpPost]
        public async Task<Response<string>> AddPosttagAsync(Posttag Posttag)
        {
            return await _posttagService.AddPosttagAsync(Posttag);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatePosttagAsync(Posttag Posttag)
        {
            return await _posttagService.UpdatePosttagAsync(Posttag);
        }

        [HttpDelete("{PosttagId}:int")]
        public async Task<Response<bool>> DeletePosttagAsync(int PosttagId)
        {
            return await _posttagService.DeletePosttagAsync(PosttagId);
        }
    }
}
