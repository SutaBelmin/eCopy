using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.WinUI
{
    public partial class frmPrintSettings : Form
    {
        private PRDataGridModel model;
        private List<Status> status;
        public APIService printRequestService = new APIService("PrintRequest"); 
        public frmPrintSettings(PRDataGridModel model)
        {
            InitializeComponent();
            this.model = model;
            this.status = Enum.GetValues<Status>().ToList();
                
        }

        private void frmPrintSettings_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            loadStatus();

            txtPrintOptions.Text = model.Options.ToString();
            txtSideOptions.Text = model.Side.ToString();
            txtOrientation.Text = model.Orientation.ToString();
            txtLetter.Text = model.Letter.ToString();
            txtPage.Text = model.Pages.ToString();
            txtCollate.Text = model.Collate.ToString();
            cmbStatus.SelectedIndex = status.IndexOf(Enum.Parse<Status>(model.Status));
            
        }

        void loadStatus()
        {
            cmbStatus.DataSource = status.Select(x => new
            {
                Name = x.ToString(),
                Value = x
            }).ToList();

            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Value";

        }

        private async void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            await printRequestService.Put<PrintRequestR>(model.ID, new PrintRequest
            {
                 Status = (Status)cmbStatus.SelectedValue
            });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
