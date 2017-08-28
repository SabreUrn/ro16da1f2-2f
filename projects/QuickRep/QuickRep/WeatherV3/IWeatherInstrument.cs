namespace QuickRep.WeatherV3
{
    public interface IWeatherInstrument
    {
        string UnitOfMeasurement { get; }
        int AbsoluteMinValue { get; }
        int AbsoluteMaxValue { get; }
        int CurrentMinValue { get; set; }
        int CurrentMaxValue { get; set; }
        int CurrentValue { get; }
        void Reset();
    }
}