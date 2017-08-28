using System.Collections.Generic;

namespace QuickRep.WeatherV2
{
    // Mere generel implementation af en vejstation. 
    // Ikke længere reference til specifikke instrumenter.
    // Ingen begrænsning af antal instrumenter

    public class WeatherStationV2
    {
        #region Instance fields

        private string _location;
        private List<SimulatedWeatherInstrumentV2> _instruments;

        #endregion

        #region Constructor

        public WeatherStationV2(string location, List<SimulatedWeatherInstrumentV2> instruments = null)
        {
            _location = location;
            _instruments = instruments ?? new List<SimulatedWeatherInstrumentV2>(); // Neat, huh...
        }

        #endregion

        #region Properties

        public string Location
        {
            get { return _location; }
        }

        #endregion

        #region Metoder

        public void Reset()
        {
            foreach (SimulatedWeatherInstrumentV2 instrument in _instruments)
            {
                instrument.Reset();
            }
        }

        public void AddInstrument(SimulatedWeatherInstrumentV2 instrument)
        {
            _instruments.Add(instrument);
        }

        // Bemærk at vi her definerer vores WeatherStationV2-specifikke
        // version af ToString (oprindeligt defineret i Object-klassen,
        // som alle klasser arver fra).

        public override string ToString()
        {
            string report = "Current weather at " + Location + "\n";
            report += "--------------------------------------\n";

            foreach (SimulatedWeatherInstrumentV2 instrument in _instruments)
            {
                report += instrument.CurrentValue + " " + instrument.UnitOfMeasurement + "\n";
            }

            return report;
        } 

        #endregion
    }

    // Problem(?): Listen er af typen List<SimulatedWeatherInstrumentV2>,
    // så vi kan kun komme simulerede instrumenter ind i listen. 
}