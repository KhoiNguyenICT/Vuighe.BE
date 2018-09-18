using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vuighe.Common;
using Vuighe.Common.Errors;
using Vuighe.Model.Entities;
using Vuighe.Model.Utils;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryFilmService _categoryFilmService;
        private readonly IFilmService _filmService;

        public CategoryController(ICategoryService categoryService, ICategoryFilmService categoryFilmService, IFilmService filmService)
        {
            _categoryService = categoryService;
            _categoryFilmService = categoryFilmService;
            _filmService = filmService;
        }

        [HttpPost]
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
                Items = await queryable
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip(skip).Take(take)
                    .Select(x => new Category()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    }).ToListAsync(),
                Count = await queryable.CountAsync()
            };
            return Ok(list);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Remove(id);
            return Ok();
        }

        [HttpPost("getByCategoryIds")]
        public async Task<IActionResult> GetByCategoryIds([FromBody]List<Guid> ids)
        {
            var result = await _categoryService.Queryable().Where(x => ids.Contains(x.Id))
                .Select(x => new Category()
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("getCategoriesByFilm/{filmId}")]
        public async Task<IActionResult> GetCategoriesByFilm(Guid filmId, int skip = 0, int take = 10, string query = null)
        {
            var queryable = _filmService.Queryable();
            var categoryIds = queryable.Include(x => x.CategoryFilms).FirstOrDefault(x => x.Id == filmId)?.CategoryFilms.Select(x => x.CategoryId);
            var categories = _categoryService.Queryable(x => categoryIds.Contains(x.Id));
            if (!string.IsNullOrWhiteSpace(query))
            {
                categories = categories.MatchSearchQuery(query);
            }
            var list = new QueryResult<Category>
            {
                Items = await categories
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip(skip).Take(take)
                    .Select(x => new Category()
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync(),
                Count = await categories.CountAsync()
            };
            return Ok(list);
        }

        [HttpDelete("{categoryId}/removeCategoryOfFilm/{filmId}")]
        public async Task<IActionResult> RemoveCategoryOfFilm(Guid categoryId, Guid filmId)
        {
            var category = _categoryFilmService.Queryable().FirstOrDefault(x => x.CategoryId == categoryId && x.FilmId == filmId);
            if (category != null)
            {
                await _categoryFilmService.Remove(category.Id);
            }
            else
            {
                throw new CustomException("System can't find category");
            }

            return Ok();
        }
    }
}