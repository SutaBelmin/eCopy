using Aspose.Words;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPPdf : Form
    {
        private string tempPdfFilePath;
        public APIServ printRequestService = new APIServ("PrintRequest");

        string tempFilePath;
        string tempSaveFilePath;

        string filePath;
        public frmPPdf(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
            pdfViewer1.CanPrint= false;
        }

        private void frmPPdf_Load(object sender, EventArgs e)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".docx")
            {
                tempFilePath = Path.GetTempFileName() + ".docx";
                tempSaveFilePath = Path.GetTempFileName() + ".pdf";

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(printRequestService._endpoint + filePath, tempFilePath);
                }

                Document doc = new Document(tempFilePath);
                doc.Save(tempSaveFilePath);
                if (File.Exists(tempSaveFilePath))
                {
                    pdfViewer1.LoadFromFile(tempSaveFilePath);
                }
                else
                {
                    MessageBox.Show("Failed to download or load the .docx file.");
                }
            }
            else if (extension == ".doc")
            {
                tempFilePath = Path.GetTempFileName() + ".doc";
                tempSaveFilePath = Path.GetTempFileName() + ".pdf";

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(printRequestService._endpoint + filePath, tempFilePath);
                }

                Document doc = new Document(tempFilePath);
                doc.Save(tempSaveFilePath);
                if (File.Exists(tempSaveFilePath))
                {
                    pdfViewer1.LoadFromFile(tempSaveFilePath);
                }
                else
                {
                    MessageBox.Show("Failed to download or load the .doc file.");
                }
            }
            else if (extension == ".pdf")
            {
                tempPdfFilePath = Path.GetTempFileName() + ".pdf";

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(printRequestService._endpoint + filePath, tempPdfFilePath);
                }

                if (File.Exists(tempPdfFilePath))
                {
                    pdfViewer1.LoadFromFile(tempPdfFilePath);
                }
                else
                {
                    MessageBox.Show("Failed to download or load the PDF file.");
                }
            }

        }

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(tempPdfFilePath) && File.Exists(tempPdfFilePath) ||
                !string.IsNullOrEmpty(tempFilePath) && File.Exists(tempFilePath) ||
                    !string.IsNullOrEmpty(tempSaveFilePath) && File.Exists(tempSaveFilePath))
            {
                File.Delete(tempPdfFilePath);
                File.Delete(tempFilePath);
                File.Delete(tempSaveFilePath);
            }
        }
    }
}
