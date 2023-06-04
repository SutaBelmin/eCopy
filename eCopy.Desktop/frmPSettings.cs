using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        private async void btnUStatus_Click(object sender, EventArgs e)
        {
            await printRequestService.Put<PrintRequestR>(model.ID, new PrintRequest
            {
                Status = (Status)cmbSt.SelectedValue
            });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
