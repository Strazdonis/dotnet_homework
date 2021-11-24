using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiClient;
using System.Collections.Generic;

namespace UnitTest
{


    public interface IIconsProvider
    {
        IList<IconModel> GetIcons();
    }

    class IconTestProvider : IIconsProvider
    {
        public IList<IconModel> Icons;
        public IList<IconModel> GetIcons()
        {
            return Icons;
        }
    }

    [TestClass]
    public class IconTests
    {
        [TestMethod]
        public void TestIcon()
        {
            var testProv = new IconTestProvider
            {
                Icons = new List<IconModel>
                {
                    new IconModel {
                        asset_id = "BTC",
                        url = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/4caf2b16a0174e26a3482cea69c34cba.png",
                    }
                }
            };

            Assert.AreEqual("BTC", testProv.Icons[0].asset_id);
            Assert.AreEqual("https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/4caf2b16a0174e26a3482cea69c34cba.png", testProv.Icons[0].url);

            Assert.AreEqual(testProv.GetIcons(), testProv.Icons);
        }
    }
}
