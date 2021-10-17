namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт хранилища курсов
    /// </summary>
    public interface ICurrencyRateStorage
    {
        /// <summary>
        /// Добавить курс
        /// </summary>
        /// <param name="currencyRate"></param>
        void Add(ICurrencyRate currencyRate);

        /// <summary>
        /// Проверить наличие курса в хранилище
        /// </summary>
        bool Contains(ICurrencyRate currencyRate);

        /// <summary>
        /// Удалить курс
        /// </summary>
        /// <param name="currencyRate"></param>
        void Delete(ICurrencyRate currencyRate);

        /// <summary>
        /// Найти курсс указанными параметрами
        /// </summary>
        /// <param name="rateParameters"></param>
        decimal Find(ICurrencyRate rateParameters);
    }
}
