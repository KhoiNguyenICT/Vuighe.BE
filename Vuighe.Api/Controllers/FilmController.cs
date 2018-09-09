using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vuighe.Common;
using Vuighe.Model.Entities;
using Vuighe.Model.Utils;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> Query(int skip = 0, int take = 10, string query = null)
        {
            var queryable = _filmService.Queryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                queryable = queryable.MatchSearchQuery(query);
            }

            var list = new QueryResult<Film>
            {
                Items = await queryable
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip(skip).Take(take)
                    .Select(x => new Film()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        LikeCount = x.LikeCount,
                        FollowCount = x.FollowCount,
                        ViewCount = x.ViewCount,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    }).ToListAsync(),
                Count = await queryable.CountAsync()
            };
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            await _filmService.Add(film);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _filmService.Remove(id);
            return Ok();
        }
    }
}