namespace eCopy.WinUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            bool logout = false;
            do
            {
                var loginForm = new frmLogin();
                //Application.Run(new frmEmp());
                Application.Run(loginForm);
                if (loginForm.Success)
                {
                    Form frm = null;

                    if (loginForm.Role == Model.Enum.Role.Employee)
                    {
                        frm = new frmEmp();
                    }
                    if (loginForm.Role == Model.Enum.Role.Administrator)
                    {
                        frm = new frmAdm();
                    }

                    Application.Run(frm);

                    logout = (frm is frmEmp frmEmpl && frmEmpl.logout) || (frm is frmAdm frmAdm && frmAdm.logout);
                }
            }while(logout);
        }
    }
}