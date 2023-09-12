using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class mdiMainAdmin : Form
    {
        public bool logout = false;

        public mdiMainAdmin()
        {
            InitializeComponent();
        }

        private void viewAndEditEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmAdmin();
            childForm.MdiParent = this;
            childForm.Text = "Employee";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmAddEmp();
            childForm.MdiParent = this;
            childForm.Text = "Add employee";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void viewAndEditCitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmCity();
            childForm.MdiParent = this;
            childForm.Text = "Cities";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void addCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmAddCity();
            childForm.MdiParent = this;
            childForm.Text = "Add city";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.logout = true;
            this.Close();
        }
    }
}
