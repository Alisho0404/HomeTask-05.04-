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
    public class PostCategoryService : IPostCategoryService
    {
        private readonly DapperContext _context;
        public PostCategoryService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddPostCategoryAsync(PostCategory postCategory)
        {
            try
            {
                var sql = $"insert into postCtaegory(postid,categoryId)" +
                    $"values({postCategory.PostId},{postCategory.CategoryId})";
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

        public async Task<Response<bool>> DeletePostCategoryAsync(int id)
        {
            try
            {
                var sql = $"Delete from postCtaegory where id ={@id}";
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

        public async Task<Response<List<PostCategory>>> GetAllPostCategoryAsync()
        {
            try
            {
                var sql = "Select * from postCtaegory";
                var result = await _context.Connection().QueryAsync<PostCategory>(sql);
                return new Response<List<PostCategory>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<PostCategory>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<PostCategory>> GetPostCategoryByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from postCtaegory where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<PostCategory>(result);
                }
                return new Response<PostCategory>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<PostCategory>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdatePostCategoryAsync(PostCategory postCategory)
        {
            try
            {
                var sql = $"update postCtaegory set postid={postCategory.PostId},categoryId={postCategory.CategoryId} " +
                    $"where id={postCategory.Id}";
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
