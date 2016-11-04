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
    public partial class EntitySetMMD2 : Page
    {
        Security PageSecurity = new Security("EntitySetMMD2");
        public EntitySetMMD2()
        {
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.EntitySetsRadGrid.Columns;
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
   var res = this.GetEntitySetsQueryDataSource.DataView.CurrentItem as EntitySet;
   NavigationService.Navigate(new Uri("/Views/EntitySetEntityMetaDataDMD2?id=" + res.id + "&DisplayName=" + res.EntityTypeName,
      UriKind.Relative));
}
//-------------------------------------------------------------//
#endregion

protected override void OnNavigatedTo(NavigationEventArgs e)
{
     if(PageSecurity.IsFormAccessValid == false)
           SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);
}

#region DataSource Actions




//-----------------------Save Delete And New Actions-----------------------------
private void EntitySetsRadGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
   if (GetEntitySetsQueryDataSource.HasChanges)
   {
        GetEntitySetsQueryDataSource.SubmitChanges();
   }
}
private void EntitySetsRadGridCancelButton_Click(object sender, RoutedEventArgs e)
{
        if (GetEntitySetsQueryDataSource.HasChanges)
        {
                GetEntitySetsQueryDataSource.CancelSubmit();
        }
}
private void EntitySetsRadGridNewButton_Click(object sender, RoutedEventArgs e)
{
    EntitySetsRadGrid.Items.AddNew();
}
#endregion//----------------------------------------------------------------------

private void button1_Click_1(object sender, RoutedEventArgs e)
{
    if (this.GetEntitySetsQueryDataSource.HasChanges)
    {
        this.GetEntitySetsQueryDataSource.SubmitChanges();
    }
}




   }
}
