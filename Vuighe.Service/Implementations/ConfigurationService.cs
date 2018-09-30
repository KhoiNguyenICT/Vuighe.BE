using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class ConfigurationService: IConfigurationService
    {
        private AppDbContext _context;

        public ConfigurationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task UpdateConfiguration(ConfigurationValue configurationValue)
        {
            var result = _context.ConfigurationValues.FirstOrDefault(x => x.Key == configurationValue.Key);
            if (result != null)
            {
                result.Value = configurationValue.Value;
            }
            else
            {
                _context.ConfigurationValues.Add(configurationValue);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ConfigurationValue> GetConfiguration(string key)
        {
            var result = await _context.ConfigurationValues.FirstOrDefaultAsync(x => x.Key == key);
            return result;
        }
    }
}