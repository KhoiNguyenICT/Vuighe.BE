using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vuighe.Model.Entities
{
    public class Tag: BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<FilmTag> FilmTags { get; set; }
        public virtual ICollection<EpisodeTag> EpisodeTags { get; set; }
        public virtual ICollection<CategoryTag> CategoryTags { get; set; }
    }
}