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
    public class PostService : IPostService
    {
        private readonly DapperContext _context;
        public PostService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddPostAsync(Post post)
        {
            try
            {
                var sql = $"insert into posts(authorid,title,published)" +
                    $"values({post.AuthorId},'{post.Title}','{post.Published}')";
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

        public async Task<Response<bool>> DeletePostAsync(int id)
        {
            try
            {
                var sql = $"Delete from posts where id ={@id}";
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

        public async Task<Response<List<Post>>> GetAllPostAsync()
        {
            try
            {
                var sql = "Select * from posts";
                var result = await _context.Connection().QueryAsync<Post>(sql);
                return new Response<List<Post>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Post>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<Post>> GetPostByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from  posts where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Post>(result);
                }
                return new Response<Post>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Post>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdatePostAsync(Post post)
        {
            try
            {
                var sql = $"update posts set authorid={post.AuthorId},title='{post.Title}',published='{post.Published}'" +
                    $" where id={post.Id}";
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
