using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.DataSourceManager;
using XamlGenerator.Component;
using System.IO;
using System.Collections;

namespace XamlGenerator.Form
{
    class MasterDetailGridForm
    {

        string formPostFixName = "MasterDetails.xaml"; //Set the form and class Name here// this name differentiate this form from other forms
        string classPostFixName = "MasterDetails";
                    
        
        string templateNew=
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
        
                "<Grid x:Name=\"LayoutRoot\" Style=\"{{StaticResource MainGridT2}}\">\n" +
                    "<Grid.RowDefinitions>\n" +
                        "<RowDefinition />\n" +
                        "<RowDefinition />\n" +
                    "</Grid.RowDefinitions>\n" +
                    "<Grid.ColumnDefinitions>\n" +
                        "<ColumnDefinition Width=\"70*\" />\n" +
                        "<ColumnDefinition  Width=\"30*\"/>\n" +
                    "</Grid.ColumnDefinitions>\n" +
                    "<Border Grid.ColumnSpan=\"2\" Grid.Row=\"0\" Style=\"{{StaticResource MainBorderT2}}\" >"+
                    "<Grid>\n"+"{3}\n"+"</Grid>"+        
                    "</Border>\n" +
            
                "<Border Grid.ColumnSpan=\"2\" Grid.Row=\"1\" Style=\"{{StaticResource SecondBorderT2}}\" >"
                    + "<Grid>\n" + "{4}\n" + "</Grid>" +
                               
                    "</Border>\n" +
                                
                "</Grid>\n"+
                "</navigation:Page>\n";

        private string OnNavigatedToTemplate =

         "\nprotected override void OnNavigatedTo(NavigationEventArgs e)\n" +
         "{\n" +

          "     if(PageSecurity.IsFormAccessValid == false)\n " +
          "          SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);\n" +
         "}\n";
        private string ActionEvent = // 0 ==> datasource name , 1 ==> gridview name,  2 ==> Property Name
            "\n#region DataSource Actions\n//-----------------------Save Delete And New Actions-----------------------------\n" +
            "\nprivate void {1}SubmitButton_Click(object sender, RoutedEventArgs e)\n" +
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
            "}}\n"+
            "#endregion//----------------------------------------------------------------------\n";
            






       


           private string GridColumnVisibilityBindingTemplate=
           "//---Binding GridView Visibility\n"+
            "GridViewColumnCollection c{1} = this.{0}.Columns;\n"+
            "foreach (var column in c{1})\n"+
            "{{\n"+
                "column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());\n"+

            "}}\n"+
            "//------------------------------\n";


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
                                "using System.Windows.Navigation;\n" +
                                "using Telerik.Windows.Controls;\n" +
                           

                                "namespace {0}\n" +
                                "{{\n" +
                                "    public partial class {1} : Page\n" +
                                "    {{\n" +
                                "        Security PageSecurity = new Security(\"{1}\");\n"+
                                "        public {1}()\n" +
                                "        {{\n" +
                                "            this.DataContext = PageSecurity;\n"+
                                "            SecurityConverter.SecurityObj = PageSecurity;\n"+
                                "            InitializeComponent();\n" +
                                "                 {3}\n" +
                                "        }}\n" +


                                      
                                "         {2}\n"+
                                         
                                "    }}\n" +
                                "}}\n";

        public MasterDetailGridForm()
        {
            //GlobalGeneratorSettings.DomainContextName = "TestDomainContext";
            //GlobalGeneratorSettings.SilverlightProjectName = "SilverlightApplication4";
            //GlobalGeneratorSettings.SilverlightWebProjectName = "SilverlightApplication4.Web";
            //GlobalGeneratorSettings.SavePath = "C://xamlTest//";
        }

        public void Save()
        {
            
            foreach (var Item in DAL.DAL.GetAllEntitySet())
            {
                IDataSourceManager DomainDataSourceManager = new RadMasterDetailsGridDomainDataSourceManager((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName);
                TelerikGrid tg = new TelerikGrid((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName, (Item as EntitySet).EntityMetaData, ref DomainDataSourceManager);
                tg.CreateGridFromMetaData();
                string GridVisiblityBind = string.Empty;
                if (!tg.NeedDetailsGrid)
                {
                    continue;
                }
                GridVisiblityBind += string.Format(GridColumnVisibilityBindingTemplate,tg.GridName,0);
                //Console.WriteLine((Item as EntitySet).EntityTypeName);
                DomainDataSourceManager.SetMasterEntitySetTypeName((Item as EntitySet).EntityTypeName);
                var ChildEntitySets = DAL.DAL.GetChildEntitySet(Item as EntitySet);
                ArrayList DetailsGrids = new ArrayList();
                int i = 1;
                string DataSourceAction = "\n#region DataSource Actions\n//-----------------------Save Delete And New Actions-----------------------------\n"
                    + string.Format(ActionEvent, tg.DataSourceName, tg.GridName, (Item as EntitySet).EntityTypeName);
                foreach (var ChildEntity in ChildEntitySets)
                {
                    
                   // Console.WriteLine((ChildEntity as EntitySet).EntityTypeName);
                    EntitySet ChildEntitySet = ChildEntity as EntitySet;
                    DomainDataSourceManager.UpdateEntityInfo(ChildEntitySet.EntityTypeName, ChildEntitySet.EntitySetName);
                    
                    TelerikGrid dtg = new TelerikGrid(ChildEntitySet.EntityTypeName, ChildEntitySet.EntitySetName, ChildEntitySet.EntityMetaData, ref DomainDataSourceManager, TelerikGrid.GridTypes.Details, tg.GridName,tg.ChildBindingPath,tg.ParameterName);
                    dtg.CreateGridFromMetaData();
                    DetailsGrids.Add(dtg);
                    GridVisiblityBind += string.Format(GridColumnVisibilityBindingTemplate, dtg.GridName,i);
                    DataSourceAction += string.Format(ActionEvent, dtg.DataSourceName, dtg.GridName, ChildEntitySet.EntityTypeName);
                    i++;
                }
                //Console.WriteLine("Next");
                //TelerikDataForm dft = new TelerikDataForm((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName, (Item as EntitySet).EntityMetaData, ref DomainDataSourceManager);
                DataSourceAction+="#endregion//----------------------------------------------------------------------\n";


                //--- save these 3 objects xamls to files.
                
                StreamWriter outfile = new StreamWriter(GlobalGeneratorSettings.SavePath+ (Item as EntitySet).EntityTypeName+formPostFixName);
                string NameSpace = DomainDataSourceManager.GetDataSourceNameSpace();
                string gridxaml = DomainDataSourceManager.GetDataSourceXaml()+tg.XamlCode;

                string detailsXaml = string.Empty;
                string detailsCodeBehind = string.Empty;
                foreach (var it in DetailsGrids)
                {
                    detailsXaml += (it as TelerikGrid).XamlCode;
                    detailsCodeBehind += (it as TelerikGrid).CodeBehindMethods;
                }


                outfile.Write(string.Format(templateNew, GlobalGeneratorSettings.SilverlightProjectName, (Item as EntitySet).EntityTypeName + classPostFixName, NameSpace, gridxaml, detailsXaml));
                outfile.Flush();

                outfile = new StreamWriter(GlobalGeneratorSettings.SavePath + (Item as EntitySet).EntityTypeName + formPostFixName+".cs");
                outfile.Write(string.Format(CodeBehind, GlobalGeneratorSettings.SilverlightProjectName, (Item as EntitySet).EntityTypeName + classPostFixName,OnNavigatedToTemplate +DataSourceAction+detailsCodeBehind,GridVisiblityBind));
                outfile.Flush();


            }
            DAL.DAL.GenerateParentChildLoadQueries(GlobalGeneratorSettings.SavePath);
            
        }

    }
}
