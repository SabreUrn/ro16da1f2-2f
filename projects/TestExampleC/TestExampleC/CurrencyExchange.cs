using System;
using System.Collections.Generic;

namespace TestExampleC {
    public class CurrencyExchange {
        #region Instance fields
        List<string> _currencies;
        List<string> _currencyCrosses;
        Dictionary<string, float> _exchangeRates;
        #endregion

        #region Constructor
        public CurrencyExchange(List<string> currencies) {
            _currencies = currencies;
            _currencyCrosses = new List<string>();
            _exchangeRates = new Dictionary<string, float>();

            InitCrosses();
        }
        #endregion

        #region Properties
        List<string> Currencies {
            get { return _currencies; }
        }

        List<string> CurrencyCrosses {
            get { return _currencyCrosses; }
        }

        Dictionary<string, float> ExchangeRates {
            get { return _exchangeRates; }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Inserts a new currency cross into the _currencyCrosses list.
        /// </summary>
        /// <param name="currencyCross">An existing cross
        /// of two currencies in the format AAABBB.</param>
        private void CurrencyCrossesInsert(string currencyCross) {
            //throw exception if currencyCross is empty, whitespace,
            //or otherwise not 6 characters (shouldn't be possible)
            if (String.IsNullOrWhiteSpace(currencyCross) || currencyCross.Length != 6) {
                throw new ArgumentException("Currency cross must be exactly six characters.");
            }

            _currencyCrosses.Add(currencyCross);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Fills the _currencyCrosses list by calling CurrencyCrossesInsert with all
        /// possible combinations (not permutations) of currencies in the Currencies list.
        /// </summary>
        public void InitCrosses() {
            //throw exception if Currencies (_currencies) is null or empty
            if (Currencies == null || Currencies.Count == 0) {
                throw new ArgumentException("Currencies list does not exist or is empty.");
            }

            //combine currency acronyms into currency crosses
            for (int i = 0; i < Currencies.Count - 1; i++) {
                for (int j = i + 1; j < Currencies.Count; j++) {
                    CurrencyCrossesInsert(Currencies[i] + Currencies[j]);
                }
            }
        }

        /// <summary>
        /// Adds a new exchange rate to the ExchangeRate dictionary(string, float) if the
        /// specified currencyCross is not already present in ExchangeRate or edits an entry
        /// in the ExchangeRate dictionary if the specified currencyCross already exists.
        /// </summary>
        /// <param name="currencyCross">An existing cross
        /// of two currencies in the format AAABBB.</param>
        /// <param name="rate">A positive decimal number for the exchange rate.</param>
        public void SpecifyExchangeRate(string currencyCross, float rate) {
            //throw exception if currencyCross is empty,
            //whitespace, or otherwise not 6 characters
            if (String.IsNullOrWhiteSpace(currencyCross) || currencyCross.Length != 6) {
                throw new ArgumentException("Currency cross must be exactly six characters.");
            }

            //throw exception if currencyCross does not match an entry in CurrencyCrosses
            if (!CurrencyCrosses.Contains(currencyCross)) {
                throw new ArgumentException("Currency cross does not exist.");
            }

            //throw exception if rate is not positive
            if (rate <= 0) {
                throw new ArgumentException("Exchange rate must be positive");
            }

            //check if currency cross already exist as an exchange rate
            //if it does, edit existing exchange rate
            //it it doesn't, add as new exchange rate(currencyCross, rate)
            if (ExchangeRates.ContainsKey(currencyCross)) {
                ExchangeRates[currencyCross] = rate;
            } else {
                ExchangeRates.Add(currencyCross, rate);
            }
        }
        #endregion
    }
}