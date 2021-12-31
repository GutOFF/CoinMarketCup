using Entity;
using Microsoft.EntityFrameworkCore;

namespace TestCoinMarketCup
{
    public class TestBase
    {
        protected ApplicationDbContext Context { get; set; }

        public TestBase()
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
    }
}
