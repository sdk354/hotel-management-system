using System;
using System.Data;
using System.Linq;            
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new ShellContext());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred:\n" + ex.Message,
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

    public class ShellContext : ApplicationContext
    {
        private int openForms = 0;
        private bool reloginRequested = false;

        public static ShellContext Current { get; private set; }

        public ShellContext()
        {
            Current = this;

            if (ShowLoginDialog())
            {
                Open(new DashboardForm());
            }
            else
            {
                ExitThread();
            }
        }

        public void Open(Form form)
        {
            openForms++;
            form.FormClosed += (s, e) =>
            {
                openForms--;
                if (openForms <= 0)
                {
                    if (reloginRequested)
                    {
                        // We’re intentionally restarting to login
                        reloginRequested = false;
                        StartAfterRelogin();
                    }
                    else
                    {
                        ExitThread();
                    }
                }
            };
            form.Show();
        }

        // Call this from anywhere (e.g., Dashboard logout) to restart the login flow
        public void Relogin()
        {
            reloginRequested = true;

            // Close all open forms; when the last one closes, StartAfterRelogin() runs
            foreach (Form f in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (f != null && !f.IsDisposed)
                    f.Close();
            }
        }

        private void StartAfterRelogin()
        {
            if (ShowLoginDialog())
            {
                Open(new DashboardForm());
            }
            else
            {
                ExitThread();
            }
        }

        private bool ShowLoginDialog()
        {
            using (var login = new LoginForm())
            {
                var result = login.ShowDialog();
                return result == DialogResult.OK;
            }
        }
    }
}
