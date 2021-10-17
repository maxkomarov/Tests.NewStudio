namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт провайдера обменного курса
    /// </summary>
    public interface ICurrencyRateProvider
    {
        /// <summary>
        /// Идентификатор провайдера обменного курса, например, IBAN или SWIFT-BIC -код 
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// Название провайдера обменного курса
        /// </summary>
        string Name { get; set; }
    }
}
