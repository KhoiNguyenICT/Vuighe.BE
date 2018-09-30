using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Api.Controllers
{
    public class ConfigurationController : BaseController
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConfiguration(ConfigurationValue configurationValue)
        {
            await _configurationService.UpdateConfiguration(configurationValue);
            return Ok();
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetConfiguration(string key)
        {
            var result = await _configurationService.GetConfiguration(key);
            return Ok(result);
        }
    }
}