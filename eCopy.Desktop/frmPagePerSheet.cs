using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPagePerSheet : Form
    {
        public APIServ pagePerSheetService = new APIServ("PagePerSheet");

        private bool update = false;
        private int ppsId = 0;

        public frmPagePerSheet()
        {
            InitializeComponent();
        }

        private void frmPagePerSheet_Load(object sender, EventArgs e)
        {
            loadData();

            dgvpps.Columns[0].Visible = false;
        }

        private async void loadData()
        {
            var list = await pagePerSheetService.Get<List<PPSModel>>();

            dgvpps.DataSource = list.Select(x => new PPSGridModel
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
                var pageps = new PagePerSheetRequest
                {
                   Name = txtName.Text,
                   IsActive = cbActive.Checked
                };

                if (update == false)
                {
                    var list = await pagePerSheetService.Get<List<PPSModel>>();
                    if (list.Any(x => x.Name == txtName.Text))
                    {
                        error.SetError(txtName, "Page per sheet already exist");
                        return;
                    }

                    await pagePerSheetService.Post<PagePerSheetResponse>(pageps);

                    MessageBox.Show("Successfully added new Page per sheet option! ", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    await pagePerSheetService.Put<PagePerSheetResponse>(ppsId, pageps);

                    MessageBox.Show("Successfully updated Page per sheet option! ", "Success", MessageBoxButtons.OK);
                }
                loadData();

                txtName.Text = "";
                cbActive.Checked = false;

                update = false;
                ppsId = 0;

            }
        }

        private async void dgvpps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvpps.Rows[e.RowIndex];

                int pagePerSheetId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var pagePerSheet = await pagePerSheetService.GetById<PagePerSheetResponse>(pagePerSheetId);

                txtName.Text = pagePerSheet.Name;
                cbActive.Checked = pagePerSheet.IsActive;
                update = true;
                ppsId = pagePerSheetId;

            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, error, "Enter some text");
        }
    }
}
