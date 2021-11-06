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
        private static readonly string API_KEY = "B6C55CAC-E186-4FA1-B877-AA9C85A5D1BF"; //rate limitted on first one, lol
        private static readonly string BASE_URL = "http://rest.coinapi.io";
        private static readonly string ASSETS_URL = "/v1/assets";
        private static readonly string HISTORY_URL = "/v1/exchangerate/{asset_id_base}/USD/history";
        public static IList<CryptoModel> FetchCryptos()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = client.GetStringAsync(BASE_URL + ASSETS_URL + "?apikey=" + API_KEY).Result;

                var list = JsonConvert.DeserializeObject<List<CryptoModel>>(response);
                return list;
            }
        }

        public static CryptoModel FetchSingleCrypto(string asset_id)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = client.GetStringAsync(BASE_URL + ASSETS_URL + "/" + asset_id + "?apikey=" + API_KEY).Result;

                var list = JsonConvert.DeserializeObject<List<CryptoModel>>(response);
                return list.First();
            }
        }

        public static IList<HistoryModel> FetchCryptoHistory(string asset_id)
        {
            using (HttpClient client = new HttpClient())
            {
                //TODO: get current time in ISO 8601 format and calculate time_start based on it.
                string response = client.GetStringAsync(BASE_URL + HISTORY_URL.Replace("{asset_id_base}", asset_id) + "?apikey=" + API_KEY + "&time_start=2020-11-06T22:36:28.7440000Z&time_end=2021-11-06T22:36:28.7440000Z&period_id=7DAY").Result;

                var list = JsonConvert.DeserializeObject<List<HistoryModel>>(response);
                return list;
            }
        }
    }
}