using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiClient
{
    public static class Fetch
    {
        //private static readonly string API_KEY = "85F6DEE6-6926-4D6E-8DFF-8EF355B8722C";
        private static readonly string API_KEY = "B6C55CAC-E186-4FA1-B877-AA9C85A5D1BF"; //rate limitted on first one
        private static readonly string BASE_URL = "http://rest.coinapi.io";
        private static readonly string ASSETS_URL = "/v1/assets";
        private static readonly string HISTORY_URL = "/v1/exchangerate/{asset_id_base}/USD/history";
        private static readonly string ICON_URL = "/v1/assets/icons/";
        private static HttpClient client = new HttpClient();
        public static IList<CryptoModel> FetchCryptos()
        {
            string response = client.GetStringAsync(BASE_URL + ASSETS_URL + "?apikey=" + API_KEY).Result;

            var list = JsonConvert.DeserializeObject<List<CryptoModel>>(response);
            return list;
        }

        public static CryptoModel FetchSingleCrypto(string asset_id)
        {
            string response = client.GetStringAsync(BASE_URL + ASSETS_URL + "/" + asset_id + "?apikey=" + API_KEY).Result;

            var list = JsonConvert.DeserializeObject<List<CryptoModel>>(response);
            return list.First();
        }

        public static IList<HistoryModel> FetchCryptoHistory(string asset_id, string period)
        {
            DateTime now = DateTime.UtcNow;
            int days = int.Parse(period.Remove(period.Length - 3, 3)); // only number part of period
            string fromDate = now.AddDays(-100 * days).ToString("o", System.Globalization.CultureInfo.InvariantCulture);


            string url = BASE_URL + HISTORY_URL.Replace("{asset_id_base}", asset_id) + "?apikey=" + API_KEY + "&time_start=" + fromDate + "&period_id=" + period;
            string response = client.GetStringAsync(url).Result;
            var list = JsonConvert.DeserializeObject<List<HistoryModel>>(response);
            return list;
        }

        public static IEnumerable<IconModel> FetchIcons(int size)
        {
            string url = BASE_URL + ICON_URL + size + "?apikey=" + API_KEY;
            string response = client.GetStringAsync(url).Result;
            var list = JsonConvert.DeserializeObject<IEnumerable<IconModel>>(response);
            return list;
        }
    }
}