namespace CurrencyExchange.Domains.Interfaces
{
    public interface ICountSkipModel
    {
        int Count { get; set; }
        int Skip { get; set; }
    }
}