using System;
using System.ComponentModel.DataAnnotations;

namespace Vuighe.Model.Entities
{
    public class ConfigurationValue
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}