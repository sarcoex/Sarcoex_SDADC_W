using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarcoex_SDADC_W
{
    public class Profile
    {
        public bool HasMonitorConfig
        {
            get { return System.IO.File.Exists("./MonitorConfigs/" + Title); }
        }

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
        
        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public Profile(string title, string playbackDevice)
        {
            this._title = title;
            this._playbackDevice = playbackDevice;
        }

        public Profile()
        {

        }

        public static ProfileButton GenerateButton(Profile p, System.Drawing.Size size)
        {
            ProfileButton b = new ProfileButton();
            b.profile = p;

            if (p == null)
                return null;

            b.Size = size;
            object image = Properties.Resources.ResourceManager.GetObject(p.Icon);
            b.BackgroundImage = System.Drawing.Image.FromFile("./Resources/" + p.Icon);
            b.TextImageRelation = TextImageRelation.ImageAboveText;
            b.Text = "";

            return b;
        }

        public static Profile ParseText(string[] lines)
        {
            //string[] lines = text.Split('\n');
            // Makes sure it actually got enough "content" to be liable as text (need better phrasing)
            if (lines == null || lines.Length < 3)
                return null;

            Profile p = new Profile();
            p.Title = lines[0];
            p.PlaybackDevice = lines[1];
            p.Icon = lines[2];

            return p;
        }
    }
}
