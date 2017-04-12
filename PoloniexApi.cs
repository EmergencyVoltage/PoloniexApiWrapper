using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Poloniex
{
    class Wrapper
    {

        public HttpClient client;
        
        public Wrapper(){
            this.client = new HttpClient();
        }

        public async void returnTicker()
        {
            // https://poloniex.com/public?command=returnTicker
            string url = "https://poloniex.com/public?command=returnTicker";

            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            try
            {
                var cl = new HttpClient();
                var page = await cl.GetStringAsync(url);
                Dictionary<string, Ticker> dataset;
                dataset = JsonConvert.DeserializeObject<Dictionary<string, Ticker>>(page);
                Console.WriteLine(dataset.Values);
                foreach (string key in dataset.Keys)
                {
                    Console.Write(key);
                    Console.Write('-');
                    Console.WriteLine(dataset[key].lowestAsk);
                }
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                Console.Write('.');
            }

        }

        
    }

    class Ticker{
         public int id;
         public double last;
         public double lowestAsk;
         public double highestBid;
         public double percentChange;
         public double baseVolume;
         public double quoteVolume;
         public int isFrozen;
         public double high24hr;
         public double low24hr;
    }

}