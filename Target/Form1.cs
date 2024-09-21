using NAudio.CoreAudioApi;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Target
{
    public partial class Form1 : Form
    {
        const int mActionHotKeyID = 1;
        const int mPrintHotKeyID = 2;
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int key);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hwnd, int id);
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        
        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;
        internal static new void KeyDown(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }
        internal static new void KeyUp(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        private Point cursorPoint;
        private bool mute = true;
        private bool hora = true;
        private Timer clock;
        private bool prntshortcut = true;
        private Point faraway;
        private Point horalocation;

        ArrayList toDeleteList;

        MMDevice audiodevice;
        private MMDeviceEnumerator audioenumerator;
        private float savedVolume;
        public Form1()
        {
            InitializeComponent();
            // Action key :: Keys.End
            RegisterHotKey(this.Handle, mActionHotKeyID, 0, (int)Keys.End);
            // Action key :: Keys.Insert
            RegisterHotKey(this.Handle, mPrintHotKeyID, 0, (int)Keys.Insert);
            // Send notification
            this.notifyIcon1.BalloonTipText = "Background Tool Operative";
            this.notifyIcon1.BalloonTipTitle = "[Target v7.2]";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(2);
            // clock
            clock = new Timer();
            clock.Tick += new EventHandler(clock_Tick);
            faraway = new Point(10000, 10000);
            horalocation = new Point(0, 0);
            // get audio device abstractor
            audioenumerator = new MMDeviceEnumerator();
            // list of forms to delete
            toDeleteList = new ArrayList();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == mActionHotKeyID)
            {

                if (WindowState == FormWindowState.Maximized)
                {

                    // Hide black forms in all other monitors
                    toDeleteList.Clear();
                    foreach (Form form in Application.OpenForms) {
                        if (form.Text.Equals("Target Secondary Window")) {
                            form.TopMost = false;
                            form.WindowState = FormWindowState.Normal;
                            form.Visible = false;
                            toDeleteList.Add(form);
                        }
                    }
                    // Hide MAIN window
                    this.TopMost = false;
                    this.WindowState = FormWindowState.Normal;
                    this.Visible = false;

                    // hide clock
                    horatxt.Visible = false;
                    clock.Stop();

                    // enable tray icon options
                    toggleTrayOptions(true);

                    //Restore cursor position
                    Cursor.Position = cursorPoint;

                    if (mute)
                    {
                        // Restore volume
                        audiodevice = audioenumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                        audiodevice.AudioEndpointVolume.MasterVolumeLevelScalar = savedVolume;
                        GC.SuppressFinalize(audiodevice);
                    }
                    
                    // Free Memory
                    foreach (Form f in toDeleteList) {
                        f.Dispose();
                        GC.SuppressFinalize(f);
                    }
                    toDeleteList.Clear();
                    GC.Collect();
                }
                else
                {   

                    // Fullscreen
                    this.Visible = true;
                    this.BringToFront();
                    this.Dock = DockStyle.Fill;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;
                    // Create black fullscreen forms on other monitors
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (!s.Primary)
                        {
                            Form fullscreenForm = new Form();
                            fullscreenForm.BackColor = Color.Black;
                            fullscreenForm.Text = "Target Secondary Window";
                            fullscreenForm.Dock = DockStyle.Fill;
                            fullscreenForm.FormBorderStyle = FormBorderStyle.None;
                            fullscreenForm.StartPosition = FormStartPosition.Manual;
                            fullscreenForm.WindowState = FormWindowState.Maximized;
                            fullscreenForm.FormClosing += Form1_FormClosing;
                            fullscreenForm.Bounds = s.Bounds;
                            fullscreenForm.Show();
                        }
                    }

                    // disable tray menu options
                    toggleTrayOptions(false);

                    // show clock
                    if (hora)
                    {
                        horatxt.Text = DateTime.Now.ToString("HH:mm:ss");
                        int y = (this.Height / 2) - (horatxt.Height / 2);
                        int x = (this.Width / 2) - (horatxt.Width / 2);
                        horalocation.X = x;
                        horalocation.Y = y;
                        horatxt.Location = horalocation;

                        clock.Interval = 1000; // in miliseconds
                        clock.Start();

                        horatxt.Visible = true;
                    }

                    // Save cursor position
                    GetCursorPos(out cursorPoint);
                    // Cursor Hide
                    Cursor.Position = faraway;

                    if (mute)
                    {
                        // Mute volume
                        audiodevice = audioenumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                        savedVolume = audiodevice.AudioEndpointVolume.MasterVolumeLevelScalar;
                        audiodevice.AudioEndpointVolume.MasterVolumeLevelScalar = 0.0f;
                        GC.SuppressFinalize(audiodevice);
                    }
                }
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == mPrintHotKeyID)
            {
                if (prntshortcut)
                {
                    // Send screenshot command
                    KeyDown(Keys.LShiftKey);
                    KeyDown(Keys.LWin);
                    KeyDown(Keys.S);
                    KeyUp(Keys.S);
                    KeyUp(Keys.LWin);
                    KeyUp(Keys.LShiftKey);
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
            UnregisterHotKey(this.Handle, mActionHotKeyID);
            UnregisterHotKey(this.Handle, mPrintHotKeyID);
            Program.mutex.ReleaseMutex();
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

        private void muteAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (muteAudioToolStripMenuItem.Checked) mute = true;
            else mute = false;
        }

        private void shortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shortcutToolStripMenuItem.Checked) prntshortcut = true;
            else prntshortcut = false;
        }

        private void toggleTrayOptions(bool enable = false)
        {
            if (enable)
            {
                muteAudioToolStripMenuItem.Enabled = true;
                backgoundToolStripMenuItem.Enabled = true;
                shortcutToolStripMenuItem.Enabled = true;
                salirToolStripMenuItem.Enabled = true;
            } else
            {
                muteAudioToolStripMenuItem.Enabled = false;
                backgoundToolStripMenuItem.Enabled = false;
                shortcutToolStripMenuItem.Enabled = false;
                salirToolStripMenuItem.Enabled = false;
            }
        }
        
    }
}