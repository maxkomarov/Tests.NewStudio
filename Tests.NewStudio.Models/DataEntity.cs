using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tests.NewStudio.Models
{
    public abstract class DataEntity
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }
    }
}
