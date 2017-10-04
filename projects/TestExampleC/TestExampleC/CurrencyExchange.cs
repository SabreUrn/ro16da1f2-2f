using System;
using System.Collections.Generic;

namespace TestExampleC {
    public class CurrencyExchange {
        #region Instance fields
        List<string> _currencies;
        List<string> _currencyCrosses;
        Dictionary<string, double> _exchangeRates;
        #endregion

        #region Constructor
        public CurrencyExchange(List<string> currencies) {
            _currencyCrosses = new List<string>();
            _exchangeRates = new Dictionary<string, double>();

            //throw exception on currencies being null or empty
            if(currencies == null || currencies.Count == 0) {
                throw new ArgumentException("Currencies list must not be empty.");
            }
            //throw exception on a currency inside list not being 3 characters
            foreach(string currency in currencies) {
                if(currency.Length != 3) {
                    throw new ArgumentException("All currency abbreviations must be exactly 3 characters.");
                }
            }
            _currencies = currencies;


            InitCrosses();
        }
        #endregion

        #region Properties
        public List<string> Currencies {
            get { return _currencies; }
        }

        public List<string> CurrencyCrosses {
            get { return _currencyCrosses; }
        }

        public Dictionary<string, double> ExchangeRates {
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
        public void SpecifyExchangeRate(string currencyCross, double rate) {
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

        //calculate exchanged rate
        public void CalculateExchangedRate(string currencyCross, string currency, int amount) {
            //TODO: throw exception if currencyCross is empty,
            //whitespace, or otherwise not 6 characters

            //TODO: throw exception if currencyCross does not match an entry in CurrencyCrosses

            //TODO: throw exception if currency does not match an entry in Currencies

            //TODO: throw exception if there is no exchange rate for currencyCross

            //TODO: throw exception if amount is not positive

            //assuming everything goes right...
            //take the exchange rate from ExchangeRates
            //IF:
            //they want the first currency in the currency cross of an exchange rate,
            //THEN:
            //amount *= rate; return amount
            //ELSE:
            //reverseExchangeRate = 1 / exchange rate; amount *= rate; return amount
        }
        #endregion
    }
}