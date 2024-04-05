using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/tag")]
    public class TagController(ITagService tagService):ControllerBase
    { 
        private readonly ITagService _tagService=tagService;

        [HttpGet]
        public async Task<Response<List<Tags>>> GetTagsAsync()
        {
            return await _tagService.GetAllTagsAsync();
        }

        [HttpGet("{TagsId:int}")]
        public async Task<Response<Tags>> GetTagsByIdAsync(int TagsId)
        {
            return await _tagService.GetTagByIdAsync(TagsId);
        }

        [HttpPost]
        public async Task<Response<string>> AdTagstAsync(Tags Tags)
        {
            return await _tagService.AddTagAsync(Tags);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatePostAsync(Tags Tags)
        {
            return await _tagService.UpdateTagAsync(Tags);
        }

        [HttpDelete("{TagsId}:int")]
        public async Task<Response<bool>> DeleteTagsAsync(int TagsId)
        {
            return await _tagService.DeleteTagAsync(TagsId);
        }
    }
}
