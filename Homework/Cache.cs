using System;
using System.Collections.Generic;
using ApiClient;

namespace Homework
{
    public class Cache
    {
        /* 
        {
            "BTC": {
                "1Day": IList<HistoryModel>,
                "3Day": IList<HistoryModel>,
                "5Day": IList<HistoryModel>,
                ...
            },
            "ETH": {
                ...
            },
            ...
        }
        */
        public Dictionary<string, Dictionary<string, IList<HistoryModel>>> memory_cache = new Dictionary<string, Dictionary<string, IList<HistoryModel>>>();


        public IList<HistoryModel> FetchCryptoHistory(string asset_id, string period)
        {
            if(memory_cache.ContainsKey(asset_id) && memory_cache[asset_id].ContainsKey(period))
            {
                Console.WriteLine("Got period from cache.");
                return memory_cache[asset_id][period];
            }
            IList<HistoryModel> response = Fetch.FetchCryptoHistory(asset_id, period);
            AddToCache(asset_id, period, response);
            return response;
        }

        public void AddToCache(string asset_id, string period, IList<HistoryModel> data)
        {
            if(!memory_cache.ContainsKey(asset_id))
            {
                memory_cache[asset_id] = new Dictionary<string, IList<HistoryModel>>();
            }
           
            memory_cache[asset_id][period] = data;
            Console.WriteLine("Cached period.");
        }

    }
}
