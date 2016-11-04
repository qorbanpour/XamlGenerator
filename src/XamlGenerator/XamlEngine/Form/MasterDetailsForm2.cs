using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using XamlGenerator.DataSourceManager;
using XamlGenerator.Component;
namespace XamlGenerator.Form
{
    class MasterDetailsForm2
    {
        string formPostFixName = "MD2.xaml"; //Set the form and class Name here// this name differentiate this form from other forms
        string classPostFixName = "MD2";
        string masterPostFix = "M";
        string detailsPostFix = "D";
        //masterform name = MasterEntityType+MasterPostFix+formPostfix
        //detailsform name = MasterEntityType+DetailEntitytype+DetailsPostFix+formPostfix


        #region  FinalTemplate
        string templateNew =
        "<navigation:Page x:Class=\"{0}.{1}\"\n" +
        "    xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
        "    xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"\n" +
        "    xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
        "    xmlns:navigation=\"clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation\"\n" +
        "    {2}\n" +
        "    FontFamily=\"Tahoma\"\n"+
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





        string templateNew_temp =
            "<navigation:Page x:Class=\"{0}.{1}\"\n" +
            "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
            "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
            "xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"\n" +
            "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
            "xmlns:navigation=\"clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Navigation\"\n" +
            "{2}\n" +
            "mc:Ignorable=\"d\"\n" +
            "d:DesignHeight=\"300\" d:DesignWidth=\"400\">\n" +

                "<Grid x:Name=\"LayoutRoot\" FlowDirection=\"RightToLeft\" >\n" +
                    //"<Grid.RowDefinitions>\n" +
                    //    "<RowDefinition />\n" +
                    //    "<RowDefinition />\n" +
                    //"</Grid.RowDefinitions>\n" +
                    "<Grid.ColumnDefinitions>\n" +
                        "<ColumnDefinition Width=\"436*\" />\n" +
                        "<ColumnDefinition  Width=\"204*\"/>\n" +
                    "</Grid.ColumnDefinitions>\n" +
                    "<Border Grid.Column=\"0\" >" +
                    "<Grid>\n" + "{3}\n" + "</Grid>" +
                    "</Border>\n" +

                "<Border Grid.Column=\"1\" >"
                    + "<Grid>\n" + "{4}\n" + "</Grid>" +

                    "</Border>\n" +

                "</Grid>\n" +
                "</navigation:Page>\n";


        private string OnNavigatedToTemplate =

          "\nprotected override void OnNavigatedTo(NavigationEventArgs e)\n"+
          "{\n" +

           "     if(PageSecurity.IsFormAccessValid == false)\n " +
           "          SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);\n" + 
          "}\n";
        private string ActionEvent = // 0 ==> datasource name , 1 ==> gridview name, 2 ==> Property Name
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
            "     newObj.ClientID = SystemSettings.Settings.GetClientId();\n"+
            "     newObj.Created = SystemSettings.Settings.ClientNow();\n"+
            "     newObj.CreatedBy = SystemSettings.Settings.GetUserID();\n"+

            "     newObj.OrganizationID = SystemSettings.Settings.GetOraganizationID();\n"+
            "     newObj.Updated = SystemSettings.Settings.ClientNow();\n"+
            "     newObj.UpdatedBy = SystemSettings.Settings.GetUserID();\n"+
            "     newObj.IsActive = true;\n" +

            "}}\n" +
            " private void {1}Delete_Click(object sender, RoutedEventArgs e)\n" +
            "{{\n" +
            "                {0}.DataView.Remove({0}.DataView.CurrentItem);\n" +
            "}}\n" +

            "#endregion//----------------------------------------------------------------------\n";







        string GridColumnVisibilityBindingTemplate =
       "//---Binding GridView Visibility\n" +
        "GridViewColumnCollection c = this.{0}.Columns;\n" +
        "foreach (var column in c)\n" +
        "{{\n" +
        "    column.IsVisible = PageSecurity.IsPropertyVisible(column.Header.ToString());\n" +

        "}}\n" +
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
                                 "using {4};\n" +
                                 "namespace {0}\n" +
                                 "{{\n" +
                                 "    public partial class {1} : Page\n" +
                                 "    {{\n" +
                                 "        Security PageSecurity = new Security(\"{1}\");\n" +
                                 "        public {1}()\n" +
                                 "        {{\n" +
                              //   "            this.DataContext = PageSecurity;\n" +
                                 "            SecurityConverter.SecurityObj = PageSecurity;\n" +
                                 "            InitializeComponent();\n" +
                                 "         {3}\n"+
                                 "        }}\n" +


                                
                                 "          {2}\n" +

                                 "   }}\n" +
                                 "}}\n";

        string NavigationButtonEvent =

        "private void Button{0}_Click(object sender, System.Windows.RoutedEventArgs e)\n" +
        "{{\n" +
        "   var res = this.{1}.DataView.CurrentItem as {2};\n" +

        "   NavigationService.Navigate(new Uri(\"/"+GlobalGeneratorSettings.SubSystemName+"/"+"{3}?{4}=\"" + "+{5},\n" +
        "      UriKind.Relative));\n" +

        "}}\n";



        public MasterDetailsForm2()
        {
        //    GlobalGeneratorSettings.DomainContextName = "TestDomainContext";
        //    GlobalGeneratorSettings.SilverlightProjectName = "SilverlightApplication4";
        //    GlobalGeneratorSettings.SilverlightWebProjectName = "SilverlightApplication4.Web";
        //    GlobalGeneratorSettings.SavePath = "C://xamlTest//";
        }

        public void Save()
        {

            foreach (var Item in DAL.DAL.GetAllEntitySet())
            {
                          
                #region foreach loop
                IDataSourceManager DomainDataSourceManager = new MasterDetails2RadDomainDataSource((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName);
                //Dictionary<IDataSourceManager,MasterDetailsForm2RadGrid> DetailsGrids
                MasterDetailsForm2RadGrid tg = new MasterDetailsForm2RadGrid((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName, (Item as EntitySet).EntityMetaData, ref DomainDataSourceManager);
                tg.CreateGridFromMetaData();



                
                //masterform name = MasterEntityType+MasterPostFix+formPostfix
                //detailsform name = MasterEntityType+DetailEntitytype+DetailsPostFix+formPostfix
                string MasterFormName = (Item as EntitySet).EntityTypeName + masterPostFix + formPostFixName;
                string MasterClassName = (Item as EntitySet).EntityTypeName + masterPostFix + classPostFixName;
                //
                //
                // StreamWriter sw = new StreamWriter(GlobalGeneratorSettings.SavePath + formPostFixName);
                // Read the master xaml here
                // Read the datasource for master from domain datasource manager
                //

                if (!tg.NeedDetailsGrid)
                {
                    continue;
                }

                //---- Master grid-----//
                //---- Master DataForm----//
                //---- ignore TempManager----//

                IDataSourceManager TempManager = new RadGridDataFormDomainDataSourceManager((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName);
                TelerikDataForm2 masterDataform = new TelerikDataForm2((Item as EntitySet).EntityTypeName, (Item as EntitySet).EntitySetName, (Item as EntitySet).EntityMetaData, ref TempManager);
                masterDataform.DataSourceName = tg.DataSourceName;
                masterDataform.CreateDataFormFromMetaData();

                //
                // Read the Master DataForm Xaml Here
                //
                //
                string MasterGridVisibilityBind = string.Format(GridColumnVisibilityBindingTemplate, tg.GridName);

                //DomainDataSourceManager.SetMasterEntitySetTypeName((Item as EntitySet).EntityTypeName);

                /*
                 * Debuging 1
                IDataSourceManager detailsDataSource = new MasterDetails2RadDomainDataSource(null, null);
                 * initializing of this object moved inside the next loop,
                 * Cause: Error in generating OnNavigatedTo Events for childs entities.
                */
                IDataSourceManager detailsDataSource;

                var ChildEntitySets = DAL.DAL.GetChildEntitySet(Item as EntitySet);
                ArrayList buttionAction = new ArrayList();
                int buttonCount = 0;
                foreach (var ChildEntity in ChildEntitySets)
                {
                    /*
                     Debuging 1
                     *  Initializing of the detailsDataSource moved inside this loop                                                             
                     */
                    detailsDataSource = new MasterDetails2RadDomainDataSource(null, null);


                    #region inner foreach loop
                    EntitySet ChildEntitySet = ChildEntity as EntitySet;
                    detailsDataSource.UpdateEntityInfo(ChildEntitySet.EntityTypeName, ChildEntitySet.EntitySetName);
                    detailsDataSource.SetMasterEntitySetTypeName((Item as EntitySet).EntityTypeName);
                    buttonCount++;

                    //int ForeignEntity_id=GetForeignEntityId(Item, ChildEntity);
                    //string ForeignEntity = GetForeignEntityTypeName(ForeignEntity_id);

                    string Key = string.Empty;
                    foreach (var ent in (Item as EntitySet).EntityMetaData)
                    {
                        if (ent.IsKey == true)
                        {
                            Key = ent.PropertyName;
                        }
                    }
                    /*
                      " private void Button{0}_Click(object sender, System.Windows.RoutedEventArgs e)\n"+
        "{{\n"+
            "var res = this.{1}.DataView.CurrentItem as {2};\n"+
            
            "NavigationService.Navigate(new Uri(\"{3}?{4}=\" + {5},\n"+
                "UriKind.Relative));\n"+

        "}}\n";
                     
                     */

                    //detailsform name = MasterEntityType+DetailEntitytype+DetailsPostFix+formPostfix
                    string DetailsFormName = (Item as EntitySet).EntityTypeName + ChildEntity.EntityTypeName + detailsPostFix + formPostFixName;
                    string DetailsClassName = (Item as EntitySet).EntityTypeName + ChildEntity.EntityTypeName + detailsPostFix + classPostFixName;
                    //


//                    if(DetailsFormName != 





                    string ButtonAction = string.Format(NavigationButtonEvent, buttonCount,tg.DataSourceName , (Item as EntitySet).EntityTypeName, DetailsClassName, Key, "res." + Key);
                    buttionAction.Add(ButtonAction);


                    MasterDetailsForm2RadGrid dtg = new MasterDetailsForm2RadGrid(ChildEntitySet.EntityTypeName, ChildEntitySet.EntitySetName, ChildEntitySet.EntityMetaData, ref detailsDataSource, MasterDetailsForm2RadGrid.GridTypes.Details, tg.GridName, tg.ChildBindingPath, tg.ParameterName);
                    dtg.CreateGridFromMetaData();
                    //-- Ignore Temp Manager
                    IDataSourceManager tempManager = new RadGridDataFormDomainDataSourceManager((ChildEntity as EntitySet).EntityTypeName, (ChildEntity as EntitySet).EntitySetName);
                    TelerikDataForm2 detailDataform = new TelerikDataForm2((ChildEntity as EntitySet).EntityTypeName, (ChildEntity as EntitySet).EntitySetName, (ChildEntity as EntitySet).EntityMetaData, ref tempManager);
                    detailDataform.DataSourceName = dtg.DataSourceName;
                    detailDataform.CreateDataFormFromMetaData();



                    string DetailsGridVisibilityBind = string.Format(GridColumnVisibilityBindingTemplate, dtg.GridName);
                    string DetailsDataSourceAction = string.Format(ActionEvent, dtg.DataSourceName, dtg.GridName, ChildEntitySet.EntityTypeName);
                    //Read details master and dataform and write it to files.
                    StreamWriter outfile = new StreamWriter(GlobalGeneratorSettings.SavePath +DetailsFormName);// (ChildEntitySet.EntityTypeName + "Details" + formPostFixName));
                    string NameSpace = DomainDataSourceManager.GetDataSourceNameSpace();
                    string detailsCodeBehind = detailsDataSource.GetDataSourceCodeBehindMethods();
                    detailsCodeBehind += detailDataform.CodeBehindMethods;
                    outfile.Write(string.Format(templateNew, GlobalGeneratorSettings.SilverlightProjectName,DetailsClassName/* ChildEntitySet.EntityTypeName + classPostFixName*/, NameSpace,detailsDataSource.GetDataSourceXaml()+ dtg.XamlCode, detailDataform.XamlCode));
                    outfile.Flush();
                    outfile.Close();
                    outfile = new StreamWriter(GlobalGeneratorSettings.SavePath + DetailsFormName + ".cs");//(ChildEntitySet.EntityTypeName + "Details"+formPostFixName + ".cs"));
                    outfile.Write(string.Format(CodeBehind, GlobalGeneratorSettings.SilverlightProjectName, DetailsClassName/*ChildEntitySet.EntityTypeName + classPostFixName*/, detailsCodeBehind+DetailsDataSourceAction, DetailsGridVisibilityBind,GlobalGeneratorSettings.SilverlightWebProjectName));
                    outfile.Flush();
                    outfile.Close();

                    #endregion
                }

                StreamWriter outStream = new StreamWriter(GlobalGeneratorSettings.SavePath + MasterFormName);//((Item as EntitySet).EntityTypeName + "Master" + formPostFixName));

                outStream.Write(string.Format(templateNew, GlobalGeneratorSettings.SilverlightProjectName,MasterClassName/* (Item as EntitySet).EntityTypeName + classPostFixName*/, DomainDataSourceManager.GetDataSourceNameSpace(),DomainDataSourceManager.GetDataSourceXaml()+"\n\n\n"+ tg.XamlCode, masterDataform.XamlCode));
                outStream.Flush();
                outStream.Close();
                string masterCodeBehind = "\n#region ------ Navigate Action For Buttons------//\n";
                foreach (var st in buttionAction)
                {
                    masterCodeBehind += st;
                }
                masterCodeBehind += "#endregion\n";
                masterCodeBehind += DomainDataSourceManager.GetDataSourceCodeBehindMethods();
                masterCodeBehind += OnNavigatedToTemplate;

                string masterDataSourceAction = string.Format(ActionEvent, tg.DataSourceName, tg.GridName, (Item as EntitySet).EntityTypeName);

                outStream = new StreamWriter(GlobalGeneratorSettings.SavePath + MasterFormName+".cs");//(Item as EntitySet).EntityTypeName + "Master"+formPostFixName + ".cs");
                outStream.Write(string.Format(CodeBehind, GlobalGeneratorSettings.SilverlightProjectName, MasterClassName/* (Item as EntitySet).EntityTypeName + classPostFixName*/, masterCodeBehind + masterDataSourceAction + masterDataform.CodeBehindMethods, MasterGridVisibilityBind, GlobalGeneratorSettings.SilverlightWebProjectName));
                outStream.Flush();
                outStream.Close();



                #endregion
            }
        }

        private string GetForeignEntityTypeName(int ForeignEntity_id)
        {
            return DAL.DAL.GetEntityTypeNameById(ForeignEntity_id);
        }

        private  int GetForeignEntityId(object Item, EntitySet ChildEntity)
        {
            
            foreach (var ent in ChildEntity.EntityMetaData)//( Item as EntitySet).EntityMetaData)
            {
                if (ent.IsForeignKey == true && ent.ForeignEntityType == (Item as EntitySet).EntityTypeName)//( ent.Equals( (ChildEntity.EntityMetaData))))
                {
                    return (int)ent.EntitySet_id;                    
                }
            }
            throw new Exception();
        }

    }
}
