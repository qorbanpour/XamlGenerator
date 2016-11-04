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
    public partial class Acct_Ac_tblHesabMoeenMMD2 : Page
    {
        public int HesabKolID { get; set; }
        public string CodeGoroh { get; set; }
        public string DisplayName { get; set; }
        public string CodeKol { get; set; }
        Security PageSecurity = new Security("Acct_Ac_tblHesabMoeenMMD2");
        public Acct_Ac_tblHesabMoeenMMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.Acct_Ac_tblHesabMoeenRadGrid.Columns;
foreach (var column in c)
{
column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());
}
//------------------------------

        }
          #region Navigation Action
//------ Navigate Action For Buttons------//
private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
{
   var res = this.GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
   NavigationService.Navigate(new Uri("Acct_Ac_tblHesabMoeenAcct_Ac_tblAfradDMD2.xaml?Acct_Ac_tblHesabMoeenID="+res.Acct_Ac_tblHesabMoeenID,
      UriKind.Relative));
}
private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
{
    var res = this.GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
   NavigationService.Navigate(new Uri("Acct_Ac_tblHesabMoeenAcct_Ac_tblAnvaeTafsily_MoeenDMD2.xaml?Acct_Ac_tblHesabMoeenID="+res.Acct_Ac_tblHesabMoeenID,
      UriKind.Relative));
}
private void Button3_Click(object sender, System.Windows.RoutedEventArgs e)
{
    var res = this.GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
   NavigationService.Navigate(new Uri("Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabhaDMD2.xaml?Acct_Ac_tblHesabMoeenID="+res.Acct_Ac_tblHesabMoeenID,
      UriKind.Relative));
}
private void Button4_Click(object sender, System.Windows.RoutedEventArgs e)
{
    var res = this.GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
   NavigationService.Navigate(new Uri("Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2.xaml?Acct_Ac_tblHesabMoeenID="+res.Acct_Ac_tblHesabMoeenID,
      UriKind.Relative));
}
private void Button5_Click(object sender, System.Windows.RoutedEventArgs e)
{
    var res = this.GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
   NavigationService.Navigate(new Uri("Acct_Ac_tblHesabMoeenAcct_Ac_tblSanadHesabdaryDMD2.xaml?Acct_Ac_tblHesabMoeenID="+res.Acct_Ac_tblHesabMoeenID,
      UriKind.Relative));
}
private void Button6_Click(object sender, System.Windows.RoutedEventArgs e)
{
    var res = this.GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
   NavigationService.Navigate(new Uri("Acct_Ac_tblHesabMoeenAcct_Ac_tblSandoghhaDMD2.xaml?Acct_Ac_tblHesabMoeenID="+res.Acct_Ac_tblHesabMoeenID,
      UriKind.Relative));
}
//-------------------------------------------------------------//
#endregion

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    //NavigationService.Navigate(new Uri("/Acct_Ac_tblHesabMoeenMMD2?HesabKolID=" + cur.Acct_Ac_tblHesabKolID +"&CodeKol"+cur.CodeKol+"&CodeGoroh"+cur.CodeGoroh+"&DisplayName=" + cur.SharhCodeKol,

    if (PageSecurity.IsFormAccessValid == false)
        SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);

    else if (NavigationContext.QueryString.ContainsKey("HesabKolID") && NavigationContext.QueryString.ContainsKey("CodeGoroh") &&
        NavigationContext.QueryString.ContainsKey("DisplayName") && NavigationContext.QueryString.ContainsKey("CodeKol"))
    {
        int temp;
        bool parse = int.TryParse(NavigationContext.QueryString["HesabKolID"].ToString(), out temp);
        if (parse)
        {
            this.HesabKolID = temp;
            this.CodeGoroh = NavigationContext.QueryString["CodeGoroh"].ToString();
            this.DisplayName = NavigationContext.QueryString["DisplayName"].ToString();
            this.CodeKol = NavigationContext.QueryString["CodeKol"].ToString();
        }
    }
    else
    {
        SystemSettings.Settings.NavigateToInvalidAcess(this.NavigationService, null, null);
    }    


}
private void ViewTafzilyButton_Click(object sender, RoutedEventArgs e)
{
                                                                                    // bas code gorooh  code kol code moenn ro beferesti
                                                                                    //Sahand: sherkatam ke dasti felan 1 bezar
                                                                                    //Sahand: ta dorostesh konam
                                                                                    //Sahand: id moeen ham ke masteridye bas pass she
                                                                                    //Sahand: hamintor sharhe moeeno
                                                                                    //Sahand: ke display memeberesh hast
    var Cur = GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
    NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2?HesabMoeenID=" + Cur.Acct_Ac_tblHesabMoeenID + "&CodeKol=" + Cur.CodeKol + "&CodeGoroh=" + Cur.CodeGoroh + "&CodeMoeen=" + Cur.CodeMoeen + "&DisplayName=" + Cur.NameMoeen, UriKind.Relative));
}

#region DataSource Actions
//-----------------------Save Delete And New Actions-----------------------------
private void Acct_Ac_tblHesabMoeenRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
    if (GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.HasChanges)
   {
       GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.SubmitChanges();
   }
}
private void Acct_Ac_tblHesabMoeenRadGridDeleteButton_Click(object sender, RoutedEventArgs e)
{


    GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.Remove(GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.DataView.CurrentItem);
    
}
private void Acct_Ac_tblHesabMoeenRadGridCancelButton_Click(object sender, RoutedEventArgs e)
{
    if (GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.HasChanges)
        {
            GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKolQueryDataSource.CancelSubmit();
        }
}
private void Acct_Ac_tblHesabMoeenRadGridNewButton_Click(object sender, RoutedEventArgs e)
{
    Acct_Ac_tblHesabMoeenRadGrid.Items.AddNew();
}
#endregion//----------------------------------------------------------------------

private void NewRecordButton_Click(object sender, RoutedEventArgs e)
{
    Acct_Ac_tblHesabMoeen newObj = Acct_Ac_tblHesabMoeenRadGrid.Items.AddNew() as Acct_Ac_tblHesabMoeen;
    newObj.Acct_Ac_tblHesabKolID =HesabKolID;
    newObj.CodeGoroh = CodeGoroh;
    newObj.CodeKol = CodeKol;
    newObj.ClientID = SystemSettings.Settings.GetClientId();
    newObj.Created = SystemSettings.Settings.ClientNow();
    newObj.CreatedBy = SystemSettings.Settings.GetUserID();
    newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();
    newObj.Updated = SystemSettings.Settings.ClientNow();
    newObj.UpdatedBy = SystemSettings.Settings.GetUserID();
    newObj.IsActive = true;

}

//private void Acct_Ac_tblHesabMoeenRadGrid_SelectionChanged(object sender, SelectionChangeEventArgs e)
//{
//    var Cur = GetAcct_Ac_tblHesabMoeenQueryDataSource.DataView.CurrentItem as Acct_Ac_tblHesabMoeen;
//    ShowTafsilyhyperlinkButton.NavigateUri = new Uri("/Acct_Ac_tblHesabMoeenAcct_Ac_tblHesabTafsilyDMD2?id="+Cur.Acct_Ac_tblHesabMoeenID, UriKind.Relative);
//}





    }
}
