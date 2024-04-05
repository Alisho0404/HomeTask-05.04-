using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/postmeta")]
    public class PostmetaController(IPostMetaService postMetaService):ControllerBase
    { 
        private readonly IPostMetaService _postmetaService=postMetaService;

        [HttpGet]
        public async Task<Response<List<Postmeta>>> GetPostmetaAsync()
        {
            return await _postmetaService.GetAllPostmetaAsync();
        }

        [HttpGet("{PostmetaId:int}")]
        public async Task<Response<Postmeta>> GePostmetaByIdAsync(int PostmetaId)
        {
            return await _postmetaService.GetPostmetaByIdAsync(PostmetaId);
        }

        [HttpPost]
        public async Task<Response<string>> AddPostmetaAsync(Postmeta Postmeta)
        {
            return await _postmetaService.AddPostmetaAsync(Postmeta);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatePostmetaAsync(Postmeta Postmeta)
        {
            return await _postmetaService.UpdatePostmetaAsync(Postmeta);
        }

        [HttpDelete("{PostmetaId}:int")]
        public async Task<Response<bool>> DeletePostmetaAsync(int PostmetaId)
        {
            return await _postmetaService.DeletePostmetaAsync(PostmetaId);
        }
    }
}
