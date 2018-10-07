using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vuighe.Common;
using Vuighe.Common.Errors;
using Vuighe.Model.Entities;
using Vuighe.Model.Utils;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Query(int skip = 0, int take = 10, string query = null)
        {
            var queryable = _tagService.Queryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                queryable = queryable.MatchSearchQuery(query);
            }

            var list = new QueryResult<Tag>
            {
                Items = await queryable
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip(skip).Take(take)
                    .Select(x => new Tag()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    }).ToListAsync(),
                Count = await queryable.CountAsync()
            };
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            await _tagService.Add(tag);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tagService.Remove(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _tagService.Get(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Tag tag)
        {
            await _tagService.Update(tag);
            return Ok();
        }
    }
}