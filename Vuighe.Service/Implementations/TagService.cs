using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class TagService: BaseService<Tag>, ITagService
    {
        public TagService(AppDbContext context) : base(context)
        {
        }
    }
}