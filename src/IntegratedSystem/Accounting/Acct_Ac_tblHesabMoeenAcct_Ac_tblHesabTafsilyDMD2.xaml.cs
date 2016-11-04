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
using System.Collections.ObjectModel;
namespace IntegratedSystem
{
    public partial class Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2 : Page
    {

        public int HesabMoeenID { get; set; }
        public string CodeKol { get; set; }
        public string CodeGoroh { get; set; }
        public string CodeMoeen { get; set; }
        public string DisplayName { get; set; }

        Security PageSecurity = new Security("Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2");
        public Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblHesabTafsilyRadDetailsGrid.Columns;
            foreach (var column in c)
            {
                column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
            }
            //------------------------------


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*NavigationService.Navigate(new Uri("/Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2?HesabMoeenID=" + Cur.Acct_Ac_tblHesabMoeenID+
             * "&CodeKol="+Cur.CodeKol+
             * "&CodeGoroh="+Cur.CodeGoroh+
             * "&CodeMoeen="+Cur.CodeMoeen+
             * "&DisplayName="+Cur.NameMoeen, UriKind.Relative));
            */
            if (PageSecurity.IsFormAccessValid == false)
                SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);

            else if (NavigationContext.QueryString.ContainsKey("HesabMoeenID") && NavigationContext.QueryString.ContainsKey("CodeKol") &&
                NavigationContext.QueryString.ContainsKey("CodeGoroh") && NavigationContext.QueryString.ContainsKey("CodeMoeen")
                && NavigationContext.QueryString.ContainsKey("DisplayName"))
            {
                int temp;
                bool parse = int.TryParse(NavigationContext.QueryString["HesabMoeenID"].ToString(), out temp);
                if (parse)
                {
                    
                    this.HesabMoeenID = temp;                    
                    this.CodeKol = NavigationContext.QueryString["CodeKol"].ToString();
                    this.CodeGoroh = NavigationContext.QueryString["CodeGoroh"].ToString();
                    this.CodeMoeen = NavigationContext.QueryString["CodeMoeen"].ToString();
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
        private void Acct_Ac_tblHesabTafsilyRadDetailsGridSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.SubmitChanges();
            }
        }
        private void Acct_Ac_tblHesabTafsilyRadDetailsGridCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.CancelSubmit();
            }
        }

        #endregion//----------------------------------------------------------------------
        private void TafsilyComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            GetAcct_Ac_tblTafsilyByAcct_Ac_tblGoroohTafsilyDataSource.AutoLoad = true;

        }
        private void EntesabButton_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(newObj == null ? "Null" : "Not Null");
            
            var SelectedItems = TafsilyListBox.SelectedItems;
            foreach (var item in SelectedItems)
            {
                Acct_Ac_tblHesabTafsily newObj = Acct_Ac_tblHesabTafsilyRadDetailsGrid.Items.AddNew() as Acct_Ac_tblHesabTafsily;     
                
                newObj.Acct_Ac_tblHesabMoeenID = HesabMoeenID;
                newObj.Acct_Ac_tblTafsilyID = (item as Acct_Ac_tblTafsily).Acct_Ac_tblTafsilyID;
                //newObj.CodeSherkat = SystemSettings.Settings.GetClientId();
                newObj.CodeGoroh = CodeGoroh;
                newObj.CodeKol = CodeKol;
                newObj.CodeMoeen = CodeMoeen;
                newObj.CodeTafsily = (item as Acct_Ac_tblTafsily).CodeTafsily;
                newObj.ClientID = SystemSettings.Settings.GetClientId();
                newObj.Created = SystemSettings.Settings.ClientNow();
                newObj.CreatedBy = SystemSettings.Settings.GetUserID();
                newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
                newObj.Updated = SystemSettings.Settings.ClientNow();
                newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
                newObj.IsActive = true;
            }
        }
        private void HazfButton_Click(object sender, RoutedEventArgs e)
        {
            GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.DataView.Remove((GetAcct_Ac_tblGoroohTafsilyDataSource.DataView.CurrentItem));
        }
        private void EmalButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeenQueryDataSource.SubmitChanges();
            }
        }

    }

}
