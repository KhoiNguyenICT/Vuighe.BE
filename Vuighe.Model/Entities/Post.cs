using System;
using System.Collections.Generic;

namespace Vuighe.Model.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Guid? ThumbnailId { get; set; }
        public Asset Thumbnail { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}