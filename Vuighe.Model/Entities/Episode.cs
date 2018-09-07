﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vuighe.Model.Entities
{
    public class Episode: BaseEntity
    {
        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string VideoSource { get; set; }
        public int LikeCount { get; set; }
        public int FollowCount { get; set; }
        public int ViewCount { get; set; }
        public string Thumbnail { get; set; }

        public virtual ICollection<FilmEpisode> FilmEpisodes { get; set; }
        public virtual ICollection<EpisodeTag> EpisodeTags { get; set; }
    }
}