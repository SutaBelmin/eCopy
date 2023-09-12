using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmSide : Form
    {
        public APIServ sideService = new APIServ("Side");

        private bool update = false;
        private int sidId = 0;

        public frmSide()
        {
            InitializeComponent();
        }

        private void frmSide_Load(object sender, EventArgs e)
        {
            loadData();

            dgvSide.Columns[0].Visible = false;
        }

        private async void loadData()
        {
            var list = await sideService.Get<List<SideModel>>();

            dgvSide.DataSource = list.Select(x => new SideGridModel
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
                var side = new SideRequest
                {
                    Name = txtName.Text,
                    IsActive = cbActive.Checked
                };

                if (update == false)
                {
                    var list = await sideService.Get<List<SideModel>>();
                    if (list.Any(x => x.Name == txtName.Text))
                    {
                        error.SetError(txtName, "Side option already exist");
                        return;
                    }

                    await sideService.Post<SideResponse>(side);

                    MessageBox.Show("Successfully added new Side option! ", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    await sideService.Put<SideResponse>(sidId, side);

                    MessageBox.Show("Successfully updated Side option! ", "Success", MessageBoxButtons.OK);
                }
                loadData();

                txtName.Text = "";
                cbActive.Checked = false;

                update = false;
                sidId = 0;

            }
        }

        private async void dgvSide_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSide.Rows[e.RowIndex];

                int sideId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var side = await sideService.GetById<SideResponse>(sideId);

                txtName.Text = side.Name;
                cbActive.Checked = side.IsActive;
                update = true;
                sidId = sideId;

            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, error, "Enter some text");
        }

    }
}
