using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tests.NewStudio.Models
{
    [Table("CurrencyRateProviders")]
    public class CurrencyRateProvider : DataEntity
    {
        [Required]
        [MaxLength(11)]
        [Column("Code")]
        public string Code { get; set; }
        [Column("Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
