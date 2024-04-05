using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ITagService
    {
        Task<Response<List<Tags>>> GetAllTagsAsync();
        Task<Response<Tags>> GetTagByIdAsync(int id);
        Task<Response<string>> AddTagAsync(Tags tag);
        Task<Response<string>> UpdateTagAsync(Tags tag);
        Task<Response<bool>> DeleteTagAsync(int id);
    }
}
