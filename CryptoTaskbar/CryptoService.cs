using System.Collections.Generic;

namespace CryptoTaskbar {
    class CryptoService {
        internal List<Crypto> cryptoList;
        private int currentIndex = 0;
        internal PriceUpdater priceUpdater;
        public Crypto CurrentCrypto;

        public CryptoService() {
            this.cryptoList = new List<Crypto>();
            Crypto eth = new Crypto {
                code = "ETH",
                fiat = "EUR"
            };
            cryptoList.Add(eth);

            Crypto btc = new Crypto {
                code = "BTC",
                fiat = "EUR"
            };
            cryptoList.Add(btc);

            Crypto eth7 = new Crypto {
                code = "ETH",
                fiat = "EUR",
                watchOnly = false,
                quantity = 7f
            };
            cryptoList.Add(eth7);
            this.CurrentCrypto = eth;

            this.priceUpdater = new PriceUpdater(this.cryptoList);
            this.priceUpdater.Update();
        }

        public Crypto SelectNextCrypto() {
            currentIndex++;
            currentIndex = currentIndex == -1 ? 0 : currentIndex % cryptoList.Count;
            CurrentCrypto = cryptoList[currentIndex];
            CurrentCrypto.OnPropertyChanged("Value");
            return CurrentCrypto;
        }

        public Crypto GetCrypto(string code) {
            return cryptoList.Find(c => c.code.Equals(code));
        }
    }
}