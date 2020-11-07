using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini
{
    // https://stackoverflow.com/questions/1738980/how-do-i-disable-the-c-sharp-message-box-beep
    // https://stackoverflow.com/a/26700191
    public static class Volume
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr h, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr h, uint dwVolume);

        private static uint _savedVolumeLevel;
        private static bool VolumeLevelSaved = false;

        // ----------------------------------------------------------------------------
        public static void On()
        {
            if (VolumeLevelSaved)
            {
                waveOutSetVolume(IntPtr.Zero, _savedVolumeLevel);
            }
        }

        // ----------------------------------------------------------------------------
        public static void Off()
        {
            waveOutGetVolume(IntPtr.Zero, out _savedVolumeLevel);
            VolumeLevelSaved = true;

            waveOutSetVolume(IntPtr.Zero, 0);
        }
    }
}
