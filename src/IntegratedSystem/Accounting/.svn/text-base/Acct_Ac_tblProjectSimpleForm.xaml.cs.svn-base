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
    public partial class Acct_Ac_tblProjectSimpleForm : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblProjectSimpleForm");
        public Acct_Ac_tblProjectSimpleForm()
        {
            this.DataContext = PageSecurity;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblProjectRadGrid.Columns;
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
        }


        private void Acct_Ac_tblProjectRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            if (this.GetAcct_Ac_tblProjectQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblProjectQueryDataSource.SubmitChanges();
            }
        }

        private void NewRecordButton_Click(object sender, RoutedEventArgs e)
        {
            var newObj= Acct_Ac_tblProjectRadGrid.Items.AddNew() as Acct_Ac_tblProject;
            newObj.IDProject = 1;
            newObj.CodeDoreh = 1;
            newObj.Acct_Ac_tblSherkathaID = SystemSettings.Settings.GetClientId(); 
            newObj.ClientID = SystemSettings.Settings.GetClientId();
            newObj.Created = SystemSettings.Settings.ClientNow();
            newObj.CreatedBy = SystemSettings.Settings.GetUserID();
            newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
            newObj.Updated = SystemSettings.Settings.ClientNow();
            newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
            newObj.IsActive = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblProjectQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblProjectQueryDataSource.SubmitChanges();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            GetAcct_Ac_tblProjectQueryDataSource.DataView.Remove(GetAcct_Ac_tblProjectQueryDataSource.DataView.CurrentItem);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblProjectQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblProjectQueryDataSource.CancelSubmit();
            }
        }

    }
}
