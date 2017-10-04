using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExampleC;
using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace UnitTestProject {
    [TestClass]
    public class CurrencyExchangeTest {

        #region Constructor
        [TestMethod]
        public void TestCurrencyExchange_Constructor_CurrenciesEmpty_Exception() {
            //arrange
            List<string> currencies = new List<string>();

            //act, assert
            Assert.ThrowsException<ArgumentException>(() => { CurrencyExchange exchange = new CurrencyExchange(currencies); });
        }

        [TestMethod]
        public void TestCurrencyExchange_Constructor_CurrenciesNull_Exception() {
            //arrange
            List<string> currencies = null;

            //act, assert
            Assert.ThrowsException<ArgumentException>(() => { CurrencyExchange exchange = new CurrencyExchange(currencies); });
        }

        [TestMethod]
        public void TestCurrencyExchange_Constructor_CurrenciesInvalidLength_Exception() {
            //arrange
            List<string> currencies = new List<string>();
            currencies.Add("AAA");
            currencies.Add("BBB");
            currencies.Add("CCCC");
            currencies.Add("DDD");

            //act, assert
            Assert.ThrowsException<ArgumentException>(() => { CurrencyExchange exchange = new CurrencyExchange(currencies); });
        }
        #endregion

        #region Properties
        [TestMethod]
        public void TestCurrencyExchange_Currencies_GetOnce() {
            //arrange
            CurrencyExchange exchange = new CurrencyExchange(new List<string> { "AAA", "BBB", "CCC" });
            List<string> expectedResult = new List<string> { "AAA", "BBB", "CCC" };

            //act
            List<string> actualResult = exchange.Currencies;

            //assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCurrencyExchange_CurrencyCrosses_GetOnce() {
            //arrange
            CurrencyExchange exchange = new CurrencyExchange(new List<string> { "AAA", "BBB", "CCC" });
            List<string> expectedResult = new List<string> { "AAABBB", "AAACCC", "BBBCCC" };

            //act
            List<string> actualResult = exchange.CurrencyCrosses;

            //assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCurrencyExchange_ExchangeRates_GetOnce() {
            //arrange
            CurrencyExchange exchange = new CurrencyExchange(new List<string> { "AAA", "BBB", "CCC" });
            Dictionary<string, double> expectedResult = new Dictionary<string, double>();
            expectedResult.Add("AAABBB", 6.50);
            expectedResult.Add("AAACCC", 0.50);

            //act
            exchange.SpecifyExchangeRate("AAABBB", 6.50);
            exchange.SpecifyExchangeRate("AAACCC", 0.50);
            Dictionary<string, double> actualResult = exchange.ExchangeRates;

            //assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region Methods
        [TestMethod]
        public void TestCurrencyExchange_ExchangeRateCurrencyCrossEmpty_Exception() {
            //arrange
            CurrencyExchange exchange = new CurrencyExchange(new List<string> { "AAA", "BBB", "CCC" });
            
            //act, assert
            Assert.ThrowsException<ArgumentException>(() => exchange.SpecifyExchangeRate("", 6.50));
        }

        [TestMethod]
        public void TestCurrencyExchange_ExchangeRateCurrencyCrossDoesNotExist_Exception() {
            //arrange
            CurrencyExchange exchange = new CurrencyExchange(new List<string> { "AAA", "BBB", "CCC" });

            //act, assert
            Assert.ThrowsException<ArgumentException>(() => exchange.SpecifyExchangeRate("AAADDD", 3.45));
        }

        [TestMethod]
        public void TestCurrencyExchange_ExchangeRateNegativeRate_Exception() {
            //arrange
            CurrencyExchange exchange = new CurrencyExchange(new List<string> { "AAA", "BBB", "CCC" });

            //act, assert
            Assert.ThrowsException<ArgumentException>(() => exchange.SpecifyExchangeRate("AAABBB", -5.50));
        }
        #endregion
    }
}
