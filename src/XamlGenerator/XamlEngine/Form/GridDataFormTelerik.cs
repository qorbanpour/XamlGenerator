using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.DataSourceManager;
using XamlGenerator.Component;
using System.IO;

namespace XamlGenerator.Form
{
    class GridDataFormTelerik
    {
    /// <summary>
    /// Instruction:
    /// First Set the appropriate values in GlobalGeneratorSettings properties.
    /// Then Per every form, pass the required parameters to the constructor of the RadGrid object
    /// Then, call the createGridFromMetaData() Method.
    /// Now read the XamlCode, CodeBehind and NameSpace from the TelerikGrid object.
    /// 
    /// 
    /// Do The same process for DataFrom
    /// 
    /// 
    /// Now Merge the result into appropriate placeholder in the template
    /// 
    /// 
    /// Note: RadGridDataFormDomainDataSourceManager should be reinitialized for every new form.
    /// Datasource Xaml and code behind should be read from DataSource Manager
    /// </summary>
    /// 


        string formPostFixName = "SimpleForm.xaml"; //Set the form and class Name here// this name differentiate this form from other forms
        string classPostFixName = "SimpleForm";
        
        string template=

    "<navigation:Page x:Class=\"{0}.{1}\"\n" +
    "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
    "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
    "xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"\n" +
    "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
    "{2}\n" +
    "mc:Ignorable=\"d\"\n" +
    "d:DesignHeight=\"300\" d:DesignWidth=\"400\">\n" +

    "<Grid x:Name=\"LayoutRoot\" Background=\"White\">\n" +
        "{3}\n" +
    "</Grid>\n" +
"</navigation:Page>\n";


        #region  FinalTemplate
        string templateNew =
        "<navigation:Page x:Class=\"{0}.{1}\"\n" +
        "    xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
        "    xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"\n" +
        "    xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
        "    xmlns:navigation=\"clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation\"\n" +
        "    {2}\n" +
        "    FontFamily=\"Tahoma\"\n" +
        "    mc:Ignorable=\"d\"\n" +
        "    d:DesignHeight=\"300\" d:DesignWidth=\"400\">\n" +
        "        <Grid FlowDirection=\"RightToLeft\" x:Name=\"LayoutRoot\">\n" +
        "		<Grid.ColumnDefinitions>\n" +
        "			<ColumnDefinition Width=\"600*\" />\n" +
        "			<ColumnDefinition Width=\"300*\"/>\n" +
        "		</Grid.ColumnDefinitions>\n" +
        "		<Grid FlowDirection=\"RightToLeft\" Grid.Column=\"0\">\n" +
        "			<Grid.RowDefinitions>\n" +
        "				<RowDefinition Height=\"Auto\" />\n" +
        "				<RowDefinition Height=\"Auto\" />\n" +
        "               <RowDefinition Height=\"Auto\"/>\n" +
        "			</Grid.RowDefinitions>\n" +
        "            <!-- \n" +
        "                Here is the place for GridView View and Buttons\n" +
        "            -->\n" +
        "            <Border Grid.Row=\"0\" Style=\"{{StaticResource TopGridViewBorder}}\" >\n" +
        "                <Grid></Grid>\n" +
        "            </Border>\n" +
        "           \n" +
        "           <Border Grid.Row=\"1\" Style=\"{{StaticResource MiddleGridViewBorder}}\">\n" +
        "                <Grid>{3}\n</Grid>\n" +
        "           </Border>\n" +
        "\n" +
        "            <Border Grid.Row=\"2\" Style=\"{{StaticResource BottomGridViewBorder}}\">\n" +
        "                <Grid></Grid>\n" +
        "            </Border>\n" +
        "		</Grid>\n" +
        "		<Grid Grid.Column=\"1\" FlowDirection=\"RightToLeft\">			\n" +
        "			<Grid.RowDefinitions>\n" +
        "                <RowDefinition Height=\"Auto\" />\n" +
        "                <RowDefinition Height=\"Auto\" />\n" +
        "                <RowDefinition Height=\"Auto\"/>\n" +
        "			</Grid.RowDefinitions>\n" +
        "            <!-- \n" +
        "                Here is the place for DataForm                     \n" +
        "            -->\n" +
        "\n" +
        "            <Border Grid.Row=\"0\" Style=\"{{StaticResource TopDataFormBorder}}\" >\n" +
        "                <Grid></Grid>\n" +
        "            </Border>\n" +
        "       \n" +
        "            <Border Grid.Row=\"1\" Style=\"{{StaticResource MiddleDataFormBorder}}\">\n" +
        "                <Grid>{4}\n</Grid>\n" +
        "            </Border>\n" +
        "    \n" +
        "            <Border Grid.Row=\"2\" Style=\"{{StaticResource BottomDataFormBorder}}\">\n" +
        "                <Grid></Grid>\n" +
        "            </Border>" +
        "        </Grid>\n" +
        "        </Grid>\n" +
        " \n" +
        "</navigation:Page>\n";

        #endregion 



        string templateNew_temp=
            "<navigation:Page x:Class=\"{0}.{1}\"\n" +
    "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
    "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
    "xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"\n" +
    "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
    "xmlns:navigation=\"clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation\"\n" +
    "{2}\n"+
    "    FontFamily=\"Tahoma\"\n" +
    "mc:Ignorable=\"d\"\n" +
    "d:DesignHeight=\"300\" d:DesignWidth=\"400\">\n" +

    "<Grid x:Name=\"LayoutRoot\">\n" +
        "<Grid.RowDefinitions>\n" +
            "<RowDefinition />\n" +
            "<RowDefinition />\n" +
        "</Grid.RowDefinitions>\n" +
        "<Grid.ColumnDefinitions>\n" +
            "<ColumnDefinition Width=\"70*\" />\n" +
            "<ColumnDefinition  Width=\"30*\"/>\n" +
        "</Grid.ColumnDefinitions>\n" +
        "<Border Grid.Column=\"0\" Grid.RowSpan=\"2\" >"+
        "<Grid>\n"+"{3}\n"+"</Grid>"+
        
        "</Border>\n" +

        "<Border Grid.RowSpan=\"2\" Grid.Column=\"1\"  >"
        + "<Grid>\n" + "{4}\n" + "</Grid>" +
       
        "</Border>\n" +
        
        "</Grid>\n"+
    "</navigation:Page>\n";





        string GridColumnVisibilityBindingTemplate =
       "//---Binding GridView Visibility\n" +
        "GridViewColumnCollection c = this.{0}.Columns;\n" +
        "foreach (var column in c)\n" +
        "{{\n" +
        "   column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());\n" +

        "}}\n" +
        "//------------------------------\n";
        private string OnNavigatedToTemplate =

         "\nprotected override void OnNavigatedTo(NavigationEventArgs e)\n" +
         "{\n" +

          "     if(PageSecurity.IsFormAccessValid == false)\n " +
          "          SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);\n" +
         "}\n";
        private string ActionEvent = // 0 ==> datasource name , 1 ==> gridview name , 2 ==> Property Name
            "\n#region DataSource Actions\n//-----------------------Save Delete And New Actions-----------------------------\n" +
            "private void {1}SubmitButton_Click(object sender, RoutedEventArgs e)\n" +
            "{{\n" +
            "   if ({0}.HasChanges)\n" +
            "   {{\n" +
            "        {0}.SubmitChanges();\n" +
            "   }}\n" +
            "}}\n" +

            "private void {1}CancelButton_Click(object sender, RoutedEventArgs e)\n" +
            "{{\n" +
            "        if ({0}.HasChanges)\n" +
            "        {{\n" +
            "                {0}.RejectChanges();\n" +
            "        }}\n" +
            "}}\n" +

            "private void {1}NewButton_Click(object sender, RoutedEventArgs e)\n" +
            "{{\n" +

            "     var newObj = {1}.Items.AddNew() as {2} ;\n" +
            "     newObj.ClientID = SystemSettings.Settings.GetClientId();\n" +
            "     newObj.Created = SystemSettings.Settings.ClientNow();\n" +
            "     newObj.CreatedBy = SystemSettings.Settings.GetUserID();\n" +
            "     newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();\n" +
            "     newObj.Updated = SystemSettings.Settings.ClientNow();\n" +
            "     newObj.UpdatedBy = SystemSettings.Settings.GetUserID();\n" +
            "     newObj.IsActive = true;\n" +
    
            "}}\n" +
            "private void {1}Delete_Click(object sender, RoutedEventArgs e)\n" +
            "{{\n" +
            "                {0}.DataView.Remove({0}.DataView.CurrentItem);\n" +           
            "}}\n" +

            "#endregion//----------------------------------------------------------------------\n";




        private string CodeBehind =
                                "using System;\n" +
                                "using System.Collections.Generic;\n" +
                                "using System.Linq;\n" +
                                "using System.Net;\n" +
                                "using System.Windows;\n" +
                                "using System.Windows.Controls;\n" +
                                "using System.Windows.Documents;\n" +
                                "using System.Windows.Input;\n" +
                                "using System.Windows.Media;\n" +
                                "using System.Windows.Media.Animation;\n" +
                                "using System.Windows.Shapes;\n" +
                                "using System.Windows.Navigation;\n"+
                                "using Telerik.Windows.Controls;\n"+

                                "namespace {0}\n" +
                                "{{\n" +
                                "    public partial class {1} : Page\n" +
                                "    {{\n" +
                                "        Security PageSecurity = new Security(\"{1}\");\n" +
                                "        public {1}()\n" +
                                "        {{\n" +
                                "            this.DataContext = PageSecurity;\n" +
                                "            SecurityConverter.SecurityObj = PageSecurity;\n" +
                                "            InitializeComponent();\n" +
                                "            {3}"+
                                "        }}\n" +
                                        



                                "         {2}\n"+
                                "    }}\n" +
                                "}}\n";

        
        public GridDataFormTelerik()
        {
            //GlobalGeneratorSettings.DomainContextName = "TestDomainContext";
            //GlobalGeneratorSettings.SilverlightProjectName = "SilverlightApplication4";
            //GlobalGeneratorSettings.SilverlightWebProjectName = "SilverlightApplication4.Web";
        }

        public void Save()
        {
            foreach (var Item in DAL.DAL.GetAllEntitySet())
            {
                IDataSourceManager DomainDataSourceManager = new RadGridDataFormDomainDataSourceManager((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName);
                TelerikGrid tg = new TelerikGrid((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName, (Item as EntitySet).EntityMetaData, ref DomainDataSourceManager);
                tg.CreateGridFromMetaData();
                string GridVisibilityBind = string.Empty;
                GridVisibilityBind= string.Format(GridColumnVisibilityBindingTemplate,tg.GridName);
                TelerikDataForm dft = new TelerikDataForm((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName, (Item as EntitySet).EntityMetaData, ref DomainDataSourceManager);
                dft.CreateDataFormFromMetaData();

                string DataSourceAction = string.Format(ActionEvent,tg.DataSourceName,tg.GridName,(Item as EntitySet).EntityTypeName);
                StreamWriter outfile = new StreamWriter(new FileStream(GlobalGeneratorSettings.SavePath + (Item as EntitySet).EntityTypeName + formPostFixName, FileMode.Create), Encoding.UTF8);
                string NameSpace = DomainDataSourceManager.GetDataSourceNameSpace();
                string gridxaml = DomainDataSourceManager.GetDataSourceXaml()+tg.XamlCode;

                string dataformXaml = dft.XamlCode;       
                
                outfile.Write(string.Format(templateNew,GlobalGeneratorSettings.SilverlightProjectName,(Item as EntitySet).EntityTypeName+classPostFixName,NameSpace,gridxaml,dataformXaml));
                outfile.Flush();

                outfile = new StreamWriter(new FileStream(GlobalGeneratorSettings.SavePath + (Item as EntitySet).EntityTypeName + formPostFixName + ".cs", FileMode.Create), Encoding.UTF8);
                outfile.Write(string.Format(CodeBehind, GlobalGeneratorSettings.SilverlightProjectName, (Item as EntitySet).EntityTypeName + classPostFixName, OnNavigatedToTemplate + DataSourceAction + dft.CodeBehindMethods, GridVisibilityBind));
                outfile.Flush();
                //Console.WriteLine(DomainDataSourceManager.GetDataSourceXaml() + tg.XamlCode + dft.XamlCode);
                //--- save these 3 objects xamls to files.

                

            }
        }

    }
}
