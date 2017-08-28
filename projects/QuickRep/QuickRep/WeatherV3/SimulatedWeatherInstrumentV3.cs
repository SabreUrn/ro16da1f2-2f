using System;

namespace QuickRep.WeatherV3
{
    public class SimulatedWeatherInstrumentV3 : IWeatherInstrument
    {
        #region Instance fields

        private string _unitOfMeasurement;
        private int _absoluteMinValue;
        private int _absoluteMaxValue;
        private int _currentMinValue;
        private int _currentMaxValue;

        // Vi tillader sub-klasser adgang til dette instance field, ikke andre!
        protected Random Rng;

        #endregion

        #region Constructor

        public SimulatedWeatherInstrumentV3(string unitOfMeasurement, int absoluteMinValue, int absoluteMaxValue)
        {
            _unitOfMeasurement = unitOfMeasurement;

            _absoluteMinValue = absoluteMinValue;
            _absoluteMaxValue = absoluteMaxValue;

            Reset();

            Rng = new Random();
        }

        #endregion

        #region Non-virtual properties

        public string UnitOfMeasurement
        {
            get { return _unitOfMeasurement; }
        }

        public int AbsoluteMinValue
        {
            get { return _absoluteMinValue; }
        }

        public int AbsoluteMaxValue
        {
            get { return _absoluteMaxValue; }
        }

        public int CurrentMinValue
        {
            get { return _currentMinValue; }
            set { _currentMinValue = value; }
        }

        public int CurrentMaxValue
        {
            get { return _currentMaxValue; }
            set { _currentMaxValue = value; }
        }

        #endregion

        #region Virtual properties

        // Når vi angiver modifieren "virtual" på en property/metode,
        // KAN en sub-klasse vælge at "udskifte" base-klassens 
        // implementation med sin egen implementation. 

        public virtual int CurrentValue
        {
            get
            {
                return CurrentMinValue + Rng.Next(CurrentMaxValue - CurrentMinValue + 1);
            }
        }

        #endregion

        #region Metoder

        public void Reset()
        {
            _currentMinValue = _absoluteMinValue;
            _currentMaxValue = _absoluteMaxValue;
        }

        #endregion
    }
}