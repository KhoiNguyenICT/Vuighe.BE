using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vuighe.Model.Entities
{
    public class Category: BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset Thumbnail { get; set; }
        public virtual ICollection<CategoryTag> CategoryTags { get; set; }
        public virtual ICollection<CategoryFilm> CategoryFilms { get; set; }
    }
}