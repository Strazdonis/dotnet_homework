using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiClient;
using System.Collections.Generic;

namespace UnitTest
{

    public interface ICryptoProvider
    {
        IList<CryptoModel> GetCryptos();
    }

    class CryptoTestProvider : ICryptoProvider
    {
        public IList<CryptoModel> Cryptos;
        public IList<CryptoModel> GetCryptos()
        {
            return Cryptos;
        }
    }

    [TestClass]
    public class CryptoTests
    {
        [TestMethod]
        public void TestCrypto()
        {
            var testProv = new CryptoTestProvider
            {
                Cryptos = new List<CryptoModel>
                {
                    new CryptoModel {
                        asset_id = "BTC",
                        name = "Bitcoin",
                        type_is_crypto = "1",
                        volume_1hrs_usd = "25901365694947.08",
                        volume_1day_usd = "562462310296082.40",
                        volume_1mth_usd = "18198075702757156.02",
                        price_usd = "56128.210565066774379493699776"
                    }
                }
            };

            Assert.AreEqual("BTC", testProv.Cryptos[0].asset_id);
            Assert.AreEqual("Bitcoin", testProv.Cryptos[0].name);
            Assert.AreEqual("1", testProv.Cryptos[0].type_is_crypto);
            Assert.AreEqual("25901365694947.08", testProv.Cryptos[0].volume_1hrs_usd);
            Assert.AreEqual("562462310296082.40", testProv.Cryptos[0].volume_1day_usd);
            Assert.AreEqual("18198075702757156.02", testProv.Cryptos[0].volume_1mth_usd);
            Assert.AreEqual("56128.210565066774379493699776", testProv.Cryptos[0].price_usd);

            Assert.AreEqual(testProv.GetCryptos(), testProv.Cryptos);
        }
    }
}
