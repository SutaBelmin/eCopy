using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                //Application.Run(new frmEmp());
                Application.Run(loginForm);
                if (loginForm.Success)
                {
                    Form frm = null;

                    if (loginForm.Role == Model.Enum.Role.Employee)
                    {
                        frm = new frmEmployee();
                    }
                    if (loginForm.Role == Model.Enum.Role.Administrator)
                    {
                        frm = new frmAdmin();
                    }

                    Application.Run(frm);

                    logout = (frm is frmEmployee frmEmpl && frmEmpl.logout) || (frm is frmAdmin frmAdm && frmAdm.logout);
                }
            } while (logout);
        }
    }
}
