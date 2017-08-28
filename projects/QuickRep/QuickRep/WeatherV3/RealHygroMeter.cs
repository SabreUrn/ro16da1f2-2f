namespace QuickRep.WeatherV3
{
    public class RealHygroMeter : RealWeatherInstrumentV3
    {
        public RealHygroMeter() : base("% humidity", 0, 100)
        {
        }

        // RealHygroMeter SKAL definere en implementation af
        // denne property, da den er abstract i base-klassen
        public override int CurrentValue
        {
            get { return CurrentMinValue + Rng.Next(CurrentMaxValue - CurrentMinValue + 1); }
        }
    }
}