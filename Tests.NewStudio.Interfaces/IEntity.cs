using System;

namespace Tests.NewStudio.Interfaces
{
    /// <summary>
    /// Абстракция элемента данных, определяемого по ключу
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
