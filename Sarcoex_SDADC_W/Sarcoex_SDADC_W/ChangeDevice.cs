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
        private string currentDevice = "";

        public ChangeDevice()
        {
            InitializeComponent();
            listPlaybackDevices.Items.Clear();
            listPlaybackDevices.Items.AddRange(FetchPlaybackDevices());
            UpdateCurrentDevice(currentDevice);
            listPlaybackDevices.ClearSelected();
        }

        private string[] FetchPlaybackDevices()
        {
            string lines = "";
            int exitCode = -1;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "EndPointController.exe";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.UseShellExecute = false;

            using (Process proc = Process.Start(start))
            {
                try
                {
                    while (!proc.StandardOutput.EndOfStream)
                    {
                        string line = proc.StandardOutput.ReadLine();
                        line = line.Substring("Audio Device 1: ".Length);
                        lines += line + "\n";
                    }
                }
                catch (System.InvalidOperationException ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }

            return lines.Split('\n');
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

        private void UpdateCurrentDevice(string device)
        {
            currentDevice = device;
            if (currentDevice == Properties.Settings.Default.HeadsetDevice)
            {
                buttonHeadset.BackColor = Color.Green;
                buttonSpeakers.BackColor = SystemColors.Control;
            buttonTV.BackColor = SystemColors.Control;
            }
            else if (currentDevice == Properties.Settings.Default.TVDevice)
            {
                buttonHeadset.BackColor = SystemColors.Control;
                buttonSpeakers.BackColor = SystemColors.Control;
                buttonTV.BackColor = Color.Green;
            }
            else if (currentDevice == Properties.Settings.Default.SpeakersDevice)
            {
                buttonHeadset.BackColor = SystemColors.Control;
                buttonSpeakers.BackColor = Color.Green;
                buttonTV.BackColor = SystemColors.Control;
            }
            else
            {
                buttonHeadset.BackColor = SystemColors.Control;
                buttonSpeakers.BackColor = SystemColors.Control;
                buttonTV.BackColor = SystemColors.Control;
            }

            int index = listPlaybackDevices.FindString(currentDevice);
            if (index > -1)
            {
                listPlaybackDevices.SelectedIndex = index;
            }
            else
            {
                listPlaybackDevices.ClearSelected();
            }
        }

        private void buttonHeadset_Click(object sender, EventArgs e)
        {
            ChangeTo(Properties.Settings.Default.HeadsetDevice);
            UpdateCurrentDevice(Properties.Settings.Default.HeadsetDevice);
        }

        private void buttonTV_Click(object sender, EventArgs e)
        {
            ChangeTo(Properties.Settings.Default.TVDevice);
            UpdateCurrentDevice(Properties.Settings.Default.TVDevice);
        }

        private void buttonSpeakers_Click(object sender, EventArgs e)
        {
            ChangeTo(Properties.Settings.Default.SpeakersDevice);
            UpdateCurrentDevice(Properties.Settings.Default.SpeakersDevice);
        }
    }
}
