using Aspose.Words;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;



namespace eCopy.Desktop
{
    public partial class frmPSettings : Form
    {
        private PRDGridModel model;
        private List<Status> status;
        public APIServ printRequestService = new APIServ("PrintRequest");

        public APIServ printPageOptService = new APIServ("PrintPageOpt");
        public APIServ sidePrintOptService = new APIServ("Side");
        public APIServ orientationService = new APIServ("Orientation");
        public APIServ letterService = new APIServ("Letter");
        public APIServ pagePSService = new APIServ("PagePerSheet");
        public APIServ collatedService = new APIServ("Collated");

        string tempFilePath;
        string tempSaveFilePath;
        string finalPath;
        string _collated;
        string _letter;
        string _orientation;
        string _sidePrintOption;
        string filePath;
        public frmPSettings(PRDGridModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void frmPSettings_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private async void loadData()
        {
            var printSettings = await printRequestService.GetById<PrintRequestR>(model.ID);
            filePath = printSettings.FilePath;

            this.status = StatusStateMachine.GetState(Enum.TryParse<Status>(model.Status, out var s) ? s : Status.New);

            loadStatus();

            if (printSettings.Comment == null || printSettings.Comment == "null")
            {
                txtComment.Text = "";
            }
            else
            {
                txtComment.Text = printSettings.Comment;
            }

            var printOptionP = await printPageOptService.GetById<PrintPageOptionResponse>(printSettings.PrintPageOptionId);
            txtPrintPO.Text = printOptionP.Name;

            var sidePrintOpt = await sidePrintOptService.GetById<SideResponse>(printSettings.SidePrintOptionId);
            txtSidePO.Text = sidePrintOpt.Name;

            var orien = await orientationService.GetById<OrientationResponse>(printSettings.OrientationId);
            txtOrie.Text = orien.Name;

            var lett = await letterService.GetById<LetterResponse>(printSettings.LetterId);
            txtLett.Text = lett.Name;

            var pps = await pagePSService.GetById<PagePerSheetResponse>(printSettings.PagePerSheetId);
            txtPagePS.Text = pps.Name;

            var coll = await collatedService.GetById<CollatedResponse>(printSettings.CollatedPrintOptionId);
            txtColl.Text = coll.Name;

            cmbSt.SelectedIndex = status.IndexOf((Status)Enum.Parse(typeof(Status), model.Status));

            if (printSettings.PaymentInfo != null)
            {
                txtPayment.Text = printSettings.PaymentInfo.StripePaymentId;
            }
            else
            {
                txtPayment.Text = "Request hasn't been paid yet";
            }

            _sidePrintOption = sidePrintOpt.Name;
            _orientation = orien.Name;
            _letter = lett.Name;
            _collated = coll.Name;

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

            await printRequestService.Put<PrintRequestR>(model.ID, new PrintRequestUpdate
            {
                Status = (Status)cmbSt.SelectedValue,
                Comment = txtComment.Text
            });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (model.ID < 8)
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
                    string filter = "Word Documents (*.docx)|*.docx|PDF Files (*.pdf)|*.pdf|Word Documents (*.doc)|*.doc|All Files (*.*)|*.*";
                    int filterIndex = 1;

                    if (!string.IsNullOrEmpty(extension))
                    {
                        if (extension == ".docx")
                        {
                            defaultExt = extension;
                            filterIndex = 1;
                        }
                        else if (extension == ".pdf")
                        {
                            defaultExt = extension;
                            filterIndex = 2;
                        }
                        else if (extension == ".doc")
                        {
                            defaultExt = extension;
                            filterIndex = 3;
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

        private void btnPreviewPrnt_Click(object sender, EventArgs e)
        {
            if (model.ID < 8)
            {
                MessageBox.Show("This is a test request so it has no file for print or preview.\n " +
                    "Please choose a request that contains a file (Id > 7)", "Message",
                    MessageBoxButtons.OK);
                return;
            }

            Thread loadingThread = new Thread(() =>
            {
                using (frmLoading loadingScreen = new frmLoading())
                {
                    loadingScreen.ShowDialog();
                }
            });

            loadingThread.Start();

            frmPPdf frm = new frmPPdf(filePath);

            frm.Shown += (s, args) =>
            {
                loadingThread.Abort(); 
            };

            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (model.ID < 8)
                {
                    MessageBox.Show("This is a test request so it has no file for print or preview.\n " +
                        "Please choose a request that contains a file (Id > 7)", "Message",
                        MessageBoxButtons.OK);
                    return;
                }

                string tempPdfFilePath = Path.GetTempFileName() + ".pdf";

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
                    finalPath = tempSaveFilePath;
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
                    finalPath = tempSaveFilePath;
                }
                else if (extension == ".pdf")
                {
                    tempPdfFilePath = Path.GetTempFileName() + ".pdf";

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(printRequestService._endpoint + filePath, tempPdfFilePath);
                    }
                    finalPath = tempPdfFilePath;
                }
                else
                {
                    MessageBox.Show("Unsupported file format. Only .docx, .doc and .pdf are supported.");
                    return;
                }

               
                using (var document = PdfDocument.Load(finalPath))
                {
                    using (PrintDialog printDialog = new PrintDialog())
                    {
                        printDialog.PrinterSettings.Copies = 1;
                        printDialog.PrinterSettings.PrintFileName = filePath;

                        if (_collated.ToLower() == "collated" || _collated.ToLower() == "collate")
                            printDialog.PrinterSettings.Collate = true;
                        else
                            printDialog.PrinterSettings.Collate = false;

                        if (_sidePrintOption.ToLower() == "printonesided" || _sidePrintOption.ToLower() == "printoneside")
                        {
                            printDialog.PrinterSettings.Duplex = Duplex.Simplex;
                        }
                        else if (printDialog.PrinterSettings.CanDuplex)
                        {
                            if (_sidePrintOption.ToLower() == "printbothsides")
                            {
                                printDialog.PrinterSettings.Duplex = Duplex.Horizontal;
                            }
                            else
                            {
                                MessageBox.Show("This printer does not support this side setting");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("This printer does not support automatic duplex printing");
                            return;
                        }

                        System.Drawing.Printing.PaperSize A0size =
                            new System.Drawing.Printing.PaperSize("A0", 3311, 4681);

                        System.Drawing.Printing.PaperSize A1size =
                            new System.Drawing.Printing.PaperSize("A1", 2339, 3311);

                        System.Drawing.Printing.PaperSize A2size =
                            new System.Drawing.Printing.PaperSize("A2", 1654, 2339);

                        System.Drawing.Printing.PaperSize A3size =
                            new System.Drawing.Printing.PaperSize("A3", 1169, 1654);

                        System.Drawing.Printing.PaperSize A4size =
                            new System.Drawing.Printing.PaperSize("A4", 827, 1169);

                        System.Drawing.Printing.PaperSize A5size =
                            new System.Drawing.Printing.PaperSize("A5", 583, 827);

                        System.Drawing.Printing.PaperSize A6size =
                            new System.Drawing.Printing.PaperSize("A6", 413, 583);

                        System.Drawing.Printing.PaperSize A7size =
                            new System.Drawing.Printing.PaperSize("A7", 291, 413);

                        System.Drawing.Printing.PaperSize A8size =
                            new System.Drawing.Printing.PaperSize("A8", 205, 291);

                        System.Drawing.Printing.PaperSize A9size =
                            new System.Drawing.Printing.PaperSize("A9", 146, 205);

                        System.Drawing.Printing.PaperSize A10size =
                            new System.Drawing.Printing.PaperSize("A10", 102, 146);

                        try
                        {
                            if (_letter.ToLower() == "a4")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A4size;
                            }
                            else if (_letter.ToLower() == "a5")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A5size;
                            }
                            else if (_letter.ToLower() == "a0")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A0size;
                            }
                            else if (_letter.ToLower() == "a1")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A1size;
                            }
                            else if (_letter.ToLower() == "a2")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A2size;
                            }
                            else if (_letter.ToLower() == "a3")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A3size;
                            }
                            else if (_letter.ToLower() == "a6")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A6size;
                            }
                            else if (_letter.ToLower() == "a7")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A7size;
                            }
                            else if (_letter.ToLower() == "a8")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A8size;
                            }
                            else if (_letter.ToLower() == "a9")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A9size;
                            }
                            else if (_letter.ToLower() == "a10")
                            {
                                printDialog.PrinterSettings.DefaultPageSettings.PaperSize = A10size;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Printer does not support this letter option");
                        }

                        if (_orientation.ToLower() == "landscape")
                            printDialog.PrinterSettings.DefaultPageSettings.Landscape = true;
                        else
                            printDialog.PrinterSettings.DefaultPageSettings.Landscape = false;


                        printDialog.AllowSomePages = true;
                        printDialog.AllowSelection = true;
                        
                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {

                            using (var printDocument = document.CreatePrintDocument())
                            {
                                printDocument.PrinterSettings = printDialog.PrinterSettings;
                                printDocument.DocumentName = filePath;
                                printDocument.PrintController = new StandardPrintController();
                                printDocument.Print();
                            }

                        }
                    }
                }
                File.Delete(finalPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
