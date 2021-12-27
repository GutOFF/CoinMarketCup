namespace CoinMarketCup.Monad
{
    public sealed class Return<T> : ModelReturn<T>
    {
        public static Return<T> ReturnSuccessfully(T information)
        {
            return new Return<T>
            {
                IsSuccessfully = true,
                Information = information
            };
        }
        public static Return<T> ReturnFail(string error)
        {
            return new Return<T>
            {
                Error = error,
                IsSuccessfully = false
            };
        }
    }
}
