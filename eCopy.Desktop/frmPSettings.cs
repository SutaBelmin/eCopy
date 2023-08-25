using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPSettings : Form
    {
        private PRDGridModel model;
        private List<Status> status;
        public APIServ printRequestService = new APIServ("PrintRequest");
        string filePath;
        public frmPSettings(PRDGridModel model)
        {
            InitializeComponent();
            this.model = model;
            this.status = Enum.GetValues(typeof(Status)).Cast<Status>().Where(x => x != Status.Canceled).ToList();
        }

        private void frmPSettings_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private async void loadData()
        {
            var printSettings = await printRequestService.GetById<PrintRequestR>(model.ID);
            filePath = printSettings.FilePath;

            loadStatus();

            if (printSettings.Comment == null || printSettings.Comment == "null")
            {
                txtComment.Text = "";
            }
            else
            {
                txtComment.Text = printSettings.Comment;
            }


            txtPrintPO.Text = printSettings.Options.ToString();
            txtSidePO.Text = printSettings.Side.ToString();
            txtOrie.Text = printSettings.Orientation.ToString();
            txtLett.Text = printSettings.Letter.ToString();
            txtPagePS.Text = printSettings.Pages.ToString();
            txtColl.Text = printSettings.Collate.ToString();
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
            var oldStatus = model.Status;

            if(oldStatus == "Completed" || oldStatus == "Rejected" || oldStatus == "Canceled")
            {
                MessageBox.Show("Can't update request when Status is Completed, Rejected or Canceled", "Message", MessageBoxButtons.OK);
                cmbSt.SelectedIndex = status.IndexOf((Status)Enum.Parse(typeof(Status), model.Status));
                return;
            }

            if ((Status)cmbSt.SelectedValue == Status.New)
            {
                MessageBox.Show("Can't set Status to New", "Message", MessageBoxButtons.OK);
                return;
            }
            else
            {
                await printRequestService.Put<PrintRequestR>(model.ID, new PrintRequestUpdate
                {
                    Status = (Status)cmbSt.SelectedValue,
                    Comment = txtComment.Text
                });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if(model.ID < 8)
                {
                    MessageBox.Show("This is a test request so it has no file for download.\n " +
                        "Please choose a request that contains a file (Id > 7)", "Message", 
                        MessageBoxButtons.OK);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    string extension = Path.GetExtension(filePath).ToLower(); 
                    string defaultExt = ".docx"; 
                    string filter = "Word Documents (*.docx)|*.docx|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"; 
                    int filterIndex = 1; 

                    if (!string.IsNullOrEmpty(extension))
                    {
                        if (extension == ".docx" || extension == ".doc")
                        {
                            defaultExt = extension;
                            filterIndex = 1; 
                        }
                        else if (extension == ".pdf")
                        {
                            defaultExt = extension;
                            filterIndex = 2; 
                        }
                    }

                    saveDialog.FileName = Path.GetFileNameWithoutExtension(filePath);
                    saveDialog.DefaultExt = defaultExt; 
                    saveDialog.Filter = filter; 
                    saveDialog.FilterIndex = filterIndex; 
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads"; 

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        WebClient client = new WebClient();
                        client.DownloadFile(printRequestService._endpoint + filePath, savePath);

                        MessageBox.Show("File downloaded successfully!", "Success", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
