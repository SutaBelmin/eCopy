using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmCollated : Form
    {
        public APIServ collatedService = new APIServ("Collated");

        private bool update = false;
        private int colId = 0;
        public frmCollated()
        {
            InitializeComponent();
        }

        private void frmCollated_Load(object sender, EventArgs e)
        {
            loadData();

            dgvCollated.Columns[0].Visible = false;
        }

        private async void loadData()
        {
            var list = await collatedService.Get<List<CollatedModel>>();

            dgvCollated.DataSource = list.Select(x => new CollatedGridModel
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
                var collated = new CollatedRequest
                {
                    Name = txtName.Text,
                    IsActive = cbActive.Checked
                };

                if (update == false)
                {
                    var list = await collatedService.Get<List<CollatedModel>>();
                    if (list.Any(x => x.Name == txtName.Text))
                    {
                        error.SetError(txtName, "Collated already exist");
                        return;
                    }

                    await collatedService.Post<CollatedResponse>(collated);

                    MessageBox.Show("Successfully added new Collated option! ", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    await collatedService.Put<CollatedResponse>(colId, collated);

                    MessageBox.Show("Successfully updated Collated option! ", "Success", MessageBoxButtons.OK);
                }
                loadData();

                txtName.Text = "";
                cbActive.Checked = false;

                update = false;
                colId = 0;

            }
        }

        private async void dgvCollated_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCollated.Rows[e.RowIndex];

                int collatedId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var collated = await collatedService.GetById<LetterResponse>(collatedId);

                txtName.Text = collated.Name;
                cbActive.Checked = collated.IsActive;
                update = true;
                colId = collatedId;

            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, error, "Enter some text");
        }
    }
}
