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


using IntegratedSystem.Web;
using Telerik.Windows.Controls;
namespace IntegratedSystem
{
    public partial class Acct_Ac_tblHesabKolMMD2 : Page
    {
        public int HesabGorohID { get; set; }
        public string DisplayName { get; set; }
        public string CodeGoroh { get; set; }

        Security PageSecurity = new Security("Acct_Ac_tblHesabKolMMD2");
        public Acct_Ac_tblHesabKolMMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblHesabKolRadGrid.Columns;
            foreach (var column in c)
            {
                column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
            }
            //------------------------------

        }
        #region Navigation Action


        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Acct_Ac_tblHesabKolMMD2?HesabGorohID=" + cur.Acct_Ac_tblHesabGorohID + "&CodeGoroh=" + cur.CodeGoroh + "&DisplayName=" + cur.SharhGroup,
            if (PageSecurity.IsFormAccessValid == false)
                SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);

            else if (NavigationContext.QueryString.ContainsKey("HesabGorohID") && NavigationContext.QueryString.ContainsKey("CodeGoroh") &&
                NavigationContext.QueryString.ContainsKey("DisplayName"))
            {
                int temp;
                bool parse = int.TryParse(NavigationContext.QueryString["HesabGorohID"].ToString(), out temp);
                if (parse)
                {
                    this.HesabGorohID = temp;
                    this.CodeGoroh = NavigationContext.QueryString["CodeGoroh"].ToString();
                    this.DisplayName = NavigationContext.QueryString["DisplayName"].ToString();
                }
            }
            else
            {
                SystemSettings.Settings.NavigateToInvalidAcess(this.NavigationService, null, null);
            }
        }

        #region DataSource Actions
        //-----------------------Save Delete And New Actions-----------------------------
        private void Acct_Ac_tblHesabKolRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.SubmitChanges();
            }
        }
        private void Acct_Ac_tblHesabKolRadGridCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.CancelSubmit();
            }
        }
       
        #endregion//----------------------------------------------------------------------

        private void Acct_Ac_tblHesabKolRadGridDelete_Click(object sender, RoutedEventArgs e)
        {
            GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.DataView.Remove(GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.DataView.CurrentItem);
        }

        private void ViewMoeenButton_Click(object sender, RoutedEventArgs e)
        {
            var cur = GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabKol;
            NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabMoeenMMD2?HesabKolID=" + cur.Acct_Ac_tblHesabKolID + "&CodeKol=" + cur.CodeKol + "&CodeGoroh=" + cur.CodeGoroh + "&DisplayName=" + cur.SharhCodeKol,
                       UriKind.Relative));
        }

        private void Acct_Ac_tblHesabKolRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            if (this.GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGorohQueryDataSource.SubmitChanges();
            }
        }
        private void NewRecordButton_Click(object sender, RoutedEventArgs e)
        {
            Acct_Ac_tblHesabKol newObj = Acct_Ac_tblHesabKolRadGrid.Items.AddNew() as Acct_Ac_tblHesabKol;
            newObj.Acct_Ac_tblHesabGorohID = HesabGorohID;
            newObj.CodeGoroh = CodeGoroh;
            newObj.ClientID = SystemSettings.Settings.GetClientId();
            newObj.Created = SystemSettings.Settings.ClientNow();
            newObj.CreatedBy = SystemSettings.Settings.GetUserID();
            newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
            newObj.Updated = SystemSettings.Settings.ClientNow();
            newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
            newObj.IsActive = true;
        //         public int HesabGorohID { get; set; }
        //public string DisplayName { get; set; }
        //public string CodeGoroh { get; set; }
        }

    }
}
