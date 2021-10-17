namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Контракт валюты
    /// </summary>
    public interface ICurrency
    {
        /// <summary>
        /// Символьный код валюты по ISO4217
        /// </summary>
        string CharCodeISO4217 { get; }

        /// <summary>
        /// Числовой код валюты по ISO4217
        /// </summary>
        int NumCodeISO4217 { get; }

        /// <summary>
        /// Метод, возвращающий уникальный ИД валюты - на усмотрение имплементатора
        /// </summary>
        /// <returns></returns>
        object GetKey();
    }
}
