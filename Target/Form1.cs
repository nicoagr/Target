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
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        private const int HWND_TOPMOST = -1;

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;
        internal static void KeyDown(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }
        internal static void KeyUp(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private Point cursorPoint;
        private bool mute = true;
        private bool hora = true;
        private Timer clock;
        private bool prntshortcut = true;
        private Point faraway;
        private Point horalocation;

        private Form[] toDelete;

        public Form1()
        {
            InitializeComponent();
            // Action key :: Keys.End
            RegisterHotKey(this.Handle, mActionHotKeyID, 0, (int)Keys.End);
            // Action key :: Keys.Imppnt
            RegisterHotKey(this.Handle, mPrintHotKeyID, 0, (int)Keys.PrintScreen);
            // Send notification
            this.notifyIcon1.BalloonTipText = "Background Tool Operative";
            this.notifyIcon1.BalloonTipTitle = "[Target v7.0]";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(2);
            // clock
            clock = new Timer();
            clock.Tick += new EventHandler(clock_Tick);
            faraway = new Point(10000, 10000);
            horalocation = new Point(0, 0);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == mActionHotKeyID)
            {

                if (WindowState == FormWindowState.Maximized)
                {

                    // Hide black forms in all other monitors
                    ArrayList toDelete = new ArrayList();
                    foreach (Form form in Application.OpenForms) {
                        if (form.Text.Equals("Target Secondary Window")) {
                            form.TopMost = false;
                            form.WindowState = FormWindowState.Normal;
                            form.Visible = false;
                            toDelete.Add(form);
                        }
                    }
                    // Hide MAIN window
                    this.TopMost = false;
                    this.WindowState = FormWindowState.Normal;
                    this.Visible = false;

                    // hide clock
                    horatxt.Visible = false;
                    clock.Stop();


                    //Restore cursor position
                    Cursor.Position = cursorPoint;

                    if (mute)
                    {
                        // Restore volume
                        SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                    }
                    
                    // Free Memory
                    foreach (Form f in toDelete) {
                        f.Dispose();
                    }
                    toDelete.Clear();
                }
                else
                {   

                    // Fullscreen
                    this.Visible = true;
                    this.TopMost = true;
                    this.BringToFront();
                    this.Dock = DockStyle.Fill;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    // Create black fullscreen forms on other monitors
                    Screen[] screens = Screen.AllScreens;
                    for (int i = 0; i < screens.Length; i++)
                    {
                        if (!screens[i].Primary)
                        {
                            Form fullscreenForm = new Form();
                            fullscreenForm.BackColor = Color.Black;
                            fullscreenForm.Text = "Target Secondary Window";
                            fullscreenForm.Dock = DockStyle.Fill;
                            fullscreenForm.FormBorderStyle = FormBorderStyle.None;
                            fullscreenForm.StartPosition = FormStartPosition.Manual;
                            fullscreenForm.WindowState = FormWindowState.Maximized;
                            fullscreenForm.FormClosing += Form1_FormClosing;
                            fullscreenForm.Bounds = screens[i].Bounds;
                            fullscreenForm.Show();
                        }
                    }

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
                        SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
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
    }
}