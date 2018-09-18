using System;

namespace Vuighe.Model.Entities
{
    public class Comment: BaseEntity
    {
        public string Content { get; set; }
        public Guid ParentId { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual Guid CommentedById { get; set; }
        public virtual Account CommentedBy { get; set; }
    }
}