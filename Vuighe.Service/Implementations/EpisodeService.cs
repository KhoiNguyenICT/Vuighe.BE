using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class EpisodeService: BaseService<Episode>, IEpisodeService
    {
        public EpisodeService(AppDbContext context) : base(context)
        {
        }
    }
}