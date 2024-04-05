using Dapper;
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

namespace Infrastructure.Services
{
    public class TagService : ITagService
    {
        private readonly DapperContext _context;
        public TagService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddTagAsync(Tags tag)
        {
            try
            {
                var sql = $"insert into tags(title,slug)" +
                    $"values('{tag.Title}','{tag.Slug}')";
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

        public async Task<Response<bool>> DeleteTagAsync(int id)
        {
            try
            {
                var sql = $"Delete from tags where id ={@id}";
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

        public async Task<Response<List<Tags>>> GetAllTagsAsync()
        {
            try
            {
                var sql = "Select * from tags";
                var result = await _context.Connection().QueryAsync<Tags>(sql);
                return new Response<List<Tags>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Tags>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<Tags>> GetTagByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from tags where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Tags>(result);
                }
                return new Response<Tags>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Tags>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateTagAsync(Tags tag)
        {
            try
            {
                var sql = $"update tags set title='{tag.Title}',slug='{tag.Slug}' where id= {tag.Id}";
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
