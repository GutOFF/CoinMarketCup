namespace CoinMarketCup.Monad
{
    public class ModelReturn<T>
    {
        public bool IsSuccessfully { get; protected set; }
        public string Error { get; protected set; }
        public T Information { get; protected set; }
    }
}