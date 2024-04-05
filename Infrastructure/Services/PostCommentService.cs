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
    public class PostCommentService : IPostCommentService
    {
        private readonly DapperContext _context;
        public PostCommentService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddPostCommentsAsync(PostComments postComments)
        {
            try
            {
                var sql = $"insert into PostComments(postid,title,published)" +
                    $"values({postComments.PostId},'{postComments.Title}','{postComments.Published}')";
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

        public async Task<Response<bool>> DeletePostCommentsAsync(int id)
        {
            try
            {
                var sql = $"Delete from PostComments where id ={@id}";
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

        public async Task<Response<List<PostComments>>> GetAllPostCommentsAsync()
        {
            try
            {
                var sql = "Select * from PostComments";
                var result = await _context.Connection().QueryAsync<PostComments>(sql);
                return new Response<List<PostComments>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<PostComments>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<PostComments>> GetPostCommentsByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from PostComments where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<PostComments>(result);
                }
                return new Response<PostComments>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<PostComments>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdatePostCommentsAsync(PostComments postComments)
        {
            try
            {
                var sql = $"update PostComments set postid=,title='{postComments.Title}',published='{postComments.Published}' " +
                    $"where id={postComments.Id}";
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
