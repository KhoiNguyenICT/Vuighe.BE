using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vuighe.Model.Entities
{
    public class Film: BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public int FollowCount { get; set; }
        public int ViewCount { get; set; }
        public Asset Thumbnail { get; set; }

        public virtual ICollection<CategoryFilm> CategoryFilms { get; set; }
        public virtual ICollection<FilmEpisode> FilmEpisodes { get; set; }
        public virtual ICollection<FilmTag> FilmTags { get; set; }
    }
}