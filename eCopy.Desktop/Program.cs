using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool logout = false;
            do
            {
                var loginForm = new frmLog();
                Application.Run(loginForm);
                if (loginForm.Success)
                {
                    Form frm = null;

                    if (loginForm.Role == Model.Enum.Role.Employee)
                    {
                        frm = new mdiMainEmployee();
                    }
                    if (loginForm.Role == Model.Enum.Role.Administrator)
                    {
                        frm = new mdiMainAdmin();
                    }

                    Application.Run(frm);

                    logout = (frm is mdiMainEmployee mdiEmp && mdiEmp.logout) || (frm is mdiMainAdmin mdiAdmin && mdiAdmin.logout);

                }
            } while (logout);
        }
    }
}
