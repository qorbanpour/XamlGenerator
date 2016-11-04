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
    public partial class Acct_Ac_tblHesabGorohMMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblHesabGorohMMD2");
        public Acct_Ac_tblHesabGorohMMD2()
        {
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblHesabGorohRadGrid.Columns;
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
            if (PageSecurity.IsFormAccessValid == false)
                SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);
        }

        #region DataSource Actions
        //-----------------------Save Delete And New Actions-----------------------------
        private void Acct_Ac_tblHesabGorohRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabGorohQueryDataSource.SubmitChanges();
            }
        }
        private void Acct_Ac_tblHesabGorohRadGridCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabGorohQueryDataSource.CancelSubmit();
            }
        }
        private void Acct_Ac_tblHesabGorohRadGridNewButton_Click(object sender, RoutedEventArgs e)
        {
            Acct_Ac_tblHesabGorohRadGrid.Items.AddNew();
        }
        #endregion//----------------------------------------------------------------------


        private void ViewHesabKolButton_Click(object sender, RoutedEventArgs e)
        {
            var cur = GetAcct_Ac_tblHesabGorohQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabGoroh;
            NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabKolMMD2?HesabGorohID=" + cur.Acct_Ac_tblHesabGorohID + "&CodeGoroh=" + cur.CodeGoroh + "&DisplayName=" + cur.SharhGroup,
                       UriKind.Relative));
        }


        //------ Navigate Action For Buttons------//
        private void GridSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabGorohQueryDataSource.SubmitChanges();
            }
        }
        private void GridCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabGorohQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabGorohQueryDataSource.CancelSubmit();
            }
        }

        private void NewRecordButton_Click(object sender, RoutedEventArgs e)
        {
             Acct_Ac_tblHesabGoroh newObj = Acct_Ac_tblHesabGorohRadGrid.Items.AddNew() as Acct_Ac_tblHesabGoroh;
             newObj.ClientID = SystemSettings.Settings.GetClientId();
             newObj.Created = SystemSettings.Settings.ClientNow();
             newObj.CreatedBy = SystemSettings.Settings.GetUserID();
             newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
             newObj.Updated = SystemSettings.Settings.ClientNow();
             newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
             newObj.IsActive = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            GetAcct_Ac_tblHesabGorohQueryDataSource.DataView.Remove(GetAcct_Ac_tblHesabGorohQueryDataSource.DataView.CurrentItem);
        }


    }
}
