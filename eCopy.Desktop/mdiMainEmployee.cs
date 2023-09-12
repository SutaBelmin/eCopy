using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class mdiMainEmployee : Form
    {
        public APIServ employeeService = new APIServ("Employee");
        public bool logout = false;
        public mdiMainEmployee()
        {
            InitializeComponent();
        }

        private async void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var emp = await employeeService.GetEmployeeAccount();

            var childForm = new frmEmployeeAccount(emp);
            childForm.MdiParent = this;
            childForm.Text = "Edit account";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
        private void manageRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmEmployee();
            childForm.MdiParent = this;
            childForm.Text = "Manage requests";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void letterOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmLetter();
            childForm.MdiParent = this;
            childForm.Text = "Letter options";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void orientationOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmOrientation();
            childForm.MdiParent = this;
            childForm.Text = "Orientation options";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void collatedOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmCollated();
            childForm.MdiParent = this;
            childForm.Text = "Collated options";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void sideOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmSide();
            childForm.MdiParent = this;
            childForm.Text = "Side options";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void printPageOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmPrintPageOption();
            childForm.MdiParent = this;
            childForm.Text = "Print page options";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void pagePerSheetOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmPagePerSheet();
            childForm.MdiParent = this;
            childForm.Text = "Page per sheet options";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmRevenueForPeriod();
            childForm.MdiParent = this;
            childForm.Text = "Revenue";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void top5CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmTop5Customers();
            childForm.MdiParent = this;
            childForm.Text = "Top 5 customers";
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void revenueForLastYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new frmRevenueForLastYear();
            childForm.MdiParent = this;
            childForm.Text = "Revenue for last year";
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
