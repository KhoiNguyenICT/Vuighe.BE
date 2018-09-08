using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Vuighe.Common;
using Vuighe.Model.Entities;
using Vuighe.Model.Utils;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Category entity)
        {
            await _categoryService.Add(entity);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Query(int skip = 0, int take = 10, string query = null)
        {
            var queryable = _categoryService.Queryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                queryable = queryable.MatchSearchQuery(query);
            }

            var list = new QueryResult<Category>
            {
                Items = await queryable.Skip(skip).Take(take)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new Category()
                    {
                        Title = x.Title,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    }).ToListAsync(),
                Count = await queryable.CountAsync()
            };
            return Ok(list);
        }
    }
}