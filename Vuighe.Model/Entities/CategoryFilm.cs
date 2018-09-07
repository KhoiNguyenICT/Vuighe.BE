using System;

namespace Vuighe.Model.Entities
{
    public class CategoryFilm: BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid FilmId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}