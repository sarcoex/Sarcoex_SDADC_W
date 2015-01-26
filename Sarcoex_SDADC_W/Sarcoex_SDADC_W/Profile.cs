using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcoex_SDADC_W
{
    public class Profile
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _playbackDevice;
        public string PlaybackDevice
        {
            get { return _playbackDevice; }
            set { _playbackDevice = value; }
        }

        private string[] _activeMonitors;
        public string[] ActiveMonitors
        {
            get { return _activeMonitors; }
            set { _activeMonitors = value; }
        }

        public Profile(string title, string playbackDevice, string[] activeMonitors)
        {
            this._title = title;
            this._playbackDevice = playbackDevice;
            this._activeMonitors = activeMonitors;
        }

        public Profile()
        {

        }

        public static Profile ParseText(string text)
        {
            Profile p = new Profile();

            return p;
        }
    }
}
