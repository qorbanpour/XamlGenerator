using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Telerik.Windows.Controls;
using IntegratedSystem.Web;
using System.ServiceModel.DomainServices.Client;
namespace IntegratedSystem
{
    public partial class Acct_Ac_tblJournalAcct_Ac_tblJournalAttachmentsDMD2 : Page
    {
        IntegratedSystemDomainContext ctx = new IntegratedSystemDomainContext();
        public int JournalID { get; set; }
        Security PageSecurity = new Security("Acct_Ac_tblJournalAcct_Ac_tblJournalAttachmentsDMD2");
        public Acct_Ac_tblJournalAcct_Ac_tblJournalAttachmentsDMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PageSecurity.IsFormAccessValid == false)
                SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);
            else if (NavigationContext.QueryString.ContainsKey("Acct_Ac_tblJournalID")) // Check to see if query string contains appropriate keys
            {
                int temp;
                bool parse= int.TryParse(NavigationContext.QueryString["Acct_Ac_tblJournalID"],out temp);
                if(parse)
                {
                    this.JournalID = temp;
                }
            }
            else
            {
                SystemSettings.Settings.NavigateToInvalidAcess(this.NavigationService, null, null);
            }
        }

        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "JPEG files (*.jpg)|*.jpg";//|GIF files (*.gif)|*.gif|All files (*.*)|*.*";
            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                
                //------- Checking file extention to allow only jepg file
                string extention= openFileDialog1.File.Extension;
                extention= extention.ToLower();
                if (!(extention == ".jpg" || extention== ".jpeg"))
                {
                    //MessageBox.Show(extention);
                    MessageBox.Show("فرمت فایل مورد قبول نیست.");
                    return;
                }
                UploadBusyIndicator.IsBusy = true;
                // Open the selected file to read.
                System.IO.Stream fileStream = openFileDialog1.File.OpenRead();
                byte[] bytes = new byte[fileStream.Length];
                int numBytesToRead = (int)fileStream.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to 10.
                    int n = fileStream.Read(bytes, numBytesRead, 1);
                    // The end of the file is reached.
                    if (n == 0)
                    {
                        break;
                    }
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                fileStream.Close();

                var attachment = new Acct_Ac_tblJournalAttachments();
                attachment.pic = bytes;
                attachment.Acct_Ac_tblJournalID = this.JournalID;
                attachment.ClientID = SystemSettings.Settings.GetClientId();
                attachment.Created = SystemSettings.Settings.ClientNow();
                attachment.CreatedBy = SystemSettings.Settings.GetUserID();
                attachment.OrganizationID = SystemSettings.Settings.GetOraganizationID();
                attachment.Updated = SystemSettings.Settings.ClientNow();
                attachment.UpdatedBy = SystemSettings.Settings.GetUserID();
                attachment.IsActive = true;


                ctx.Acct_Ac_tblJournalAttachments.Add(attachment);
                var t = ctx.SubmitChanges(OnSubmitCompleted, null);
           
            }
        }
        private void OnSubmitCompleted(SubmitOperation so)
        {
            UploadBusyIndicator.IsBusy = false;
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                MessageBox.Show("Submitted Successfully!");
                GetAcct_Ac_tblJournalAttachmentsByAcct_Ac_tblJournalQueryDataSource.Load();
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentItem = AttachmentListBox.SelectedItem as Acct_Ac_tblJournalAttachments;            
            //var ttttt=GetAcct_Ac_tblJournalAttachmentsByAcct_Ac_tblJournalQueryDataSource.DataView.AsQueryable();
            //var t = ctx.Load(ctx.GetTblImagesByIsQuery(1));
            //var tt = ctx.TblImages;
            //foreach (var item in tt)
            //{
            //    var Item = item as TblImage;
            //    var save= new SaveFileDialog();
            //    save.ShowDialog();
            //    break;
            //} 
            var SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "JPEG files (*.jpg)|*.jpg";//"JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*";

            bool? result = SaveDialog.ShowDialog();
            if (result == true)
            {
                System.IO.Stream fileStream = SaveDialog.OpenFile();
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                // System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fileStream);

                fileStream.Write(CurrentItem.pic, 0, CurrentItem.pic.Length);
                fileStream.Flush();
                fileStream.Close();
                // bw.Write
                //sw.WriteLine("Writing some text in the file.");
                // sw.Flush();
                // sw.Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var Result=MessageBox.Show("آیا مطئنید؟","اخطار",MessageBoxButton.OKCancel);
            if (Result == MessageBoxResult.OK)
            {
                var CurrentItem = AttachmentListBox.SelectedItem as Acct_Ac_tblJournalAttachments;
                GetAcct_Ac_tblJournalAttachmentsByAcct_Ac_tblJournalQueryDataSource.DataView.Remove(CurrentItem);
                GetAcct_Ac_tblJournalAttachmentsByAcct_Ac_tblJournalQueryDataSource.SubmitChanges();                
            }
            else
                MessageBox.Show("عملیات به درخواست کاربر لغو شد.");
        }

        private void ViewDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentItem = AttachmentListBox.SelectedItem as Acct_Ac_tblJournalAttachments;
            ViewAttachmentChildWindow childWindow = new ViewAttachmentChildWindow(CurrentItem);
            childWindow.Show();
        }



    }
}
