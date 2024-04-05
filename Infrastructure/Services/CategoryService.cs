using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _context;
        public CategoryService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddCategoryAsync(Category category)
        {
            try
            {
                var sql = $"insert into category(title,slug,content)" +
                    $"values('{category.Title}','{category.Slug}','{category.Content}')"; 
                var result=await _context.Connection().ExecuteAsync(sql);
                if (result>0)
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

        public async Task<Response<bool>> DeleteCategoryAsync(int id)
        {
            try
            {
                var sql = $"Delete from category where id ={@id}";
                var result = await _context.Connection().ExecuteAsync(sql); 
                if (result>0)
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

        public async Task<Response<List<Category>>> GetAllCategoriesAsync()
        {
            try
            {
                var sql = "Select * from category";
                var result = await _context.Connection().QueryAsync<Category>(sql);
                return new Response<List<Category>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message); 
                return new Response<List<Category>>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<Category>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from category where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result!=null)
                {
                    return new Response<Category>(result);
                }
                return new Response<Category>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Category>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateCategoryAsync(Category category)
        {
            try
            {
                var sql = $"update category set title='{category.Title}',slug='{category.Slug}',content='{category.Content}' " +
                    $"where id={category.Id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result>0)
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
