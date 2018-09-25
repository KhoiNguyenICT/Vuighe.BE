using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var result = await _collectionService.Queryable().OrderBy(x => x.CreatedDate).Select(x => new Collection
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();
            return Ok(result);
        }
    }
}