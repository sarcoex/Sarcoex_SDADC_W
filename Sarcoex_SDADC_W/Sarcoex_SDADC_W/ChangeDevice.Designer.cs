namespace Sarcoex_SDADC_W
{
    partial class ChangeDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.devicesFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonHeadset = new System.Windows.Forms.Button();
            this.buttonTV = new System.Windows.Forms.Button();
            this.buttonSpeakers = new System.Windows.Forms.Button();
            this.listPlaybackDevices = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicesFlowLayout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // devicesFlowLayout
            // 
            this.devicesFlowLayout.Controls.Add(this.buttonHeadset);
            this.devicesFlowLayout.Controls.Add(this.buttonTV);
            this.devicesFlowLayout.Controls.Add(this.buttonSpeakers);
            this.devicesFlowLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.devicesFlowLayout.Location = new System.Drawing.Point(0, 33);
            this.devicesFlowLayout.Name = "devicesFlowLayout";
            this.devicesFlowLayout.Size = new System.Drawing.Size(778, 381);
            this.devicesFlowLayout.TabIndex = 0;
            // 
            // buttonHeadset
            // 
            this.buttonHeadset.BackColor = System.Drawing.SystemColors.Control;
            this.buttonHeadset.BackgroundImage = global::Sarcoex_SDADC_W.Properties.Resources.audio_headset;
            this.buttonHeadset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHeadset.Location = new System.Drawing.Point(3, 3);
            this.buttonHeadset.Name = "buttonHeadset";
            this.buttonHeadset.Size = new System.Drawing.Size(128, 128);
            this.buttonHeadset.TabIndex = 0;
            this.buttonHeadset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonHeadset.UseVisualStyleBackColor = false;
            this.buttonHeadset.Click += new System.EventHandler(this.buttonHeadset_Click);
            // 
            // buttonTV
            // 
            this.buttonTV.BackgroundImage = global::Sarcoex_SDADC_W.Properties.Resources.video_television_3;
            this.buttonTV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTV.Location = new System.Drawing.Point(137, 3);
            this.buttonTV.Name = "buttonTV";
            this.buttonTV.Size = new System.Drawing.Size(128, 128);
            this.buttonTV.TabIndex = 1;
            this.buttonTV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTV.UseVisualStyleBackColor = true;
            this.buttonTV.Click += new System.EventHandler(this.buttonTV_Click);
            // 
            // buttonSpeakers
            // 
            this.buttonSpeakers.BackgroundImage = global::Sarcoex_SDADC_W.Properties.Resources.audio_speaker;
            this.buttonSpeakers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSpeakers.Location = new System.Drawing.Point(271, 3);
            this.buttonSpeakers.Name = "buttonSpeakers";
            this.buttonSpeakers.Size = new System.Drawing.Size(128, 128);
            this.buttonSpeakers.TabIndex = 2;
            this.buttonSpeakers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSpeakers.UseVisualStyleBackColor = true;
            this.buttonSpeakers.Click += new System.EventHandler(this.buttonSpeakers_Click);
            // 
            // listPlaybackDevices
            // 
            this.listPlaybackDevices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listPlaybackDevices.Enabled = false;
            this.listPlaybackDevices.FormattingEnabled = true;
            this.listPlaybackDevices.ItemHeight = 20;
            this.listPlaybackDevices.Location = new System.Drawing.Point(0, 420);
            this.listPlaybackDevices.Name = "listPlaybackDevices";
            this.listPlaybackDevices.Size = new System.Drawing.Size(778, 124);
            this.listPlaybackDevices.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // ChangeDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.listPlaybackDevices);
            this.Controls.Add(this.devicesFlowLayout);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "ChangeDevice";
            this.Text = "Change Device";
            this.devicesFlowLayout.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel devicesFlowLayout;
        private System.Windows.Forms.Button buttonHeadset;
        private System.Windows.Forms.Button buttonTV;
        private System.Windows.Forms.Button buttonSpeakers;
        private System.Windows.Forms.ListBox listPlaybackDevices;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
    }
}