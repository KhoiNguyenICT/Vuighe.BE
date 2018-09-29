using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Vuighe.Model.Entities
{
    public class Collection: BaseEntity
    {
        [StringLength(500)]
        public string Title { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }

        [NotMapped]
        public int TotalAsset { get; set; }
    }
}