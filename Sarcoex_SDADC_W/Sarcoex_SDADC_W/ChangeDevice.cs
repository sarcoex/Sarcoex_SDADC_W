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
        private Profile currentDevice;
        Profile[] profiles;

        public ChangeDevice()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            devicesFlowLayout.Controls.Clear();
            RefreshDevices();
            LoadProfiles();
        }

        private void LoadProfiles()
        {
            if (!System.IO.Directory.Exists("./profiles"))
                System.IO.Directory.CreateDirectory("./profiles");
            if (!System.IO.Directory.Exists("./MonitorConfigs"))
                System.IO.Directory.CreateDirectory("./MonitorConfigs");

            string[] profiles = System.IO.Directory.EnumerateFiles("./profiles").ToArray();
            if (profiles != null && profiles.Length > 0)
            {
                foreach (string s in profiles)
                {
                    string[] lines = System.IO.File.ReadAllLines(s);
                    Profile p = Profile.ParseText(lines);
                    ProfileButton b = Profile.GenerateButton(p, new Size(128, 128));
                    b.Click += new EventHandler(buttonDevice_CLick);

                    if (!System.IO.File.Exists("./MonitorConfigs/" + p.Title))
                    {
                        DialogResult result = MessageBox.Show("No Monitor config found for " + p.Title + ".\nDo you want to use current monitor setup", "No config found", MessageBoxButtons.YesNo);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            GenerateMonitorSetupConfig(p); 
                        }
                    }

                    devicesFlowLayout.Controls.Add(b);
                }
            }
        }

        private void SaveProfiles()
        {

        }

        private void RefreshDevices()
        {
            listPlaybackDevices.Items.Clear();
            listPlaybackDevices.Items.AddRange(FetchPlaybackDevices());
            UpdateCurrentDevice(currentDevice);
            listPlaybackDevices.ClearSelected();
        }

        private void ChangeMonitor(Profile p)
        {
            int exitCode = -1;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = (Properties.Settings.Default.Use64Bit) ? "dc2.exe" : "dc2x86.exe";
            start.Arguments = "-configure=\"./MonitorConfigs/" + p.Title + "\"";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
        }

        private void GenerateMonitorSetupConfig(Profile p)
        {
            int exitCode = -1;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = (Properties.Settings.Default.Use64Bit) ? "dc2.exe" : "dc2x86.exe";
            start.Arguments = "-create=\"./MonitorConfigs/" + p.Title + "\"";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
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

        private void UpdateCurrentDevice(Profile device)
        {
            currentDevice = device;
            if (currentDevice != null)
            {
                int index = listPlaybackDevices.FindString(currentDevice.PlaybackDevice);
                if (index > -1)
                {
                    listPlaybackDevices.SelectedIndex = index;
                }
                else
                {
                    listPlaybackDevices.ClearSelected();
                } 
            }
        }

        private void buttonDevice_CLick(object sender, EventArgs e)
        {
            Profile p = ((ProfileButton) sender).profile;
            ChangeTo(p.PlaybackDevice);
            ChangeMonitor(p);
            UpdateCurrentDevice(p);

            foreach (ProfileButton b in devicesFlowLayout.Controls)
            {
                if (b != (ProfileButton)sender)
                    b.BackColor = System.Drawing.SystemColors.Control;
            }

            ((ProfileButton)sender).BackColor = Color.Green;
        }
    }
}
