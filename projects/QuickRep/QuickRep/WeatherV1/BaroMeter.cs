namespace QuickRep.WeatherV1
{
    // Vi kan også modellere en kompleks entitet 
    // ved brug af nedarvning. 
    //
    // Specielt relevant hvis vi modellerer klasser, 
    // som har et "er-en" (is-a) relation
    //
    // Elementer som er fælles for flere - mere 
    // specialiserede - klasser defineres i en base-klasse, 
    // som en mere specialiseret klasse (sub-klassen) 
    // kan arve fra.

    // Her er SimulatedWeatherInstrumentV1 base-klassen,
    // mens BaroMeter er sub-klassen
    public class BaroMeter : SimulatedWeatherInstrumentV1
    {
        public BaroMeter() : base("mmHg", 900, 1100)
        {
            CurrentMinValue = 990;
            CurrentMaxValue = 1030;
        }

        public int CurrentAirPressure
        {
            get { return CurrentValue; }
        }
    }
}