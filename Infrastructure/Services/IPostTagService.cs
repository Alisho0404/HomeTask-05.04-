using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPostTagService
    {
        Task<Response<List<Posttag>>> GetAllPosttagAsync();
        Task<Response<Posttag>> GetPosttagByIdAsync(int id);
        Task<Response<string>> AddPosttagAsync(Posttag posttag);
        Task<Response<string>> UpdatePosttagAsync(Posttag posttag);
        Task<Response<bool>> DeletePosttagAsync(int id);
    }
}
