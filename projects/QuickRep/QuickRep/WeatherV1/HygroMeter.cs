namespace QuickRep.WeatherV1
{
    public class HygroMeter : SimulatedWeatherInstrumentV1
    {
        public HygroMeter() : base("% humidity", 0, 100)
        {
            CurrentMinValue = 20;
            CurrentMaxValue = 80;
        }

        public int CurrentHumidity
        {
            get { return CurrentValue; }
        }
    }
}