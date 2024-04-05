using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPostCommentService
    {
        Task<Response<List<PostComments>>> GetAllPostCommentsAsync();
        Task<Response<PostComments>> GetPostCommentsByIdAsync(int id);
        Task<Response<string>> AddPostCommentsAsync(PostComments postComments);
        Task<Response<string>> UpdatePostCommentsAsync(PostComments postComments);
        Task<Response<bool>> DeletePostCommentsAsync(int id);
    }
}
