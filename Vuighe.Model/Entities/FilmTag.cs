using System;

namespace Vuighe.Model.Entities
{
    public class FilmTag: BaseEntity
    {
        public Guid FilmId { get; set; }
        public Guid TagId { get; set; }
        public virtual Film Film { get; set; }
        public virtual Tag Tag { get; set; }
    }
}