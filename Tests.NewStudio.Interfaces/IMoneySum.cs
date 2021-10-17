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
        decimal Amount { get; set; }
        /// <summary>
        /// Валюта суммы
        /// </summary>
        ICurrency Currency { get; set; }
    }
}
