using System;

namespace CurrencyExchange.DataAccess.Interfaces
{
    public interface IEntityWithDate
    {
        DateTime CreateTime { get; set; }
        DateTime ChangeTime { get; set; }
    }
}