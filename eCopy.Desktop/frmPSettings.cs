using eCopy.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPSettings : Form
    {
        private PRDGridModel model;
        private List<Status> status;
        public APIServ printRequestService = new APIServ("PrintRequest");
        public frmPSettings(PRDGridModel model)
        {
            InitializeComponent();
            this.model = model;
            this.status = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
        }

        private void frmPSettings_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            loadStatus();

            txtPrintPO.Text = model.Options.ToString();
            txtSidePO.Text = model.Side.ToString();
            txtOrie.Text = model.Orientation.ToString();
            txtLett.Text = model.Letter.ToString();
            txtPagePS.Text = model.Pages.ToString();
            txtColl.Text = model.Collate.ToString();
            cmbSt.SelectedIndex = status.IndexOf((Status)Enum.Parse(typeof(Status), model.Status));
            //(model.Status) je string i mora se parsirati u Enum,
            //IndexOf prima enum tj Status a Status je Enum
        }

        void loadStatus()
        {
            cmbSt.DataSource = status.Select(x => new
            {
                Name = x.ToString(),
                Value = x
            }).ToList();

            cmbSt.DisplayMember = "Name";
            cmbSt.ValueMember = "Value";

        }
    }
}
