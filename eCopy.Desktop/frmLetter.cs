using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmLetter : Form
    {
        public APIServ letterService = new APIServ("Letter");

        private bool update = false;
        private int lettId = 0;
        public frmLetter()
        {
            InitializeComponent();
        }

        private void frmLetter_Load(object sender, EventArgs e)
        {
            loadData();

            dgvLetter.Columns[0].Visible = false;
        }

        private async void loadData()
        {
            var list = await letterService.Get<List<LetterModel>>();

            dgvLetter.DataSource = list.Select(x=> new LetterGridModel
            {
                Id= x.Id,
                Name= x.Name,
                IsActive = x.IsActive
            }).ToList();

        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                var letter = new LetterRequest
                {
                    Name = txtName.Text,
                    IsActive = cbActive.Checked
                };

                if (update == false)
                {
                    var list = await letterService.Get<List<LetterModel>>();
                    if (list.Any(x => x.Name == txtName.Text))
                    {
                        error.SetError(txtName, "Letter already exist");
                        return;
                    }

                    await letterService.Post<LetterResponse>(letter);

                    MessageBox.Show("Successfully added new Letter! ", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    await letterService.Put<LetterResponse>(lettId, letter);

                    MessageBox.Show("Successfully updated Letter! ", "Success", MessageBoxButtons.OK);
                }
                loadData();

                txtName.Text = "";
                cbActive.Checked = false;

                update = false;
                lettId = 0;

            }

        }

        private async void dgvLetter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvLetter.Rows[e.RowIndex];

                int letterId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var letter = await letterService.GetById<LetterResponse>(letterId);

                txtName.Text = letter.Name;
                cbActive.Checked = letter.IsActive;
                update = true;
                lettId = letterId;

            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, error, "Enter some text");
        }

    }
}
