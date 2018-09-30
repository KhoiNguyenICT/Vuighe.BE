using System.Threading.Tasks;
using Vuighe.Model.Entities;

namespace Vuighe.Service.Interfaces
{
    public interface IConfigurationService
    {
        Task UpdateConfiguration(ConfigurationValue configurationValue);

        Task<ConfigurationValue> GetConfiguration(string key);
    }
}