using CoinMarketCup.API;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using CoinMarketCup.Repository;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoinMarketCup.CoinMarketCupTest
{
    class TestCallApiCoinMarketCup : TestBase
    {
        private readonly string API_KEY = "10c2408c-f3fd-4c1e-801e-b97ba3bba899";

        [Test]
        public async Task TestGetMetadataOnApi()
        {
            // arrange
            Mock<SettingCryptocurrencyRepository> settingMock = new Mock<SettingCryptocurrencyRepository>(Context);

            int errorCode = 0;

            settingMock.Setup(w => w.GetApiKey())
                .ReturnsAsync(API_KEY);
            int id = 1;

            var callCoinMarketCup = new CallCoinMarketCup(settingMock.Object);

            // act
            var result = await callCoinMarketCup
                .GetCryptoCurrencyMetadata(id.ToString());

            //assert
            Assert.AreEqual(errorCode, result.Status.ErrorCode);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(MetadataRequest), result);
            Assert.AreEqual(id,result.Data.Values.FirstOrDefault().Id);
        }

        [Test]
        public async Task TestGetListingLatestOnApi()
        {
            // arrange
            Mock<SettingCryptocurrencyRepository> settingMock = new Mock<SettingCryptocurrencyRepository>(Context);
        
            int errorCode = 0;
            
            settingMock.Setup(w => w.GetLimit())
               .ReturnsAsync(1);
            settingMock.Setup(w => w.GetApiKey())
                .ReturnsAsync(API_KEY);
            
            var callCallCoinMarketCup = new CallCoinMarketCup(settingMock.Object);
            
            //act
            var result = await callCallCoinMarketCup.GetCryptoCurrencyListing();

            //assert
            Assert.AreEqual(errorCode, result.Status.ErrorCode);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(ListingLatestRequest), result);
        }
    }
}
