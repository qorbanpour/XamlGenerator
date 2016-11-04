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
    public partial class EntitySetEntityMetaDataDMD2 : Page
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        Security PageSecurity = new Security("EntitySetEntityMetaDataDMD2");
        public EntitySetEntityMetaDataDMD2()
        {
            this.DataContext = this;
            SecurityConverter.SecurityObj = PageSecurity;
            InitializeComponent();
         //---Binding GridView Visibility
GridViewColumnCollection c = this.EntityMetaDatasRadDetailsGrid.Columns;
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
    else
    {

        if (NavigationContext.QueryString.ContainsKey("id"))
        {

            this.Id = int.Parse(NavigationContext.QueryString["id"]);
            this.DisplayName = NavigationContext.QueryString["DisplayName"];

        }
    }
 }

#region DataSource Actions
//-----------------------Save Delete And New Actions-----------------------------
private void EntityMetaDatasRadDetailsGridSubmitButton_Click(object sender, RoutedEventArgs e)
{
   if (GetEntityMetaDatasByEntitySetQueryDataSource.HasChanges)
   {
        GetEntityMetaDatasByEntitySetQueryDataSource.SubmitChanges();
   }
}
private void EntityMetaDatasRadDetailsGridCancelButton_Click(object sender, RoutedEventArgs e)
{
        if (GetEntityMetaDatasByEntitySetQueryDataSource.HasChanges)
        {
                GetEntityMetaDatasByEntitySetQueryDataSource.CancelSubmit();
        }
}
private void EntityMetaDatasRadDetailsGridNewButton_Click(object sender, RoutedEventArgs e)
{
    EntityMetaDatasRadDetailsGrid.Items.AddNew();
}
#endregion//----------------------------------------------------------------------

private void Button_Click(object sender, RoutedEventArgs e)
{
    if (this.GetEntityMetaDatasByEntitySetQueryDataSource.HasChanges)
    {
        GetEntityMetaDatasByEntitySetQueryDataSource.CancelSubmit();
        MessageBox.Show("Operation Canceled By User!");
    }
}

private void Button_Click_1(object sender, RoutedEventArgs e)
{
    
    if (this.GetEntityMetaDatasByEntitySetQueryDataSource.HasChanges)
    {
        GetEntityMetaDatasByEntitySetQueryDataSource.SubmitChanges();
        MessageBox.Show("Saved Successfully!");
    }
}

private void EntityMetaDatasRadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
{
    if (this.GetEntityMetaDatasByEntitySetQueryDataSource.HasChanges)
    {
        GetEntityMetaDatasByEntitySetQueryDataSource.SubmitChanges();
    }
}

   }
}
