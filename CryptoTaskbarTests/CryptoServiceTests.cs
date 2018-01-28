using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CryptoTaskbar.Tests {
    [TestClass()]
    public class CryptoServiceTests {
        CryptoService cryptoService;
        [TestInitialize]
        public void SetUp() {
            cryptoService = new CryptoService();
            List<Crypto> list = new List<Crypto>();
            Crypto eth = new Crypto {
                code = "ETH",
                fiat = "EUR"
            };
            list.Add(eth);

            Crypto btc = new Crypto {
                code = "BTC",
                fiat = "EUR"
            };
            list.Add(btc);

            Crypto eth7 = new Crypto {
                code = "ETH",
                fiat = "EUR",
                watchOnly = false,
                quantity = 7f
            };
            list.Add(eth7);
            cryptoService.cryptoList = list;
        }
        [TestMethod()]
        public void UpdatesAddedCoin() {
            Crypto eth = cryptoService.GetCrypto("ETH");

            Assert.IsNotNull(eth);
            Assert.AreEqual("EUR", eth.fiat);
            Assert.IsNotNull(eth.Value);
            Assert.AreNotEqual("", eth.Value);
        }

        [TestMethod()]
        public void SelectsNextCryptoInList() {
            Assert.IsNotNull(cryptoService.CurrentCrypto);
            Assert.AreEqual("ETH", cryptoService.CurrentCrypto.code);

            cryptoService.SelectNextCrypto();

            Assert.IsNotNull(cryptoService.CurrentCrypto);
            Assert.AreEqual("BTC", cryptoService.CurrentCrypto.code);

            cryptoService.SelectNextCrypto();

            Assert.IsNotNull(cryptoService.CurrentCrypto);
            Assert.AreEqual("ETH", cryptoService.CurrentCrypto.code);
            Assert.AreEqual(7f, cryptoService.CurrentCrypto.quantity);

            cryptoService.SelectNextCrypto(); // goes back to the first coin

            Assert.IsNotNull(cryptoService.CurrentCrypto);
            Assert.AreEqual("ETH", cryptoService.CurrentCrypto.code);
        }
    }
}