using System;

namespace QuickRep.WeatherV1
{
    // Når vi prøver at modellere mere komplekse entiteter, vil vi 
    // ofte definere nye klasser ved hjælp af andre klasser.
    ///
    // Association: Objekter rummer referencer til andre objekter.
    // Varianter:
    //   Aggregation: A refererer til B, men B kan godt "leve" udenfor A.
    //   Composition: A skaber og refererer til B. 
    //                Ingen andre kan referere til B.
    //
    // Klasserne har en "har-en" (has-a) relation; 
    // en vejrstation har-et termometer, osv..

    public class WeatherStationV1
    {
        #region Instance fields

        private string _location;       // Simplel type
        private ThermoMeter _thermo;    // Klasse-type
        private HygroMeter _hygro;      // Klasse-type
        private BaroMeter _baro;        // Klasse-type 

        #endregion

        #region Constructor

        public WeatherStationV1(string location)
        {
            _location = location;

            // I dette tilfælde laver WeatherStationV1 selv
            // instanser af de objekter, den skal referere til.
            // D.v.s. der er tale om Composition.

            _thermo = new ThermoMeter();
            _hygro = new HygroMeter();
            _baro = new BaroMeter();
        }

        #endregion

        #region Properties/metoder

        public string Location
        {
            get { return _location; }
        }


        // Nogle properties/metoder vil nu benytte properties/metoder 
        // fra de objekter, objektet selv refererer til.

        public void Reset()
        {
            _thermo.Reset();
            _hygro.Reset();
            _baro.Reset();
        }

        public void PrintReport()
        {
            Console.WriteLine("Current weather at " + Location);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(_thermo.CurrentTemperature + " " + _thermo.UnitOfMeasurement);
            Console.WriteLine(_hygro.CurrentHumidity + " " + _hygro.UnitOfMeasurement);
            Console.WriteLine(_baro.CurrentAirPressure + " " + _baro.UnitOfMeasurement);
        } 

        #endregion
    }

    // Problem(?): Der refereres eksplicit til tre specifikke
    // instrumenter, ikke særligt fleksibelt.
}