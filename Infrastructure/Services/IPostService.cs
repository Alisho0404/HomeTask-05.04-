using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPostService
    {
        Task<Response<List<Post>>> GetAllPostAsync();
        Task<Response<Post>> GetPostByIdAsync(int id);
        Task<Response<string>> AddPostAsync(Post post);
        Task<Response<string>> UpdatePostAsync(Post post);
        Task<Response<bool>> DeletePostAsync(int id);
    }
}
