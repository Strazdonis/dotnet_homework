using Homework;
using ApiClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CacheTest
    {
        Cache cache = new Cache();
        [TestMethod]
        public void TestMethod1()
        {
            HistoryModel FakeHistory = new HistoryModel()
            {
                rate_open = "90",
                rate_close = "100",
                rate_low = "90",
                rate_high = "100",
                time_open = "2021-12-09T00:00:00.0000000Z",
                time_close = "2021-12-14T23:46:00.0000000Z",
                time_period_start = "2021-12-09T00:00:00.0000000Z",
                time_period_end = "2021-12-16T00:00:00.0000000Z"
            };
            IList<HistoryModel> FakeHistoryList = new List<HistoryModel>() { FakeHistory};

            cache.AddToCache("TEST", "7DAY", FakeHistoryList);

            Assert.AreEqual(1, cache.memory_cache.Count);

            IList<HistoryModel> CachedHistoryList = cache.FetchCryptoHistory("TEST", "7DAY");
            Assert.AreEqual(1, cache.memory_cache.Count); // nothing got added

            Assert.AreEqual(FakeHistoryList, CachedHistoryList); // cached value and received value matches
        }
    }
}
