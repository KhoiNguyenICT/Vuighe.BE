using System;
using System.ComponentModel.DataAnnotations;

namespace Vuighe.Model.Entities
{
    public class Asset : BaseEntity
    {
        [Required]
        public string FileName { get; set; }

        [StringLength(50)]
        public string FileExtension { get; set; }

        public long FileSize { get; set; }

        [Required]
        public string FilePath { get; set; }

        public Guid CollectionId { get; set; }

        public virtual Collection Collection { get; set; }
    }
}