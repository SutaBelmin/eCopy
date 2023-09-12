using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPrintPageOption : Form
    {
        public APIServ printpoService = new APIServ("PrintPageOpt");

        private bool update = false;
        private int ppoId = 0;

        public frmPrintPageOption()
        {
            InitializeComponent();
        }

        private void frmPrintPageOption_Load(object sender, EventArgs e)
        {
            loadData();

            dgvppo.Columns[0].Visible = false;
        }

        private async void loadData()
        {
            var list = await printpoService.Get<List<PPOModel>>();

            dgvppo.DataSource = list.Select(x => new PPOGridModel
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive
            }).ToList();

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                var prinpo = new PrintPageOptionRequest
                {
                    Name = txtName.Text,
                    IsActive = cbActive.Checked
                };

                if (update == false)
                {
                    var list = await printpoService.Get<List<PPOModel>>();
                    if (list.Any(x => x.Name == txtName.Text))
                    {
                        error.SetError(txtName, "Print page option already exist");
                        return;
                    }

                    await printpoService.Post<PrintPageOptionResponse>(prinpo);

                    MessageBox.Show("Successfully added new Print page option! ", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    await printpoService.Put<PrintPageOptionResponse>(ppoId, prinpo);

                    MessageBox.Show("Successfully updated Print page option! ", "Success", MessageBoxButtons.OK);
                }
                loadData();

                txtName.Text = "";
                cbActive.Checked = false;

                update = false;
                ppoId = 0;

            }
        }

        private async void dgvppo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvppo.Rows[e.RowIndex];

                int printPageOptId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var printPageOpt = await printpoService.GetById<PrintPageOptionResponse>(printPageOptId);

                txtName.Text = printPageOpt.Name;
                cbActive.Checked = printPageOpt.IsActive;
                update = true;
                ppoId = printPageOptId;

            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, error, "Enter some text");
        }
    }
}
