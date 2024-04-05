using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;
        public UserService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddUserAsync(User user)
        {
            try
            {
                var sql = $"insert into users(firstname,lastname,phone,email)" +
                    $"values('{user.FirstName}','{user.LastName}','{user.Phone}','{user.Email}')";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Succesfully created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeletUseryAsync(int id)
        {
            try
            {
                var sql = $"Delete from users where id ={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<List<User>>> GetAllUsersAsync()
        {
            try
            {
                var sql = "Select * from users";
                var result = await _context.Connection().QueryAsync<User>(sql);
                return new Response<List<User>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<User>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<User>> GetUserByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from users where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<User>(result);
                }
                return new Response<User>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<User>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateUserAsync(User user)
        {
            try
            {
                var sql = $"update users set firstname='{user.FirstName}',lastname='{user.LastName}',phone='{user.Phone}'," +
                    $"email='{user.Email}' where id={user.Id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Succesfully updated");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }
    }
}
