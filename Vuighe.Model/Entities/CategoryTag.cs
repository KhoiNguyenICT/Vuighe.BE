using System;

namespace Vuighe.Model.Entities
{
    public class CategoryTag: BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid TagId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Tag Tag { get; set; }
    }
}