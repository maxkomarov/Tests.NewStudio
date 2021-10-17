namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт денежной суммы в некоей валюте
    /// </summary>
    public interface IMoneySum
    {
        /// <summary>
        /// Сумма
        /// </summary>
        decimal Value { get; set; }
        /// <summary>
        /// Валюта суммы
        /// </summary>
        string Currency { get; set; }
    }
}
