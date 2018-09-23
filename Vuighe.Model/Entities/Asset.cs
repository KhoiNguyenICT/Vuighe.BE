using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Vuighe.Common.Attributes;

namespace Vuighe.Model.Entities
{
    public class Asset: BaseEntity
    {
        [Required]
        public string FileName { get; set; }

        [StringLength(50)]
        public string FileExtension { get; set; }

        public long FileSize { get; set; }

        [Required]
        public string FilePath { get; set; }

        [NotMapped]
        [ResolveUrl]
        public string FileUrl => Path.GetFileName(FilePath);

        public Guid CollectionId { get; set; }

        public virtual Collection Collection { get; set; }
    }
}