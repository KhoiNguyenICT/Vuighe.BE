using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class CollectionService: BaseService<Collection>, ICollectionService
    {
        public CollectionService(AppDbContext context) : base(context)
        {
        }
    }
}