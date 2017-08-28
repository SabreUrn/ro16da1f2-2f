using System;

namespace QuickRep.WeatherV1
{
    // Denne klasse kommer til at være base-klasse for et antal mere
    // specifikke klasser, men det fremgår ikke af klassen selv.

    public class SimulatedWeatherInstrumentV1
    {
        #region Instance fields

        private string _unitOfMeasurement;
        private int _absoluteMinValue;
        private int _absoluteMaxValue;
        private int _currentMinValue;
        private int _currentMaxValue;
        private Random _rng;

        #endregion

        #region Constructor

        public SimulatedWeatherInstrumentV1(string unitOfMeasurement, int absoluteMinValue, int absoluteMaxValue)
        {
            _unitOfMeasurement = unitOfMeasurement;

            _absoluteMinValue = absoluteMinValue;
            _absoluteMaxValue = absoluteMaxValue;

            Reset();

            _rng = new Random();
        }

        #endregion

        #region Properties

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

        public int CurrentValue
        {
            get
            {
                return CurrentMinValue + _rng.Next(CurrentMaxValue - CurrentMinValue + 1);
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