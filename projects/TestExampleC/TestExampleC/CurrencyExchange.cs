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
        /// Fills the _currencyCrosses list by calling CurrencyCrossesInsert with all
        /// possible combinations (not permutations) of currencies in the Currencies list.
        /// </summary>
        private void InitCrosses() {
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
        /// Adds a new exchange rate to the ExchangeRate dictionary(string, float) if the
        /// specified currencyCross is not already present in ExchangeRate or edits an entry
        /// in the ExchangeRate dictionary if the specified currencyCross already exists.
        /// </summary>
        /// <param name="currencyCross">An existing cross
        /// of two currencies in the format AAABBB.</param>
        /// <param name="rate">A positive decimal number for the exchange rate.</param>
        public void SpecifyExchangeRate(string currencyCross, double rate) {
            #region SpecifyExchangeRate sanity
            //throw exception if currencyCross is empty,
            //whitespace, or otherwise not 6 characters
            //TODO: move to ExchangeRates property
            if (String.IsNullOrWhiteSpace(currencyCross) || currencyCross.Length != 6) {
                throw new ArgumentException("Currency cross must be exactly six characters.");
            }

            //throw exception if currencyCross does not match an entry in CurrencyCrosses
            if (!CurrencyCrosses.Contains(currencyCross)) {
                throw new ArgumentException("Given currency cross does not exist.");
            }

            //throw exception if rate is not positive
            if (rate <= 0) {
                throw new ArgumentException("Exchange rate must be positive");
            }
            #endregion

            //check if currency cross already exist as an exchange rate
            //if it does, edit existing exchange rate
            //it it doesn't, add as new exchange rate(currencyCross, rate)
            string reverseRate = currencyCross.Substring(3) + currencyCross.Substring(0, 3);
            if (ExchangeRates.ContainsKey(currencyCross)) {
                ExchangeRates[currencyCross] = rate;
            } else if (ExchangeRates.ContainsKey(reverseRate)) {
                ExchangeRates[currencyCross] = 1 / rate;
            }  else {
                ExchangeRates.Add(currencyCross, rate);
            }

            //go through ExchangeRates
            //if any entry has a cross matching one of our currencyCross but not the other,
            //also add an ExchangeRates entry for these two
            bool crossFound = false;
            string newCross = "";
            foreach(string cross in ExchangeRates.Keys) {
                if(cross.Substring(0, 3) == currencyCross.Substring(0, 3)) {    //AAAbbb, AAAccc
                    newCross = cross.Substring(3) + currencyCross.Substring(3); //aaaBBB, aaaCCC
                    crossFound = true;                                          //BBBCCC
                } else if(cross.Substring(0, 3) == currencyCross.Substring(3)) {    //AAAbbb, cccAAA
                    newCross = cross.Substring(3) + currencyCross.Substring(0, 3);  //aaaBBB, CCCaaa
                    crossFound = true;                                              //BBBCCC
                } else if(cross.Substring(3) == currencyCross.Substring(0, 3)) {    //bbbAAA, AAAccc
                    newCross = cross.Substring(0, 3) + currencyCross.Substring(3);  //BBBaaa, aaaCCC
                    crossFound = true;                                              //BBBCCC
                } else if(cross.Substring(3) == currencyCross.Substring(3)) {           //bbbAAA, cccAAA
                    newCross = cross.Substring(0, 3) + currencyCross.Substring(0, 3);   //BBBaaa, CCCaaa
                    crossFound = true;                                                  //BBBCCC
                }

                string reverseRate2 = "";
                if (!String.IsNullOrEmpty(newCross)) reverseRate2 = newCross.Substring(3) + newCross.Substring(0, 3);
                if (crossFound && !ExchangeRates.ContainsKey(newCross) && ExchangeRates.ContainsKey(reverseRate2)) {
                    ExchangeRates.Add(newCross, ExchangeRates[cross] / rate);
                    crossFound = false;
                }
            }
        }

        //calculate exchanged rate
        public double CalculateExchangedRate(string currencyCross, string currency, double amount) {
            #region CalculateExchangedRate sanity
            //throw exception if currencyCross is empty,
            //whitespace, or otherwise not 6 characters
            if(String.IsNullOrWhiteSpace(currencyCross) || currency.Length != 6) {
                throw new ArgumentException("Currency cross must be exactly six characters.");
            }

            //throw exception if currencyCross does not match an entry in CurrencyCrosses
            if(!CurrencyCrosses.Contains(currencyCross)) {
                throw new ArgumentException("Given currency cross does not exist.");
            }

            //throw exception if currency does not match an entry in Currencies
            if(!Currencies.Contains(currency)) {
                throw new ArgumentException("Given currency does not exist.");
            }

            //throw exception if there is no exchange rate for currencyCross
            if(!ExchangeRates.ContainsKey(currencyCross)) {
                throw new ArgumentException("Given currency cross does not have a specified exchange rate.");
            }

            //throw exception if amount is not positive
            if(amount <= 0) {
                throw new ArgumentException("Amount must be positive.");
            }
            #endregion

            double rate = ExchangeRates[currencyCross];
            if(currencyCross.Substring(0, 3) == currency) { //if they want the first currency of the cross currency (AAA from AAABBB),
                amount *= rate;                             //multiply amount by rate
                return amount;                              //and return amount
            } else {                                        //ELSE
                double reverseRate = 1 / rate;              //reverse the rate (if 1 AAA = 6.50 BBB, 1 BBB = 1 / 6.50 = 0.15 AAA),
                amount *= reverseRate;                      //multiply amount by reversed rate,
                return amount;                              //and return amount
            }
        }
        #endregion
    }
}