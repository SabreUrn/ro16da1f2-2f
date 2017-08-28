using System;

namespace QuickRep.WeatherV2
{
    // Denne klasse arver fra SimulatedWeatherInstrumentV2, og
    // bliver således en sub-klasse til SimulatedWeatherInstrumentV2.

    public class CloudCoverMeter : SimulatedWeatherInstrumentV2
    {
        #region Instance fields

        // Dette instance field er specifikt for CloudCoverMeter

        private int _lastValue;

        #endregion

        #region Constructor

        // Når base-klassens constructor kræver parametre, må vi kalde
        // base-klassens constructor eksplicit i sub-klassens constructor.

        public CloudCoverMeter() : base(" of 8", 0, 8) // Kald til base-klasse
        {
            _lastValue = 4;
        }

        #endregion

        #region Properties/metoder

        // Her anvendes en anden algoritme for at finde den nye værdi:
        // Den nye værdi er lig med den gamle værdi +/- 1, og skal være
        // indenfor max. og min. værdier.
        // Modifieren "override" angiver, at vi "udskifter" base-klassens
        // implementation med denne implementation.
        public override int CurrentValue
        {
            get
            {
                int newCurrentValue = _lastValue - 1 + Rng.Next(3);

                if (newCurrentValue > CurrentMaxValue)
                {
                    newCurrentValue = CurrentMaxValue;
                }

                if (newCurrentValue < CurrentMinValue)
                {
                    newCurrentValue = CurrentMinValue;
                }

                _lastValue = newCurrentValue;
                return newCurrentValue;
            }
        } 

        #endregion
    }
}