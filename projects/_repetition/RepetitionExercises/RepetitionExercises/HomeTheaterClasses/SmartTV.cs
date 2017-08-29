using System;

namespace RepetitionExercises {
    // Denne klasse modellerer et (meget simpelt) Smart TV,
    // der kan tændes og slukkes, og hvor man kan skifte kanal.
    public class SmartTV : IHomeTheaterDevice {
        private const int MinChannel = 1;
        private const int MaxChannel = 100;

        private bool _isOn;
        private int _channel;

        public SmartTV() {
            _channel = 0;
        }
        
        // Skift kanal, med mindre den nye værdi er
        // ulovlig, jf. min- og max-værdier for kanal.
        public int Channel {
            get { return _channel; }
            set {
                if (value >= MinChannel && value <= MaxChannel && IsOn) {
                    _channel = value;
                }
            }
        }

        public bool IsOn {
            get { return _isOn; }
        }

        public void ToggleOnOff() {
            _isOn = !_isOn;

            if (_isOn) {
                _channel = 1;
            } else {
                _channel = 0;
            }
        }
    }
}