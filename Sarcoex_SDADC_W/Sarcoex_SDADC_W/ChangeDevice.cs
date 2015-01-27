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
                    if (!p.HasMonitorConfig)
                        b.BackColor = Color.DarkRed;
                    b.ContextMenuStrip = deviceMenu;
                    b.Click += new EventHandler(buttonDevice_CLick);

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
            
            // An extra just in case, because sometimes the TV audio ouput isn't shown, 
            // if connected to the TV with HDMI and the TV display is NOT enabled
            ChangeTo(p.PlaybackDevice);
        }

        private void changeMonitorSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem != null)
            {
                ContextMenuStrip cms = (ContextMenuStrip) menuItem.GetCurrentParent();
                ProfileButton sourceClicked = (ProfileButton) cms.SourceControl;
                DialogResult result = MessageBox.Show("Please adjust to monitor setup you want to use with " + sourceClicked.profile.Title +
                    "\nPress OK when you are done.", "Monitor configuration", MessageBoxButtons.OK);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    GenerateMonitorSetupConfig(sourceClicked.profile);
                }

                if (!sourceClicked.profile.HasMonitorConfig)
                {
                    sourceClicked.BackColor = Color.DarkRed;
                }
                else
                {
                    sourceClicked.BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }
    }
}
