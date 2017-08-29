namespace RepetitionExercises {
    // Denne klasse modellerer en højttaler, der kan tændes og slukkes,
    // og hvor man kan skrue op og ned for lysstyrken.
    public class Speaker : HomeTheaterDevice {
        private const int MinVolume = 0;
        private const int MaxVolume = 100;

        private int _currentVolume;

        public Speaker() : base() {
            _currentVolume = 0;
        }

        public int CurrentVolume {
            get { return _currentVolume; }
        }

        // Skru op for lydstyrken, med mindre vi har nået
        // den maksimale lydstyrke
        public void IncreaseVolume() {
            if (_currentVolume < MaxVolume && IsOn) {
                _currentVolume++;
            }
        }

        // Skru op for lydstyrken, med mindre vi har nået
        // den minimale lydstyrke
        public void DecreaseVolume() {
            if (_currentVolume > MinVolume && IsOn) {
                _currentVolume--;
            }
        }
    }
}