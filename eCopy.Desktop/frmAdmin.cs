using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;

namespace eCopy.Desktop
{
    public partial class frmAdmin : Form
    {
        public APIServ employeeService = new APIServ("Employee");
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var employees = await employeeService.Get<List<EmployeeResponse>>();
        }
    }
}
