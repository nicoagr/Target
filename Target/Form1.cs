using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

        public Form1()
        {
            InitializeComponent();
            // Action key :: Keys.End
            RegisterHotKey(this.Handle, mActionHotKeyID, 0, (int)Keys.End);
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

                    //Restore cursor position
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = cursorPoint;

                }
                else
                {
                    // Save cursor position
                    GetCursorPos(out cursorPoint);

                    // Fullscreen
                    this.Visible = true;
                    this.TopMost = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;

                    // Cursor Hide
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = new Point(10000, 10000);

                }
            }
            base.WndProc(ref m);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}