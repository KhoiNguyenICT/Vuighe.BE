using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vuighe.Common.Errors;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class CollectionController : BaseController
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetCollections()
        {
            var queryable = _collectionService.Queryable();
            var result = await queryable
                .Include(x=>x.Assets)
                .OrderBy(x => x.CreatedDate)
                .Select(x => new Collection
            {
                Id = x.Id,
                Title = x.Title,
                TotalAsset = x.Assets.Count()
            }).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(Collection collection)
        {
            var result = _collectionService.Queryable().FirstOrDefault(x => x.Title == collection.Title);
            if (result != null)
            {
                throw new CustomException("Collection existed");
            }
            await _collectionService.Add(collection);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(Guid id)
        {
            await _collectionService.Remove(id);
            return Ok();
        }
    }
}