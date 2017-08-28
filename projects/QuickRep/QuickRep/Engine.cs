namespace QuickRep
{
    public class Engine
    {
        private string _manufacturer;
        private int _horsePower;
        private bool _isRunning;
        private bool _statusOK;

        public Engine(string manufacturer, int horsePower)
        {
            _manufacturer = manufacturer;
            _horsePower = horsePower;
            _isRunning = false;
            _statusOK = true;
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
        }

        public int HorsePower
        {
            get { return _horsePower; }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
        }

        public bool StatusOK
        {
            get { return _statusOK; }
            set { _statusOK = value; }
        }

        public void TurnOn()
        {
            _isRunning = true;
        }
    }
}