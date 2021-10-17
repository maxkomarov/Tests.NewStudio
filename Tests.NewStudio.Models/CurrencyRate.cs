using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tests.NewStudio.Models
{
    [Table("CurrencyRates")]
    public class CurrencyRate : DataEntity
    {
        [ForeignKey("")]
        public Guid From { get; set; }
        public Guid To { get; set; }
        public decimal Limit { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public DateTime Dated { get; set; }
        public Guid CurrencyRateProvider { get; set; }
    }
}
