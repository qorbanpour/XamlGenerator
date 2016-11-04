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
namespace IntegratedSystem
{
    public partial class Acct_Ac_tblHesabTafsilyAcct_Ac_tblHesabTafsilyMarakezDMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblHesabTafsilyAcct_Ac_tblHesabTafsilyMarakezDMD2");
        public int HesabTafsilyID { get; set; }
        public string DisplayName { get; set; }
        public Acct_Ac_tblHesabTafsilyAcct_Ac_tblHesabTafsilyMarakezDMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblHesabTafsilyMarakezRadDetailsGrid.Columns;
            foreach (var column in c)
            {
                column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
            }
            //------------------------------

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PageSecurity.IsFormAccessValid == false)
                SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);
            else if (NavigationContext.QueryString.ContainsKey("Acct_Ac_tblHesabTafsilyID")) //NavigationService.Navigate(new Uri("/Acct_Ac_tblHesabTafsilyAcct_Ac_tblHesabTafsilyMarakezDMD2?Acct_Ac_tblHesabTafsilyID="+res.Acct_Ac_tblHesabTafsilyID+"&DisplayName="+res.SharhCodeTafsily,
            {
                int temp;
                bool parse = int.TryParse(NavigationContext.QueryString["Acct_Ac_tblHesabTafsilyID"],out temp);
                if (parse)
                {
                    HesabTafsilyID = temp;
                    this.DisplayName = NavigationContext.QueryString["DisplayName"];
                }

            }
            else
            {
                SystemSettings.Settings.NavigateToInvalidAcess(this.NavigationService, null, null);
            }

        }

        private void Acct_Ac_tblHesabTafsilyMarakezRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            if (this.GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.SubmitChanges();
            }
        }

        
        private void GoroohMarakezComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.AutoLoad = true;
        }
        private void EntesabButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItems = Acct_Ac_tblHesabMarakezRadDetailsGrid.SelectedItems;
            foreach (var Item in SelectedItems)
            {
                var item = Item as Acct_Ac_tblHesabMarakez;
                var newObj = Acct_Ac_tblHesabTafsilyMarakezRadDetailsGrid.Items.AddNew() as Acct_Ac_tblHesabTafsilyMarakez;
                //newObj.CodeSherkat = item.CodeSherkat;
                newObj.NoeMarkaz = short.Parse(item.NoeMarkaz.ToString());
                newObj.ClientID = SystemSettings.Settings.GetClientId();
                newObj.Created = SystemSettings.Settings.ClientNow();
                newObj.CreatedBy = SystemSettings.Settings.GetUserID();
                newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
                newObj.Updated = SystemSettings.Settings.ClientNow();
                newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
                newObj.IsActive = true;

            }
        }

        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.SubmitChanges();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.DataView.Remove(GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.DataView.CurrentItem);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsilyQueryDataSource.CancelSubmit();
            }
        }

        
    }
}
