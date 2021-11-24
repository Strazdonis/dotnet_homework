using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiClient;
using System.Collections.Generic;

namespace UnitTest
{


    public interface IHistoryProvider
    {
        IList<HistoryModel> GetHistory();
    }

    class HistoryTestProvider : IHistoryProvider
    {
        public IList<HistoryModel> History;
        public IList<HistoryModel> GetHistory()
        {
            return History;
        }
    }

    [TestClass]
    public class HistoryTests
    {
        [TestMethod]
        public void TestHistory()
        {

            var testProv = new HistoryTestProvider
            {
                History = new List<HistoryModel>
                {
                    new HistoryModel {
                        time_period_start = "2021-11-04T00:00:00.0000000Z",
                        time_period_end = "2021-11-11T00:00:00.0000000Z",
                        time_open = "2021-11-04T00:01:00.0000000Z",
                        time_close = "2021-11-06T22:36:00.0000000Z",
                        rate_open = "62947.46674573254",
                        rate_high = "63113.76594975721",
                        rate_low = "60136.677362254806",
                        rate_close = "61301.7827063516"
                    }
                }
            };

            Assert.AreEqual("2021-11-04T00:00:00.0000000Z", testProv.History[0].time_period_start);
            Assert.AreEqual("2021-11-11T00:00:00.0000000Z", testProv.History[0].time_period_end);
            Assert.AreEqual("2021-11-04T00:01:00.0000000Z", testProv.History[0].time_open);
            Assert.AreEqual("2021-11-06T22:36:00.0000000Z", testProv.History[0].time_close);
            Assert.AreEqual("62947.46674573254", testProv.History[0].rate_open);
            Assert.AreEqual("63113.76594975721", testProv.History[0].rate_high);
            Assert.AreEqual("60136.677362254806", testProv.History[0].rate_low);
            Assert.AreEqual("61301.7827063516", testProv.History[0].rate_close);

            Assert.AreEqual(testProv.GetHistory(), testProv.History);
        }
    }
}
