namespace RepetitionExercises {
    // Denne klasse modellerer en (meget simpel) Blu-Ray afspiller,
    // der kan tændes og slukkes, og hvor en afspilning kan startes
    // og stoppes
    public class BluRayPlayer : HomeTheaterDevice {
        private bool _isPlaying;

        public BluRayPlayer() : base() {
            _isPlaying = false;
        }

        public bool IsPlaying {
            get { return _isPlaying; }
        }

        // Start afspilning. Kan kun foretages, hvis
        // afspilleren er tændt.
        public void Play() {
            if (IsOn) {
                _isPlaying = true;
            }
        }

        // Stop afspilning.
        public void Stop() {
            _isPlaying = false;
        }
    }
}