using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Target
{
    internal static class Program
    {

        static Mutex mutex = new Mutex(true, name: "{37B1A52D-FA21-476C-9E6A-0FE832F112F2}");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("El programa ya se está ejecutando!!", "Target - Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}