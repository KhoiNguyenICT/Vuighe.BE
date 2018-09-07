using System.Threading.Tasks;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}