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
    public partial class Acct_Ac_tblJournalMMD2 : Page
    {
        Security PageSecurity = new Security("Acct_Ac_tblJournalMMD2");
        public Acct_Ac_tblJournalMMD2()
        {
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.Acct_Ac_tblJournalRadGrid.Columns;
foreach (var column in c)
{
    column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
}
//------------------------------

        }
          
#region ------ Navigate Action For Buttons------//
private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblJournalQueryDataSource.DataView.CurrentItem as Acct_Ac_tblJournal;
   NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblJournalAcct_Ac_tblJournalLineDMD2?Acct_Ac_tblJournalID="+res.Acct_Ac_tblJournalID,
      UriKind.Relative));
}
private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblJournalQueryDataSource.DataView.CurrentItem as Acct_Ac_tblJournal;
   NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblJournalAcct_Ac_tblJournalAttachmentsDMD2?Acct_Ac_tblJournalID="+res.Acct_Ac_tblJournalID,
      UriKind.Relative));
}
private void Button3_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblJournalQueryDataSource.DataView.CurrentItem as Acct_Ac_tblJournal;
   NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblJournalAcct_Ac_tblSharhKolySanadDMD2?Acct_Ac_tblJournalID="+res.Acct_Ac_tblJournalID,
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
private void Acct_Ac_tblJournalRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
   if (GetAcct_Ac_tblJournalQueryDataSource.HasChanges)
   {
        GetAcct_Ac_tblJournalQueryDataSource.SubmitChanges();
   }
}
private void Acct_Ac_tblJournalRadGridCancelButton_Click(object sender, RoutedEventArgs e)
{
        if (GetAcct_Ac_tblJournalQueryDataSource.HasChanges)
        {
                GetAcct_Ac_tblJournalQueryDataSource.CancelSubmit();
        }
}
private void Acct_Ac_tblJournalRadGridNewButton_Click(object sender, RoutedEventArgs e)
{
     var newObj = Acct_Ac_tblJournalRadGrid.Items.AddNew() as Acct_Ac_tblJournal ;
     newObj.ClientID = SystemSettings.Settings.GetClientId();
     newObj.Created = SystemSettings.Settings.ClientNow();
     newObj.CreatedBy = SystemSettings.Settings.GetUserID();
     newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
     newObj.Updated = SystemSettings.Settings.ClientNow();
     newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
     newObj.IsActive = true;
}
 private void Acct_Ac_tblJournalRadGridDelete_Click(object sender, RoutedEventArgs e)
{
                GetAcct_Ac_tblJournalQueryDataSource.DataView.Remove(GetAcct_Ac_tblJournalQueryDataSource.DataView.CurrentItem);
}
#endregion//----------------------------------------------------------------------
private void Acct_Ac_tblJournalRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
{
       if (this.GetAcct_Ac_tblJournalQueryDataSource.HasChanges)
       {
            GetAcct_Ac_tblJournalQueryDataSource.SubmitChanges();
       }
}

   }
}
