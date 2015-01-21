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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonHeadset = new System.Windows.Forms.Button();
            this.buttonTV = new System.Windows.Forms.Button();
            this.buttonSpeakers = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonHeadset);
            this.flowLayoutPanel1.Controls.Add(this.buttonTV);
            this.flowLayoutPanel1.Controls.Add(this.buttonSpeakers);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(402, 344);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonHeadset
            // 
            this.buttonHeadset.BackgroundImage = global::Sarcoex_SDADC_W.Properties.Resources.audio_headset;
            this.buttonHeadset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHeadset.Location = new System.Drawing.Point(3, 3);
            this.buttonHeadset.Name = "buttonHeadset";
            this.buttonHeadset.Size = new System.Drawing.Size(128, 128);
            this.buttonHeadset.TabIndex = 0;
            this.buttonHeadset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonHeadset.UseVisualStyleBackColor = true;
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
            // ChangeDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 344);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(424, 400);
            this.MinimumSize = new System.Drawing.Size(424, 400);
            this.Name = "ChangeDevice";
            this.Text = "Change Device";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonHeadset;
        private System.Windows.Forms.Button buttonTV;
        private System.Windows.Forms.Button buttonSpeakers;
    }
}