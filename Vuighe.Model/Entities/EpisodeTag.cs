using System;

namespace Vuighe.Model.Entities
{
    public class EpisodeTag: BaseEntity
    {
        public Guid EpisodeId { get; set; }
        public Guid TagId { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual Tag Tag { get; set; }
    }
}