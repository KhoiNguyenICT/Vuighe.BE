using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Vuighe.Api.Extensions;
using Vuighe.Common.Constants;
using Vuighe.Common.Errors;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class AssetController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAssetService _assetService;
        private readonly ICollectionService _collectionService;
        private readonly IConfiguration _configuration;

        public AssetController(
            IHostingEnvironment hostingEnvironment,
            IAssetService assetService,
            ICollectionService collectionService, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _assetService = assetService;
            _collectionService = collectionService;
            _configuration = configuration;
        }

        [HttpPost("upload/{collectionId}"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFile(IFormFile file, Guid collectionId)
        {
            try
            {
                var now = DateTime.Now;
                if (file == null)
                {
                    throw new CustomException("You can include your image");
                }
                else
                {
                    var fileContent = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName
                        .Trim('"').Split(".");
                    var fileName = fileContent[0] + "-" + Guid.NewGuid() + "." + fileContent[1];
                    var contentType = file.ContentType.Replace("/", "\\");
                    var imageFolder = $@"\uploads\" + contentType + $@"\{now:yyyyMMdd}";
                    var folder = _hostingEnvironment.WebRootPath + imageFolder;

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string filePath = Path.Combine(folder, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    var asset = file.To<Asset>();
                    asset.FileName = fileName;
                    asset.FilePath = imageFolder.Replace(@"\", "/") + "/" + fileName;
                    asset.CollectionId = collectionId;
                    await _assetService.Add(asset);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("collection/{collectionId}")]
        public IActionResult GetAssets(Guid collectionId, int skip)
        {
            var queryable = _collectionService.Queryable();
            var result = queryable.Include(x => x.Assets)
                .FirstOrDefault(x => x.Id == collectionId)?.Assets.Select(x => new Asset
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    FilePath = _configuration[ConfigurationKeys.WebHostUrl] + x.FilePath
                }).ToList();
            return Ok(result);
        }
    }
}