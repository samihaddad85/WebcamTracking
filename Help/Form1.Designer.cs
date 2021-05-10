
using AForge.Controls;

namespace Help
{
    partial class FrmWecamTracking
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
            videoSourcePlayer.NewFrame -= new VideoSourcePlayer.NewFrameHandler(this.VideoSourcePlayerNewFrame);
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.cboCameras = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblMotionAlert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(42, 12);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(660, 305);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.Click += new System.EventHandler(this.videoSourcePlayer_Click);
            // 
            // cboCameras
            // 
            this.cboCameras.FormattingEnabled = true;
            this.cboCameras.Location = new System.Drawing.Point(235, 368);
            this.cboCameras.Name = "cboCameras";
            this.cboCameras.Size = new System.Drawing.Size(121, 21);
            this.cboCameras.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(394, 365);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Video";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblMotionAlert
            // 
            this.lblMotionAlert.AutoSize = true;
            this.lblMotionAlert.Location = new System.Drawing.Point(514, 375);
            this.lblMotionAlert.Name = "lblMotionAlert";
            this.lblMotionAlert.Size = new System.Drawing.Size(70, 13);
            this.lblMotionAlert.TabIndex = 3;
            this.lblMotionAlert.Text = "lblMotionAlert";
            this.lblMotionAlert.Click += new System.EventHandler(this.lblMotionAlert_Click);
            // 
            // FrmWecamTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMotionAlert);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cboCameras);
            this.Controls.Add(this.videoSourcePlayer);
            this.Name = "FrmWecamTracking";
            this.Text = "Wecam Tracking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.ComboBox cboCameras;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblMotionAlert;
    }
}

