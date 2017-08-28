using System;

namespace QuickRep.WeatherV3
{
    public abstract class RealWeatherInstrumentV3 : IWeatherInstrument
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

        public RealWeatherInstrumentV3(string unitOfMeasurement, int absoluteMinValue, int absoluteMaxValue)
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

        #region Abstract properties

        // Når vi angiver modifieren "abstract" på en property/metode,
        // SKAL en sub-klasse definere sin egen implementation. 

        public abstract int CurrentValue { get; }

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