using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IDKEY = System.Guid;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ability.Core.Models
{
    public class BaseRecord : IEntity
    {
        [Key, Unique]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public IDKEY Id { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Дата изменения")]
        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
