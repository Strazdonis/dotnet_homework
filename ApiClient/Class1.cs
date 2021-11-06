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
        private static readonly string API_KEY = "85F6DEE6-6926-4D6E-8DFF-8EF355B8722C";
        private static readonly string BASE_URL = "http://rest.coinapi.io";
        private static readonly string ASSETS_URL = "/v1/assets";

        public static IList<CryptoModel> FetchCryptos()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = client.GetStringAsync(BASE_URL + ASSETS_URL + "?apikey=" + API_KEY).Result;

                var list = JsonConvert.DeserializeObject<List<CryptoModel>>(response);
                return list;
            }
        }
    }
}