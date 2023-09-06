using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmCity : Form
    {
        public APIServ cityService = new APIServ("City");

        public frmCity()
        {
            InitializeComponent();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {
            loadCity();
        }

        private async void loadCity()
        {
            
            var list = await cityService.Get<List<CityResponse>>();

            dgvCity.DataSource = list.Select(x => new CityModel
            {
                ID = x.ID,
                Name = x.Name,
                ShortName = x.ShortName,
                PostalCode = x.PostalCode
            }).ToList();
        }

        private void btnNewCity_Click(object sender, EventArgs e)
        {
            frmAddCity frmACi = new frmAddCity();
            var result = frmACi.ShowDialog();


            if (result == DialogResult.OK)
            {
                loadCity();
            }
        }

        private void dgvCity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var req = dgvCity.SelectedRows[0].DataBoundItem as CityModel;

            if (req != null)
            {
                frmEditCity frm = new frmEditCity(req);
                frm.ShowDialog();
                loadCity();
            }
        }
    }
}
