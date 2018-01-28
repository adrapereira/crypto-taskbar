using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Timers;

namespace CryptoTaskbar {
    class PriceUpdater {
        private List<Crypto> cryptoList;

        private Timer timer;

        public PriceUpdater(List<Crypto> cryptoList) {
            this.cryptoList = cryptoList;
            this.timer = new Timer(60000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
            GC.KeepAlive(timer);
        }

        public void Update() {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            // Build Request
            List<String> coinCodes = new List<string>();
            HashSet<String> fiatCodes = new HashSet<string>();
            foreach (Crypto coin in cryptoList) {
                coinCodes.Add(coin.code);
                fiatCodes.Add(coin.fiat);
            }
            String coins = String.Join(",", coinCodes);
            String fiats = String.Join(",", fiatCodes);
            String url = String.Format("https://min-api.cryptocompare.com/data/pricemulti?fsyms={0}&tsyms={1}&e=Coinbase", coins, fiats);

            // Make Request
            var response = client.DownloadString(url);

            // Update Coin Prices
            var prices = JObject.Parse(response);
            foreach (Crypto coin in cryptoList) {
                var coinPrices = prices.GetValue(coin.code);
                coin.Value = coinPrices.SelectToken(coin.fiat).Value<String>();
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e) {
            Update();
        }



    }
}
