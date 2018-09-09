using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Implementations
{
    public class FilmService: BaseService<Film>, IFilmService
    {
        public FilmService(AppDbContext context) : base(context)
        {
        }
    }
}