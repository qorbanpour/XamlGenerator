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
    public partial class Acct_Ac_tblGoroohMarakezMMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblGoroohMarakezMMD2");
        public Acct_Ac_tblGoroohMarakezMMD2()
        {
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.Acct_Ac_tblGoroohMarakezRadGrid.Columns;
foreach (var column in c)
{
column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
}
//------------------------------

        }

protected override void OnNavigatedTo(NavigationEventArgs e)
{
     if(PageSecurity.IsFormAccessValid == false)
           SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);
}

#region DataSource Actions
//-----------------------Save Delete And New Actions-----------------------------
private void Acct_Ac_tblGoroohMarakezRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
   if (GetAcct_Ac_tblGoroohMarakezQueryDataSource.HasChanges)
   {       
       GetAcct_Ac_tblGoroohMarakezQueryDataSource.SubmitChanges();
   }
}
private void Acct_Ac_tblGoroohMarakezRadGridCancelButton_Click(object sender, RoutedEventArgs e)
{
        if (GetAcct_Ac_tblGoroohMarakezQueryDataSource.HasChanges)
        {
                GetAcct_Ac_tblGoroohMarakezQueryDataSource.CancelSubmit();
        }
}
private void Acct_Ac_tblGoroohMarakezRadGridNewButton_Click(object sender, RoutedEventArgs e)
{
    var newObj= Acct_Ac_tblGoroohMarakezRadGrid.Items.AddNew() as Acct_Ac_tblGoroohMarakez;
    newObj.ClientID = SystemSettings.Settings.GetClientId();
    newObj.Created = SystemSettings.Settings.ClientNow();
    newObj.CreatedBy = SystemSettings.Settings.GetUserID();
    newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
    newObj.Updated = SystemSettings.Settings.ClientNow();
    newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
    newObj.IsActive = true;
}
#endregion//----------------------------------------------------------------------

private void ViewHesabMarakezButton_Click(object sender, RoutedEventArgs e)
{
    var Cur = GetAcct_Ac_tblGoroohMarakezQueryDataSource.DataView.CurrentItem as Acct_Ac_tblGoroohMarakez;
    NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblGoroohMarakezAcct_Ac_tblHesabMarakezDMD2?GoroohMarakezID=" + Cur.Acct_Ac_tblGoroohMarakezID + "&DisplayName=" + Cur.SharhGMarkaz, UriKind.Relative));
}

private void NewRecordButton_Click(object sender, RoutedEventArgs e)
{
    Acct_Ac_tblGoroohMarakez newObj=Acct_Ac_tblGoroohMarakezRadGrid.Items.AddNew() as Acct_Ac_tblGoroohMarakez;
    newObj.Acct_Ac_tblSherkathaID = SystemSettings.Settings.GetClientId();
    newObj.ClientID = SystemSettings.Settings.GetClientId();
    newObj.Created = SystemSettings.Settings.ClientNow();
    newObj.CreatedBy = SystemSettings.Settings.GetUserID();
    
}

private void HazfButton_Click(object sender, RoutedEventArgs e)
{
    GetAcct_Ac_tblGoroohMarakezQueryDataSource.DataView.Remove(GetAcct_Ac_tblGoroohMarakezQueryDataSource.DataView.CurrentItem);
}

   }
}
