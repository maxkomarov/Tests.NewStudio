namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт валюты по ISO 4217 (частичный)
    /// </summary>
    public interface ICurrency
    {
        /// <summary>
        /// Символьный код валюты (3 знака)
        /// </summary>
        string StringCode { get; set; }
        /// <summary>
        /// Числовой код валюты (]0:999])
        /// </summary>
        ushort NumericCode { get; set; }
        /// <summary>
        /// Разменная единица [0:N]
        /// </summary>
        ushort DecimalSeparator { get; set; } 
        /// <summary>
        /// Официальное название
        /// </summary>
        string Name { get; set; }
    }
}
