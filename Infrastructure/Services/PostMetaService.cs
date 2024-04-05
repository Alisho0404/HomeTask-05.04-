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
    public class PostMetaService : IPostMetaService
    {
        private readonly DapperContext _context;
        public PostMetaService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddPostmetaAsync(Postmeta postmeta)
        {
            try
            {
                var sql = $"insert into postmeta(postid,key,content)" +
                    $"values({postmeta.PostId},'{postmeta.Key}','{postmeta.Content}')";
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

        public async Task<Response<bool>> DeletePostmetaAsync(int id)
        {
            try
            {
                var sql = $"Delete from postmeta where id ={@id}";
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

        public async Task<Response<List<Postmeta>>> GetAllPostmetaAsync()
        {
            try
            {
                var sql = "Select * from postmeta";
                var result = await _context.Connection().QueryAsync<Postmeta>(sql);
                return new Response<List<Postmeta>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Postmeta>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<Postmeta>> GetPostmetaByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from postmeta where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Postmeta>(result);
                }
                return new Response<Postmeta>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Postmeta>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdatePostmetaAsync(Postmeta postmeta)
        {
            try
            {
                var sql = $"Update postmeta set postid={postmeta.PostId},key='{postmeta.Key}',content='{postmeta.Content}' " +
                    $"where id={postmeta.Id}";
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
