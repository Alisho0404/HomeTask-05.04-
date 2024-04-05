using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPostMetaService
    {
        Task<Response<List<Postmeta>>> GetAllPostmetaAsync();
        Task<Response<Postmeta>> GetPostmetaByIdAsync(int id);
        Task<Response<string>> AddPostmetaAsync(Postmeta postmeta);
        Task<Response<string>> UpdatePostmetaAsync(Postmeta postmeta);
        Task<Response<bool>> DeletePostmetaAsync(int id);
    }
}
