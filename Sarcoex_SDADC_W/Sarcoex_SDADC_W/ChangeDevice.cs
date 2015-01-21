using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

// Prepare the process to run

namespace Sarcoex_SDADC_W
{
    public partial class ChangeDevice : Form
    {
        public ChangeDevice()
        {
            InitializeComponent();
        }

        private void ChangeTo(string device)
        {
            int exitCode = -1;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "NirCmd.exe";
            start.Arguments = "setdefaultsounddevice " + device;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
        }

        private void buttonHeadset_Click(object sender, EventArgs e)
        {
            ChangeTo(Properties.Settings.Default.HeadsetDevice);
        }

        private void buttonTV_Click(object sender, EventArgs e)
        {
            ChangeTo(Properties.Settings.Default.TVDevice);
        }

        private void buttonSpeakers_Click(object sender, EventArgs e)
        {
            ChangeTo(Properties.Settings.Default.SpeakersDevice);
        }
    }
}
