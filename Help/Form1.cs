using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Vision.Motion;
using System.Threading;
using AForge.Controls;

namespace Help
{
    public partial class FrmWecamTracking : Form
    {
        private readonly FilterInfoCollection
            _videoDevices;

        private string _selectedDevice;

        private readonly MotionDetector _detector =
         new MotionDetector(
            new TwoFramesDifferenceDetector(),
            new MotionAreaHighlighting());

        public string SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
        }

        public FrmWecamTracking()
        {
            InitializeComponent();
            try
            {
                _videoDevices = new FilterInfoCollection
                    (FilterCategory.VideoInputDevice);
                if(_videoDevices.Count == 0)
                {
                    throw new ApplicationException();
                }
                foreach (FilterInfo videoDevice in _videoDevices)
                {
                    cboCameras.Items.Add(videoDevice.Name);
                }
            }
            catch (ApplicationException)
            {
                cboCameras.Items.Add("No Cameras Found");
                cboCameras.Enabled = false;
                btnStart.Enabled = false;
            }
            cboCameras.SelectedIndex = 0;
        }

        private void videoSourcePlayer_Click(object sender, EventArgs e)
        {

        }

        private void OpenVideoSource(IVideoSource source)
        {
            CloseVideoSource();
            videoSourcePlayer.VideoSource =
                new AsyncVideoSource(source);
            videoSourcePlayer.Start();
            videoSourcePlayer.NewFrame += new VideoSourcePlayer.NewFrameHandler(this.VideoSourcePlayerNewFrame);
            
        }

        private void CloseVideoSource()
        {
            videoSourcePlayer.SignalToStop();

            for (int i = 0; i < 50 &&
            videoSourcePlayer.IsRunning; i++)
            {
                Thread.Sleep(100);
            }

            if (_detector != null)
            {
                _detector.Reset();
            }

            videoSourcePlayer.BorderColor = Color.Black;
        }


        private void VideoSourcePlayerNewFrame(object sender, ref Bitmap image)
        {
            try
            {
                var img = image;
                this.Invoke(new MethodInvoker(delegate ()
                {

                    if (_detector == null) return;

                    var motionValue = _detector.ProcessFrame(img);
                    if (motionValue > 0.1)
                    {
                        lblMotionAlert.ForeColor = Color.Red;
                        lblMotionAlert.Text = "Motion Detected";
                    }
                    else
                    {
                        lblMotionAlert.ForeColor = Color.Green;
                        lblMotionAlert.Text = "No Motion Detected";
                    }
                }));
            }
            catch (ObjectDisposedException)
            {
                // do nothing
            }

        }

        
        private void btnStart_Click(object sender, EventArgs e)
        {
            _selectedDevice = _videoDevices
                [cboCameras.SelectedIndex].MonikerString;

            OpenVideoSource(new VideoCaptureDevice(_selectedDevice));
        }

        private void lblMotionAlert_Click(object sender, EventArgs e)
        {

        }
    }
}
