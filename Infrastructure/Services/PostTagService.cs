using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

namespace Infrastructure.Services
{
    public class PostTagService : IPostTagService
    {
        private readonly DapperContext _context;
        public PostTagService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddPosttagAsync(Posttag posttag)
        {
            try
            {
                var sql = $"insert into posttag(postid,tagid)" +
                    $"values({posttag.PostId},{posttag.TagId})";
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

        public async Task<Response<bool>> DeletePosttagAsync(int id)
        {
            try
            {
                var sql = $"Delete from posttag where id ={@id}";
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

        public async Task<Response<List<Posttag>>> GetAllPosttagAsync()
        {
            try
            {
                var sql = "Select * from  posttag";
                var result = await _context.Connection().QueryAsync<Posttag>(sql);
                return new Response<List<Posttag>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Posttag>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<Posttag>> GetPosttagByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from  posttag where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Posttag>(result);
                }
                return new Response<Posttag>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Posttag>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdatePosttagAsync(Posttag posttag)
        {
            try
            {
                var sql = $"update posttag set postid={posttag.PostId},tagid={posttag.TagId} where id={posttag.Id}";
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
