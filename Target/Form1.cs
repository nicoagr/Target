using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Target
{
    public partial class Form1 : Form
    {
        const int mActionHotKeyID = 1;
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int key);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hwnd, int id);

        private Point cursorPoint;
        private double volume;
        private CoreAudioDevice defaultPlaybackDevice;
        private bool hora = true;
        private Timer clock = new Timer();

        public Form1()
        {
            InitializeComponent();
            // Action key :: Keys.End
            RegisterHotKey(this.Handle, mActionHotKeyID, 0, (int)Keys.End);
            defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == mActionHotKeyID)
            {

                if (WindowState == FormWindowState.Maximized)
                {
                    // Hide window
                    this.TopMost = false;
                    this.WindowState = FormWindowState.Normal;
                    this.Visible = false;

                    // hide clock
                    horatxt.Visible = false;

                    //Restore cursor position
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = cursorPoint;

                    // Restore volume
                    defaultPlaybackDevice.Volume = volume;

                }
                else
                {   

                    // Fullscreen
                    this.Visible = true;
                    this.TopMost = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;

                    // show clock
                    if (hora)
                    {
                        horatxt.Text = DateTime.Now.ToString("HH:mm:ss");
                        int y = (this.Height / 2) - (horatxt.Height / 2);
                        int x = (this.Width / 2) - (horatxt.Width / 2);
                        horatxt.Location = new Point(x, y);

                        clock.Tick += new EventHandler(clock_Tick);
                        clock.Interval = 1000; // in miliseconds
                        clock.Start();

                        horatxt.Visible = true;
                    }
               
                    // Save cursor position
                    GetCursorPos(out cursorPoint);
                    // Cursor Hide
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = new Point(10000, 10000);

                    // Save volume
                    volume = defaultPlaybackDevice.Volume;
                    // Mute volume
                    defaultPlaybackDevice.Volume = 0;

                }
            }
            base.WndProc(ref m);
        }

        private void clock_Tick(object sender, EventArgs e)
        {
                horatxt.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Disable Alt F4 to close the form
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void backgoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgoundToolStripMenuItem.Checked) hora = true;
            else hora = false;
        }
    }
}