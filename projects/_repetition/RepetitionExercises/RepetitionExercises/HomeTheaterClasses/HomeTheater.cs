namespace RepetitionExercises {
    // Denne klasse definerer et Home Theater (HT) system. 
    // Dette er defineret som bestående af: 
    // Et TV, en Blu-Ray afspiller samt to højttalere.
    public class HomeTheater {
        private SmartTV smartTV;
        private BluRayPlayer bluRay;
        private Speaker speakerLeft;
        private Speaker speakerRight;

        public HomeTheater() {
            smartTV = new SmartTV();
            bluRay = new BluRayPlayer();
            speakerLeft = new Speaker();
            speakerRight = new Speaker();
        }

        // Skift mellem tændt og slukket tilstand for systemet.
        // Dette gøres ved at udføre denne operation på alle
        // devices i systemet.
        public void ToggleOnOff() {
            smartTV.ToggleOnOff();
            bluRay.ToggleOnOff();
            speakerLeft.ToggleOnOff();
            speakerRight.ToggleOnOff();
        }

        // Skru op for lydstyrken i begge højttalere.
        public void IncreaseVolume() {
            speakerLeft.IncreaseVolume();
            speakerRight.IncreaseVolume();
        }

        // Skru ned for lydstyrken i begge højttalere.
        public void DecreaseVolume() {
            speakerLeft.DecreaseVolume();
            speakerRight.DecreaseVolume();
        }

        // Skift til næste kanal (kanal lige efter 
        // nuværende kanal) på TVet.
        public void IncreaseChannel() {
            smartTV.Channel++;
        }

        // Skift til forrige kanal (kanal lige før 
        // nuværende kanal) på TVet.
        public void DecreaseChannel() {
            smartTV.Channel--;
        }

        // Start afspilning på Blu-Ray afspilleren
        public void PlayDevice() {
            if (!bluRay.IsPlaying) {
                bluRay.Play();
            }
        }

        // Stop afspilning på Blu-Ray afspilleren
        public void StopDevice() {
            if (bluRay.IsPlaying) {
                bluRay.Stop();
            }
        }

        // Returnerer status for hele system, i form af en string.
        // Udskift "???" med navnet på det instance field, du har
        // defineret for hver af de fire devices i HT-systemet.
        public override string ToString() {
            string status = "Current status of Home Theater\n";
            status += "------------------------------\n";
            status += $"Smart TV       : {ConvertOnOff(smartTV.IsOn)}, showing channel {ConvertChannelNo(smartTV.Channel)}\n";
            status += $"Blu-Ray player : {ConvertOnOff(bluRay.IsOn)}, is {ConvertBluRayStatus(bluRay.IsPlaying)}\n";
            status += $"Left Speaker   : {ConvertOnOff(speakerLeft.IsOn)}, is at volume {speakerLeft.CurrentVolume}\n";
            status += $"Right Speaker  : {ConvertOnOff(speakerRight.IsOn)}, is at volume {speakerRight.CurrentVolume}\n";

            return status;
        }

        #region Private metoder
        private string ConvertOnOff(bool onOff) {
            return onOff ? "On" : "Off";
        }

        private string ConvertChannelNo(int channelNo) {
            return channelNo == 0 ? "(No channel)" : channelNo.ToString();
        }

        private string ConvertBluRayStatus(bool isPlaying) {
            return isPlaying ? "Playing" : "Stopped";
        }
        #endregion
    }
}