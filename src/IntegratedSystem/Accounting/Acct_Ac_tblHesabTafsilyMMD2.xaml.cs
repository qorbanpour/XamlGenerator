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
    public partial class Acct_Ac_tblHesabTafsilyMMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblHesabTafsilyMMD2");
        public Acct_Ac_tblHesabTafsilyMMD2()
        {
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.Acct_Ac_tblHesabTafsilyRadGrid.Columns;
foreach (var column in c)
{
    column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
}
//------------------------------

        }
          
#region ------ Navigate Action For Buttons------//
private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblHesabTafsilyQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabTafsily;
   NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabTafsilyAcct_Ac_tblHesabRizMarakezDMD2?Acct_Ac_tblHesabTafsilyID=" + res.Acct_Ac_tblHesabTafsilyID,
      UriKind.Relative));
}
private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblHesabTafsilyQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabTafsily;
   NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabTafsilyAcct_Ac_tblHesabTafsilyMarakezDMD2?Acct_Ac_tblHesabTafsilyID=" + res.Acct_Ac_tblHesabTafsilyID + "&DisplayName=" + res.SharhCodeTafsily,
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
private void Acct_Ac_tblHesabTafsilyRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
   if (GetAcct_Ac_tblHesabTafsilyQueryDataSource.HasChanges)
   {
        GetAcct_Ac_tblHesabTafsilyQueryDataSource.SubmitChanges();
   }
}
private void Acct_Ac_tblHesabTafsilyRadGridCancelButton_Click(object sender, RoutedEventArgs e)
{
        if (GetAcct_Ac_tblHesabTafsilyQueryDataSource.HasChanges)
        {
                GetAcct_Ac_tblHesabTafsilyQueryDataSource.CancelSubmit();
        }
}
private void Acct_Ac_tblHesabTafsilyRadGridNewButton_Click(object sender, RoutedEventArgs e)
{
    var newObj= Acct_Ac_tblHesabTafsilyRadGrid.Items.AddNew() as Acct_Ac_tblHesabTafsily;
    newObj.ClientID = SystemSettings.Settings.GetClientId();
    newObj.Created = SystemSettings.Settings.ClientNow();
    newObj.CreatedBy = SystemSettings.Settings.GetUserID();
    newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
    newObj.Updated = SystemSettings.Settings.ClientNow();
    newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
    newObj.IsActive = true;
}
 private void Acct_Ac_tblHesabTafsilyRadGridDelete_Click(object sender, RoutedEventArgs e)
{
                GetAcct_Ac_tblHesabTafsilyQueryDataSource.DataView.Remove(GetAcct_Ac_tblHesabTafsilyQueryDataSource.DataView.CurrentItem);
}
#endregion//----------------------------------------------------------------------
private void Acct_Ac_tblHesabTafsilyRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
{
       if (this.GetAcct_Ac_tblHesabTafsilyQueryDataSource.HasChanges)
       {
            GetAcct_Ac_tblHesabTafsilyQueryDataSource.SubmitChanges();
       }
}

   }
}
