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
    public partial class Acct_Ac_tblGoroohMarakezAcct_Ac_tblHesabMarakezDMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblGoroohMarakezAcct_Ac_tblHesabMarakezDMD2");
        public int GoroohMarakezID { get; set; }
        public string DisplayName { get; set; }
        public Acct_Ac_tblGoroohMarakezAcct_Ac_tblHesabMarakezDMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
            //---Binding GridView Visibility
            GridViewColumnCollection c = this.Acct_Ac_tblHesabMarakezRadDetailsGrid.Columns;
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
            else if (NavigationContext.QueryString.ContainsKey("GoroohMarakezID")  
                && NavigationContext.QueryString.ContainsKey("DisplayName"))
            {
                int temp;
                bool parse = int.TryParse(NavigationContext.QueryString["GoroohMarakezID"].ToString(), out temp);
                if (parse)
                {

                    this.GoroohMarakezID = temp;
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
        private void Acct_Ac_tblHesabMarakezRadDetailsGridSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.SubmitChanges();
            }
        }
        private void Acct_Ac_tblHesabMarakezRadDetailsGridCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.HasChanges)
            {
                GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.CancelSubmit();
            }
        }
        private void Acct_Ac_tblHesabMarakezRadDetailsGridNewButton_Click(object sender, RoutedEventArgs e)
        {
            Acct_Ac_tblHesabMarakez newObj= Acct_Ac_tblHesabMarakezRadDetailsGrid.Items.AddNew() as Acct_Ac_tblHesabMarakez;
            newObj.Acct_Ac_tblGoroohMarakezID = GoroohMarakezID;
            newObj.ClientID = SystemSettings.Settings.GetClientId();
            newObj.Created = SystemSettings.Settings.ClientNow();
            newObj.CreatedBy = SystemSettings.Settings.GetUserID();
            newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
            newObj.Updated = SystemSettings.Settings.ClientNow();
            newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
            newObj.IsActive = true;
            
        }

        

        private void Acct_Ac_tblHesabMarakezRadDetailsGridDelete_Click(object sender, RoutedEventArgs e)
        {
            GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.DataView.Remove((GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakezQueryDataSource.DataView.CurrentItem));
        }

        #endregion//----------------------------------------------------------------------

    }
}
