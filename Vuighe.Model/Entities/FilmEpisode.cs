using System;

namespace Vuighe.Model.Entities
{
    public class FilmEpisode : BaseEntity
    {
        public Guid FilmId { get; set; }
        public Guid EpisodeId { get; set; }
        public virtual Film Film { get; set; }
        public virtual Episode Episode { get; set; }
    }
}