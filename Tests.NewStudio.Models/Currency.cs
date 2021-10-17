using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tests.NewStudio.Models
{
    [Table("Currencies")]
    public class Currency : DataEntity
    {

        [Column("StringCode"), MaxLength(3)]
        [Required]
        public string StringCode { get; set; }
        [Key]
        [Column("NumericCode")]
        [Required]
        public ushort NumericCode { get; set; }
        [Column("DecimalSeparator")]
        [Required]
        public ushort DecimalSeparator { get; set; }
        [Column("Name"), MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
