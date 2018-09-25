using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class AssetService : BaseService<Asset>, IAssetService
    {
        public AssetService(AppDbContext context) : base(context)
        {
        }
    }
}