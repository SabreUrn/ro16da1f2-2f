namespace QuickRep.WeatherV1
{
    public class ThermoMeter : SimulatedWeatherInstrumentV1
    {
        public ThermoMeter() : base("C", -100, 60)
        {
            CurrentMinValue = -40;
            CurrentMaxValue = 40;
        }

        public int CurrentTemperature
        {
            get { return CurrentValue; }
        }      
    }
}