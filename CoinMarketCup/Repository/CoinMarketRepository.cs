using Entity;
using Entity.Model;

namespace CoinMarketCup.Repository
{
    public class CoinMarketRepository : RepositoryBase<Cryptocurrency>
    {
        public CoinMarketRepository(ApplicationDbContext context) : base(context)
        {
            
        }


    }
}
