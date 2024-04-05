using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        Task<Response<List<User>>> GetAllUsersAsync();
        Task<Response<User>> GetUserByIdAsync(int id);
        Task<Response<string>> AddUserAsync(User user);
        Task<Response<string>> UpdateUserAsync(User user);
        Task<Response<bool>> DeletUseryAsync(int id);
    }
}
