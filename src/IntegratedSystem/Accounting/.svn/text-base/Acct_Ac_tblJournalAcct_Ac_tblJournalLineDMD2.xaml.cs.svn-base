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
    public partial class Acct_Ac_tblJournalAcct_Ac_tblJournalLineDMD2 : Page
    {
        public int JournalId { get; set; }
        Security PageSecurity = new Security("Acct_Ac_tblJournalAcct_Ac_tblJournalLineDMD2");
        public Acct_Ac_tblJournalAcct_Ac_tblJournalLineDMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblJournalLineRadDetailsGrid.Columns;
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
            else if ((NavigationContext.QueryString.ContainsKey("Acct_Ac_tblJournalID"))) // Check to see if query string contains appropriate keys
            {              
                int temp;
                bool parse = int.TryParse(NavigationContext.QueryString["Acct_Ac_tblJournalID"].ToString(), out temp);
                if (parse)
                {
                    this.JournalId = temp;                    
                }
            }
            else
            {
                SystemSettings.Settings.NavigateToInvalidAcess(this.NavigationService, null, null);
            }
        }
        private void Acct_Ac_tblJournalLineRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            if (this.GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.SubmitChanges();
            }
            
        }

        #region DataSource Actions
        //-----------------------Save Delete And New Actions-----------------------------
        private void Acct_Ac_tblJournalLineRadDetailsGridSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.SubmitChanges();                
            }
        }

        
        private void Acct_Ac_tblJournalLineRadDetailsGridCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.CancelSubmit();
            }
        }
        private void Acct_Ac_tblJournalLineRadDetailsGridNewButton_Click(object sender, RoutedEventArgs e)
        {
            var newObj = Acct_Ac_tblJournalLineRadDetailsGrid.Items.AddNew() as Acct_Ac_tblJournalLine;
            newObj.ClientID = SystemSettings.Settings.GetClientId();
            newObj.Created = SystemSettings.Settings.ClientNow();
            newObj.CreatedBy = SystemSettings.Settings.GetUserID();
            newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
            newObj.Updated = SystemSettings.Settings.ClientNow();
            newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
            newObj.IsActive = true;
            //-----
            newObj.Acct_Ac_tblJournalID = this.JournalId;
        }
        private void Acct_Ac_tblJournalLineRadDetailsGridDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result= MessageBox.Show("آیا مطمئنید؟", "اخطار", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.DataView.Remove(GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournalQueryDataSource.DataView.CurrentItem);
            }
            else
                MessageBox.Show("عملیات با درخواست کاربر کنسل شد.");
        }
        #endregion//----------------------------------------------------------------------

    }
}
