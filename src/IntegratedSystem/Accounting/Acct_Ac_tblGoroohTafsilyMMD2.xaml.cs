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
    public partial class Acct_Ac_tblGoroohTafsilyMMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblGoroohTafsilyMMD2");
        public Acct_Ac_tblGoroohTafsilyMMD2()
        {
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.Acct_Ac_tblGoroohTafsilyRadGrid.Columns;
foreach (var column in c)
{
    column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
}
//------------------------------

        }
          
#region ------ Navigate Action For Buttons------//
private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblGoroohTafsilyQueryDataSource.DataView.CurrentItem as Acct_Ac_tblGoroohTafsily;
   NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblGoroohTafsilyAcct_Ac_tblTafsilyDMD2?Acct_Ac_tblGoroohTafsilyID="+res.Acct_Ac_tblGoroohTafsilyID+"&DisplayName="+res.SharhGTafsily,
      UriKind.Relative));
}
#endregion

protected override void OnNavigatedTo(NavigationEventArgs e)
{
     if(PageSecurity.IsFormAccessValid == false)
           SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);
}

#region DataSource Actions
//-----------------------Save Delete And New Actions-----------------------------
private void Acct_Ac_tblGoroohTafsilyRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
   if (GetAcct_Ac_tblGoroohTafsilyQueryDataSource.HasChanges)
   {
        GetAcct_Ac_tblGoroohTafsilyQueryDataSource.SubmitChanges();
   }
}
private void Acct_Ac_tblGoroohTafsilyRadGridCancelButton_Click(object sender, RoutedEventArgs e)
{
        if (GetAcct_Ac_tblGoroohTafsilyQueryDataSource.HasChanges)
        {
                GetAcct_Ac_tblGoroohTafsilyQueryDataSource.CancelSubmit();
        }
}
private void Acct_Ac_tblGoroohTafsilyRadGridNewButton_Click(object sender, RoutedEventArgs e)
{
    var newObj= Acct_Ac_tblGoroohTafsilyRadGrid.Items.AddNew() as Acct_Ac_tblGoroohTafsily;
    newObj.ClientID = SystemSettings.Settings.GetClientId();
    newObj.Created = SystemSettings.Settings.ClientNow();
    newObj.CreatedBy = SystemSettings.Settings.GetUserID();
    newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
    newObj.Updated = SystemSettings.Settings.ClientNow();
    newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
    newObj.IsActive = true;
}
 private void Acct_Ac_tblGoroohTafsilyRadGridDelete_Click(object sender, RoutedEventArgs e)
{
                GetAcct_Ac_tblGoroohTafsilyQueryDataSource.DataView.Remove(GetAcct_Ac_tblGoroohTafsilyQueryDataSource.DataView.CurrentItem);
}
#endregion//----------------------------------------------------------------------
private void Acct_Ac_tblGoroohTafsilyRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
{
       if (this.GetAcct_Ac_tblGoroohTafsilyQueryDataSource.HasChanges)
       {
            GetAcct_Ac_tblGoroohTafsilyQueryDataSource.SubmitChanges();
       }
}

   }
}
