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
    public class EpisodeController : BaseController
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet]
        public async Task<IActionResult> Query(int skip = 0, int take = 10, string query = null)
        {
            var queryable = _episodeService.Queryable();

            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.MatchSearchQuery(query);
            }

            var list = new QueryResult<Episode>
            {
                Items = await queryable
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip(skip).Take(take)
                    .Select(x => new Episode()
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
        public async Task<IActionResult> Create(Episode episode)
        {
            await _episodeService.Add(episode);
            return Ok();
        }
    }
}