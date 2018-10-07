﻿using System;

namespace Vuighe.Model.Entities
{
    public class PostTag : BaseEntity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}