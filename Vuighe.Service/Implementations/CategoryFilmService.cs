using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class CategoryFilmService: BaseService<CategoryFilm>, ICategoryFilmService
    {
        public CategoryFilmService(AppDbContext context) : base(context)
        {
        }
    }
}