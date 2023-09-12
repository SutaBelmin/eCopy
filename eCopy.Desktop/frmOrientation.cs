using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmOrientation : Form
    {
        public APIServ orientationService = new APIServ("Orientation");

        private bool update = false;
        private int orientId = 0;

        public frmOrientation()
        {
            InitializeComponent();
        }

        private void frmOrientation_Load(object sender, EventArgs e)
        {
            loadData();

            dgvOrientation.Columns[0].Visible = false;
        }

        private async void loadData()
        {
            var list = await orientationService.Get<List<OrientationModel>>();

            dgvOrientation.DataSource = list.Select(x => new OrientationGridModel
            {
                Id= x.Id,
                Name= x.Name,
                IsActive = x.IsActive
            }).ToList();

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                var orientation = new OrientationRequest
                {
                   Name = txtName.Text,
                   IsActive = cbActive.Checked
                };

                if (update == false)
                {
                    var list = await orientationService.Get<List<OrientationModel>>();
                    if (list.Any(x => x.Name == txtName.Text))
                    {
                        error.SetError(txtName, "Orientation already exist");
                        return;
                    }

                    await orientationService.Post<OrientationResponse>(orientation);

                    MessageBox.Show("Successfully added new Orientation! ", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    await orientationService.Put<OrientationResponse>(orientId, orientation);

                    MessageBox.Show("Successfully updated Orientation! ", "Success", MessageBoxButtons.OK);
                }
                loadData();

                txtName.Text = "";
                cbActive.Checked = false;

                update = false;
                orientId = 0;

            }
        }

        private async void dgvOrientation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvOrientation.Rows[e.RowIndex];

                int orientationId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var orientation = await orientationService.GetById<OrientationResponse>(orientationId);

                txtName.Text = orientation.Name;
                cbActive.Checked = orientation.IsActive;
                update = true;
                orientId = orientationId;
            }
        }


        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, error, "Enter some text");
        }

    }
}
