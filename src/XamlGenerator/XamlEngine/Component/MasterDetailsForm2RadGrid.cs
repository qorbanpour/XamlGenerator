using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.DataSourceManager;

namespace XamlGenerator.Component
{
    class MasterDetailsForm2RadGrid
    {
    
    //--------------------------------------------------------- GridView Definition --------------------------------------------------------------------//
    //<telerik:RadGridView AutoGenerateColumns="False" HorizontalAlignment="Stretch" Name="radGridView1" ItemsSource="{Binding DataView, ElementName=userDataSource}"
    //                 IsBusy="{Binding IsBusy, ElementName=userDataSource}" VerticalAlignment="Top" >
    //    <telerik:RadGridView.Columns>
    //        <telerik:GridViewDataColumn DataMemberBinding="{Binding Id}" IsVisible="False" Header="ID" IsReadOnly="True" Width="Auto" />
    //        <telerik:GridViewDataColumn DataMemberBinding="{Binding Name}"  Header="نام"  Width="Auto" />
    //        <telerik:GridViewDataColumn DataMemberBinding="{Binding Familiy}" Header="فامیل"  Width="Auto" />
    //        <telerik:GridViewDataColumn DataMemberBinding="{Binding StoreId}" Header="شماره مغازه" Width="Auto" />
    //    </telerik:RadGridView.Columns>
    //</telerik:RadGridView>
    //--------------------------------------------------------------------------------------------------------------------------------------------------//
        public enum GridTypes { Details = 1, Master, Typical };
        #region Property
        public string XamlNameSpace { get; set; }
        //public string XamlDataSource { get; set; }
        public string XamlCode { get; set; }
        public string CodeBehindMethods { get; set; }
        public string GridName { get; set; }  //------------ = EntitySetName + "RadGrid" for master and  typical and EntitySetName + "RadDetailsGrid" for detials grid
        public string EntityTypeName { get; set; }
        public string EntitySetName { get; set; }
        private IEnumerable<EntityMetaData> MetaDatas { get; set; }
        private IDataSourceManager DomainDataSourceManager { get; set; }
        private GridTypes GridType { get; set; }
        public bool NeedDetailsGrid { get; set; }
        //---- initialized in second constructor- Used for Details Grid----// 
        public string ParameterName { get; set; }
        public string ChildBindingPath { get; private set; }
        //private string ParentName { get; set; }
        private string MasterGridName { get; set; }
        //public string ChildEntity { get; set; }
        public string DataSourceName { get; set; }// Master Grid DataSource Name
        # endregion

        # region private field
        private string OpenGridDefinition = "<telerik:RadGridView AutoGenerateColumns=\"False\" CanUserDeleteRows=\"False\" CanUserInsertRows=\"False\" IsReadOnly=\"{{Binding IsFormReadOnly}}\" HorizontalAlignment=\"Stretch\" Name=\"{0}\" ItemsSource=\"{{Binding DataView, ElementName={1}}}\" IsBusy=\"{{Binding IsBusy, ElementName={2}}}\" VerticalAlignment=\"Stretch\" >\n";
        private string BeginColumnDefinition = "<telerik:RadGridView.Columns>\n";
        //private string TypicalColumnTemplate = "<telerik:GridViewDataColumn DataMemberBinding=\"{{Binding {0}}}\" IsVisible=\"{1}\" Header=\"{2}\" IsReadOnly=\"{3}\" Width=\"Auto\" />\n";
        //private string ComboBoxColumnTemplate = "<telerik:GridViewComboBoxColumn  DataMemberBinding=\"{{Binding {0}}}\" IsVisible=\"{1}\" Header=\"{2}\" IsReadOnly=\"{3}\" DisplayMemberPath=\"{4}\" IsComboBoxEditable=\"{5}\"  Width=\"Auto\" />\n";
        private string EndColumnDefinition = "</telerik:RadGridView.Columns>\n";
        private string EndGridDefinition = "</telerik:RadGridView>\n";        
        #endregion

        #region constructor
        public MasterDetailsForm2RadGrid(string EntityTypeName, string EntitySetName , IEnumerable<EntityMetaData> MetaDatas, ref IDataSourceManager DomainDataSourceManager)
        {
            this.XamlNameSpace = string.Empty; //--- telerik name space already included in datasource class namespace
            this.CodeBehindMethods = string.Empty;
            this.XamlCode = string.Empty;
            this.MetaDatas = MetaDatas.OrderBy(e => e.FieldOrder); 
            this.GridName = EntitySetName + "RadGrid";
            this.EntityTypeName = EntityTypeName;
            this.EntitySetName = EntitySetName;
            this.DomainDataSourceManager = DomainDataSourceManager;
            this.GridType = GridTypes.Typical;
            this.NeedDetailsGrid = IsDetailsGridNeeded(MetaDatas);
            this.ChildBindingPath = GetBindingPath(MetaDatas);
            this.ParameterName = FindParameterName(MetaDatas);
            
        }
        public MasterDetailsForm2RadGrid(string EntityTypeName, string EntitySetName, IEnumerable<EntityMetaData> MetaDatas, ref IDataSourceManager DomainDataSourceManager, GridTypes gridType, string MasterGridName, string ChildBindingPath, string ParameterName)
        {
            this.XamlNameSpace = string.Empty; //--- telerik name space already included in datasource class namespace
            this.CodeBehindMethods = string.Empty;
            this.XamlCode = string.Empty;
            this.MetaDatas = MetaDatas.OrderBy(e => e.FieldOrder);
            this.GridName = EntitySetName + "RadGrid";
            if (gridType == GridTypes.Details)
            {
                this.GridName = EntitySetName + "RadDetailsGrid";
            }
            this.EntityTypeName = EntityTypeName;
            this.EntitySetName = EntitySetName;
            this.DomainDataSourceManager = DomainDataSourceManager;
            this.GridType = gridType;
            this.ParameterName = ParameterName;
            this.ChildBindingPath = ChildBindingPath;
            //this.ParentName = FindParentName(MetaDatas);
            this.MasterGridName = MasterGridName;
            
        }

        private bool IsDetailsGridNeeded(IEnumerable<EntityMetaData> MetaDatas)
        {
            foreach (var Item in MetaDatas)
            {
                if (Item.IsCollectionEntity== true)
                    return true;
            }
            return false;
        }

        //private string FindParentName(IEnumerable<EntityMetaData> MetaDatas)
        //{
        //    foreach (var Item in MetaDatas)
        //    {
        //        if (Item.IsForeignKey == true)
        //        {
        //            return Item.ForeignEntityType;
        //        }
        //    }
        //    return null;
        //}

        private string GetBindingPath(IEnumerable<EntityMetaData> MetaDatas)
        {
            return "SelectedItem."+ FindParameterName(MetaDatas);//+ ParameterName;
        }

      
        private string FindParameterName(IEnumerable<EntityMetaData> MetaDatas)
        {
            foreach (var Item in MetaDatas)
            {
                if (Item.IsKey == true)
                {
                    return Item.PropertyName;
                }                
            }
            return null;
        }
        #endregion

        #region public methods
        public void CreateGridFromMetaData()
        {
            //string code_behind = string.Empty;
            //string xaml = string.Empty;  
            //xaml = string.Format(OpenGridDefinition, GridName, this.DomainDataSourceManager.GetDomainDataSourceName(), this.DomainDataSourceManager.GetDomainDataSourceName());
            //xaml += BeginColumnDefinition;

            //string Columns = string.Empty;
            //foreach (var Item in MetaDatas) //---- Items are already sorted by fieldOrder Desc
            //{
            //    Columns+= GetColumn(Item);               
            //}
            //xaml += Columns;
            //xaml += EndGridDefinition;

            //this.XamlCode = xaml;            

            if (this.GridType == GridTypes.Typical)
            {
                string code_behind = string.Empty;
                string xaml = string.Empty;
                xaml = string.Format(OpenGridDefinition, GridName, this.DomainDataSourceManager.GetDomainDataSourceName(), this.DomainDataSourceManager.GetDomainDataSourceName());
                xaml += BeginColumnDefinition;

                string Columns = string.Empty;
                foreach (var Item in MetaDatas) //---- Items are already sorted by fieldOrder Desc
                {
                    if (Item.IsInVisible == true)
                    {
                        continue;
                    }
                    Columns += GetColumn(Item);
                }
                xaml += Columns;
                xaml += EndColumnDefinition;
                xaml += EndGridDefinition;

                this.XamlCode = xaml;
                this.DataSourceName = this.DomainDataSourceManager.GetDomainDataSourceName();
            }
            else if (this.GridType == GridTypes.Details)
            {
                string code_behind = string.Empty;
                string xaml = string.Empty;

                //xaml = string.Format(OpenGridDefinition, GridName, this.DomainDataSourceManager.GetDomainDataSourceName(), this.DomainDataSourceManager.GetDomainDataSourceName());

                xaml = string.Format(OpenGridDefinition, GridName, this.DomainDataSourceManager.GetDetailsDomainDataSourceName(this.ParameterName, this.ChildBindingPath, this.MasterGridName,this.EntitySetName), this.DomainDataSourceManager.GetDetailsDomainDataSourceName(this.ParameterName, this.ChildBindingPath, this.MasterGridName,this.EntitySetName));
                xaml += BeginColumnDefinition;

                string Columns = string.Empty;
                foreach (var Item in MetaDatas) //---- Items are already sorted by fieldOrder Desc
                {
                    if (Item.IsInVisible == true)
                    {
                        continue;
                    }
                    Columns += GetColumn(Item);
                }            
                
                xaml += Columns;
                xaml += EndColumnDefinition;
                xaml += EndGridDefinition;

                this.XamlCode = xaml;
                this.DataSourceName = this.DomainDataSourceManager.GetDetailsDomainDataSourceName(this.ParameterName, this.ChildBindingPath, this.MasterGridName, this.EntitySetName);
            }
                

        }

        
        #endregion

        #region Private Method 
        //--------------------------- These methods moved to DataSourceManager----------------------------
        //private string GetDomainDataSourceName()
        //{
        //    string DataSourceName= GetDataSourceQueryName() + "DataSource";
        //    DomainDataSourceManager.NewRadDomainDataSource(DataSourceName,GetDataSourceQueryName(),true);
        //    return DataSourceName;
        //}

        //private string GetDataSourceQueryName()
        //{
        //    return "Get" + this.EntitySetName + "Query";
        //}
        //--------------------------------------------
        /// <summary>
        /// Analyze the MetaData and return the appropriate column type with binding applied
        /// </summary>
        /// <param name="Item">EntityMetaData</param>
        /// <returns>string represented the column type</returns>
        /*
        private string GetColumn(EntityMetaData Item)
        {
            //string column = string.Empty;
            //switch (Item.TypeUsageName)
            //{ 
            //    case "string":
                    
            //    //case "String":
            //    default :
            //        column = "<telerik:GridViewDataColumn DataMemberBinding=\"{Binding {0}}\"  Header=\"{}\"  Width=\"Auto\" />";
            //        break;                                                          
            //}
            //return string.Format(column,Item.PropertyName,Item.Translation);
            //throw new NotImplementedException();
            

            //------------------------------ First Template---------------------------------------------------------------------
             //<telerik:GridViewDataColumn Header="" DataMemberBinding="{Binding uniteprice, Mode=TwoWay}" TextAlignment="Right">
             //       <telerik:GridViewDataColumn.CellTemplate>
             //           <DataTemplate>
             //               <TextBlock Text="{Binding {} }" />
             //           </DataTemplate>
             //       </telerik:GridViewDataColumn.CellTemplate>
             //       <telerik:GridViewDataColumn.CellEditTemplate>
             //           <DataTemplate>
             //               <TextBox Text="{Binding {}, Mode=TwoWay}" />                                
             //           </DataTemplate>
             //       </telerik:GridViewDataColumn.CellEditTemplate>              
             //   </telerik:GridViewDataColumn>
             //   <telerik:GridViewComboBoxColumn>
            string TextBlockTextBoxTemplate =
                " <telerik:GridViewDataColumn Header=\"{0}\" DataMemberBinding=\"{{Binding {1}, Mode=TwoWay}}\" TextAlignment=\"Right\">\n" +
                 " <telerik:GridViewDataColumn.CellTemplate>\n" +
                      "<DataTemplate>\n" +
                          "<TextBlock Text=\"{{Binding {1} }}\" />\n" +
                      "</DataTemplate>\n" +
                  "</telerik:GridViewDataColumn.CellTemplate>\n" +
                  "<telerik:GridViewDataColumn.CellEditTemplate>\n" +
                      "<DataTemplate>\n" +
                          "<TextBox Text=\"{{Binding {1}, Mode=TwoWay}}\" />\n" +
                      "</DataTemplate>\n" +
                  "</telerik:GridViewDataColumn.CellEditTemplate>\n" +
              "</telerik:GridViewDataColumn>\n";
               



            //<telerik:GridViewDataColumn Header="Discontinued"
            //            DataMemberBinding="{Binding Discontinued, Mode=TwoWay}"
            //            TextAlignment="Center">
            //        <telerik:GridViewDataColumn.CellTemplate>
            //            <DataTemplate>
            //                <CheckBox IsChecked="{Binding Discontinued}" IsEnabled="False" />
            //            </DataTemplate>
            //        </telerik:GridViewDataColumn.CellTemplate>
            //        <telerik:GridViewDataColumn.CellEditTemplate>
            //            <DataTemplate>
            //                <CheckBox  Margin="5, 0, 0, 0"
            //                        VerticalAlignment="Center"
            //                        IsChecked="{Binding Discontinued, Mode=TwoWay}" />
            //            </DataTemplate>
            //        </telerik:GridViewDataColumn.CellEditTemplate>
            //    </telerik:GridViewDataColumn>
              string CheckboxTemplate = 
                  "<telerik:GridViewDataColumn Header=\"{0}\"\n" +
                          "DataMemberBinding=\"{{Binding {1}, Mode=TwoWay}}\"\n" +
                          "TextAlignment=\"Center\">\n" +
                      "<telerik:GridViewDataColumn.CellTemplate>\n" +
                          "<DataTemplate>\n" +
                              "<CheckBox IsChecked=\"{{Binding {1}}}\" IsEnabled=\"False\" />\n" +
                          "</DataTemplate>\n" +
                      "</telerik:GridViewDataColumn.CellTemplate>\n" +
                      "<telerik:GridViewDataColumn.CellEditTemplate>\n" +
                          "<DataTemplate>\n" +
                              "<CheckBox  Margin=\"5, 0, 0, 0\"\n" +
                                      "VerticalAlignment=\"Center\"\n" +
                                      "IsChecked=\"{{Binding {1}, Mode=TwoWay}}\" />\n" +
                          "</DataTemplate>\n" +
                      "</telerik:GridViewDataColumn.CellEditTemplate>\n" +
                  "</telerik:GridViewDataColumn>\n";


            //<telerik:GridViewComboBoxColumn Header="Driver" 
            //                       DataMemberBinding="{Binding DriverID}"
            //                       UniqueName="Driver"
            //                       ItemsSourceBinding="{Binding CurrentDrivers}"
            //                       SelectedValueMemberPath="ID"
            //                       DisplayMemberPath="Name" />

              string ComboBoxTemplate =
                 "<telerik:GridViewComboBoxColumn Header=\"{0}\" \n" +
                                     "DataMemberBinding=\"{{Binding {1}}}\"\n" +
                                     "ItemsSource=\"{Binding {2}}\""+
                                     "UniqueName=\"{3}\"" +
                                     "ItemsSourceBinding=\"{{Binding {4}}}\"\n" +
                                     "SelectedValueMemberPath=\"{5}\"\n" +
                                     "DisplayMemberPath=\"{6}\" />\n";
              string ComboBoxTemplate2 =
                   "<telerik:GridViewComboBoxColumn Header=\"{0}\" \n" +
                                       "DataMemberBinding=\"{{Binding {1} , Mode=TwoWay}}\"\n" +
                                       "UniqueName=\"{2}\"\n" +
                                       "ItemsSource=\"{{Binding DataView, ElementName={3}}}\"\n" +
                                       "SelectedValueMemberPath=\"{4}\"\n" +
                                       "DisplayMemberPath=\"{5}\" />\n";

            //---------- Button Template
                //<telerik:GridViewDataColumn>
                //    <telerik:GridViewDataColumn.CellTemplate>
                //        <DataTemplate>
                //            <Button Content="HI" />
                //        </DataTemplate>
                //    </telerik:GridViewDataColumn.CellTemplate>
                //</telerik:GridViewDataColumn>
              string ButtonTemplate =
                      "<telerik:GridViewDataColumn>\n" +
                      "<telerik:GridViewDataColumn.CellTemplate>\n" +
                          "<DataTemplate>\n" +
                              "<Button Content=\"{0}\" />\n" +
                          "</DataTemplate>\n" +
                      "</telerik:GridViewDataColumn.CellTemplate>\n" +
                  "</telerik:GridViewDataColumn>\n";

              string VirtualNoBindingTemplate = "<telerik:GridViewDataColumn Header=\"{0}\" >\n" +
                        "<telerik:GridViewDataColumn.CellTemplate>\n" +
                            "<DataTemplate>\n" +
                                "<TextBox/>\n" +
                            "</DataTemplate>\n" +
                        "</telerik:GridViewDataColumn.CellTemplate>\n" +
                    "</telerik:GridViewDataColumn>\n";


            

              if (Item.IsVirtual == true)
              {
                  if (Item.IsButton == true)
                  {
                      return string.Format(ButtonTemplate,Item.Translation);
                  }
                  else
                  {
                      return string.Format(VirtualNoBindingTemplate, Item.Translation);
                  }
              }
              else if (Item.IsList==true)
              {
                  if (Item.IsForeignKey == true) //load the list from foregin key entity
                  {
                      string column = string.Empty;
                      //string ListEntityName = Item.ListTableName;
                      EntitySet entity = DAL.DAL.GetEntitySetByEntitySetTypeName(Item.ForeignEntityType);
                      string DataSourceName = this.DomainDataSourceManager.GetComboBoxDomainDataSourceName(entity);
                      column = string.Format(ComboBoxTemplate2, Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, entity.EntityKey, Item.DisplayMemberName);
                      return column; 
                  }
                  else // load the list from the referenced entity name
                  {
                     
                      //"<telerik:GridViewComboBoxColumn Header=\"{0}\" \n" +
                      //                 "DataMemberBinding=\"{{Binding {1}}}\"\n" +
                      //                 "UniqueName=\"{2}\"\n" +
                      //                 "ItemsSource=\"{{Binding {3}}}\"\n" +
                      //                 "SelectedValueMemberPath=\"{4}\"\n" +
                      //                 "DisplayMemberPath=\"{5}\" />\n";                                                          
                                            
                      string column = string.Empty;
                      string ListEntityName = Item.ListTableName;
                      EntitySet entity = DAL.DAL.GetEntitySetByEntitySetTypeName(ListEntityName);
                      string DataSourceName = this.DomainDataSourceManager.GetComboBoxDomainDataSourceName(entity);
                      column = string.Format(ComboBoxTemplate2, Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, entity.EntityKey, Item.DisplayMemberName);
                      return column;                      
                  }
              }
              else
              {
                  string Column = string.Empty;
                  switch (Item.TypeUsageName)
                  {
                      case "int32":
                      case "Int32":
                      case "int":
                          Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName);
                          break;
                      case "string":
                      case "String":
                          Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName);
                          break;
                      case "Boolean":
                      case "bool":
                          Column = string.Format(CheckboxTemplate, Item.Translation, Item.PropertyName);
                          break;
                      case "DateTime":
                          Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName);
                          break;                          
                      default:
                          Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName);
                          break;

                  }
                  return Column;
              }



        }
        */
        private string GetColumn(EntityMetaData Item)
        {
            string GridViewColumnSecurityTemplate = " IsVisible=\"{{Binding  Converter={{StaticResource SecurityConverter}},ConverterParameter=BooleanVisibility_{0}}}\"\n" +
                " IsReadOnly=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=IsReadOnly_{0}}}\"\n";
            string GridViewHeaderSecurityTemplate = " IsReadOnly=\"{{Binding IsFormReadOnly}}\" ";
            string ButtonSecurityTemplate = " Visibility=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=Visibility_{0}}}\" \n";





            //string column = string.Empty;
            //switch (Item.TypeUsageName)
            //{ 
            //    case "string":

            //    //case "String":
            //    default :
            //        column = "<telerik:GridViewDataColumn DataMemberBinding=\"{Binding {0}}\"  Header=\"{}\"  Width=\"Auto\" />";
            //        break;                                                          
            //}
            //return string.Format(column,Item.PropertyName,Item.Translation);
            //throw new NotImplementedException();


            //------------------------------ First Template---------------------------------------------------------------------
            //<telerik:GridViewDataColumn Header="" DataMemberBinding="{Binding uniteprice, Mode=TwoWay}" TextAlignment="Right">
            //       <telerik:GridViewDataColumn.CellTemplate>
            //           <DataTemplate>
            //               <TextBlock Text="{Binding {} }" />
            //           </DataTemplate>
            //       </telerik:GridViewDataColumn.CellTemplate>
            //       <telerik:GridViewDataColumn.CellEditTemplate>
            //           <DataTemplate>
            //               <TextBox Text="{Binding {}, Mode=TwoWay}" />                                
            //           </DataTemplate>
            //       </telerik:GridViewDataColumn.CellEditTemplate>              
            //   </telerik:GridViewDataColumn>
            //   <telerik:GridViewComboBoxColumn>
            string TextBlockTextBoxTemplate =
                " <telerik:GridViewDataColumn Header=\"{0}\" DataMemberBinding=\"{{Binding {1}, Mode=TwoWay}}\" {2} TextAlignment=\"Right\">\n" +
                 " <telerik:GridViewDataColumn.CellTemplate>\n" +
                      "<DataTemplate>\n" +
                          "<TextBlock Text=\"{{Binding {1} }}\" />\n" +
                      "</DataTemplate>\n" +
                  "</telerik:GridViewDataColumn.CellTemplate>\n" +
                  "<telerik:GridViewDataColumn.CellEditTemplate>\n" +
                      "<DataTemplate>\n" +
                          "<TextBox Text=\"{{Binding {1}, Mode=TwoWay}}\" />\n" +
                      "</DataTemplate>\n" +
                  "</telerik:GridViewDataColumn.CellEditTemplate>\n" +
              "</telerik:GridViewDataColumn>\n";




            //<telerik:GridViewDataColumn Header="Discontinued"
            //            DataMemberBinding="{Binding Discontinued, Mode=TwoWay}"
            //            TextAlignment="Center">
            //        <telerik:GridViewDataColumn.CellTemplate>
            //            <DataTemplate>
            //                <CheckBox IsChecked="{Binding Discontinued}" IsEnabled="False" />
            //            </DataTemplate>
            //        </telerik:GridViewDataColumn.CellTemplate>
            //        <telerik:GridViewDataColumn.CellEditTemplate>
            //            <DataTemplate>
            //                <CheckBox  Margin="5, 0, 0, 0"
            //                        VerticalAlignment="Center"
            //                        IsChecked="{Binding Discontinued, Mode=TwoWay}" />
            //            </DataTemplate>
            //        </telerik:GridViewDataColumn.CellEditTemplate>
            //    </telerik:GridViewDataColumn>
            string CheckboxTemplate =
                "<telerik:GridViewCheckBoxColumn Header=\"{0}\"\n" +
                        " {2}  DataMemberBinding=\"{{Binding {1}, Mode=TwoWay}}\"\n" +
                        "TextAlignment=\"Center\">\n" +
                    "<telerik:GridViewCheckBoxColumn.CellTemplate>\n" +
                        "<DataTemplate>\n" +
                            "<CheckBox IsChecked=\"{{Binding {1}}}\" />\n" +
                        "</DataTemplate>\n" +
                    "</telerik:GridViewCheckBoxColumn.CellTemplate>\n" +
                    "<telerik:GridViewCheckBoxColumn.CellEditTemplate>\n" +
                        "<DataTemplate>\n" +
                            "<CheckBox  Margin=\"5, 0, 0, 0\"\n" +
                                    "VerticalAlignment=\"Center\"\n" +
                                    "IsChecked=\"{{Binding {1}, Mode=TwoWay}}\" />\n" +
                        "</DataTemplate>\n" +
                    "</telerik:GridViewCheckBoxColumn.CellEditTemplate>\n" +
                "</telerik:GridViewCheckBoxColumn>\n";


            //<telerik:GridViewComboBoxColumn Header="Driver" 
            //                       DataMemberBinding="{Binding DriverID}"
            //                       UniqueName="Driver"
            //                       ItemsSourceBinding="{Binding CurrentDrivers}"
            //                       SelectedValueMemberPath="ID"
            //                       DisplayMemberPath="Name" />

            string ComboBoxTemplate =
               "<telerik:GridViewComboBoxColumn Header=\"{0}\" \n" +
                                   " {7}   DataMemberBinding=\"{{Binding {1}}}\"\n" +
                                   "ItemsSource=\"{Binding {2}}\"" +
                                   "UniqueName=\"{3}\"" +
                                   "ItemsSourceBinding=\"{{Binding {4}}}\"\n" +
                                   "SelectedValueMemberPath=\"{5}\"\n" +
                                   "DisplayMemberPath=\"{6}\" />\n";
            string ComboBoxTemplate2 =
                 "<telerik:GridViewComboBoxColumn Header=\"{0}\" \n" +
                                     "  {6}  DataMemberBinding=\"{{Binding {1} , Mode=TwoWay}}\"\n" +
                                     "UniqueName=\"{2}\"\n" +
                                     "ItemsSource=\"{{Binding DataView, ElementName={3}}}\"\n" +
                                     "SelectedValueMemberPath=\"{4}\"\n" +
                                     "DisplayMemberPath=\"{5}\" />\n";

            //---------- Button Template
            //<telerik:GridViewDataColumn>
            //    <telerik:GridViewDataColumn.CellTemplate>
            //        <DataTemplate>
            //            <Button Content="HI" />
            //        </DataTemplate>
            //    </telerik:GridViewDataColumn.CellTemplate>
            //</telerik:GridViewDataColumn>
            string ButtonTemplate =
                    "<telerik:GridViewDataColumn {1} >\n" +
                    "<telerik:GridViewDataColumn.CellTemplate>\n" +
                        "<DataTemplate>\n" +
                            "<Button Content=\"{0}\" />\n" +
                        "</DataTemplate>\n" +
                    "</telerik:GridViewDataColumn.CellTemplate>\n" +
                "</telerik:GridViewDataColumn>\n";

            string VirtualNoBindingTemplate = "<telerik:GridViewDataColumn {1} Header=\"{0}\" >\n" +
                      "<telerik:GridViewDataColumn.CellTemplate>\n" +
                          "<DataTemplate>\n" +
                              "<TextBox/>\n" +
                          "</DataTemplate>\n" +
                      "</telerik:GridViewDataColumn.CellTemplate>\n" +
                  "</telerik:GridViewDataColumn>\n";
            //string PersianCalendarTemplate =
            //        "<telerik:GridViewDataColumn DataMemberBinding=\"{{Binding {1}}}\" Header=\"{0}\" \n {2}\n" +
            //        "Width=\"Auto\" >\n" +
            //        "   <telerik:GridViewDataColumn.CellTemplate>\n" +
            //        "        <DataTemplate>\n" +
            //        "            <controls:DatePicker IsEnabled=\"False\" CalendarInfo=\"{StaticResource PersianCalendarInfo}\" HorizontalAlignment=\"Stretch\" SelectedDate=\"{{Binding {1}}}\"  VerticalAlignment=\"Stretch\" Width=\"183\" FontFamily=\"Tahoma\" FlowDirection=\"RightToLeft\" SelectedDateFormat=\"Long\" />\n" +
            //        "        </DataTemplate>\n" +
            //        "    </telerik:GridViewDataColumn.CellTemplate>\n" +
            //        "    <telerik:GridViewDataColumn.CellEditTemplate>\n" +
            //        "        <DataTemplate>\n" +
            //        "            <controls:DatePicker CalendarInfo=\"{StaticResource PersianCalendarInfo}\" HorizontalAlignment=\"Stretch\" SelectedDate=\"{{Binding {1}, Mode=TwoWay}}\"  VerticalAlignment=\"Stretch\" Width=\"183\" FontFamily=\"Tahoma\" FlowDirection=\"RightToLeft\" SelectedDateFormat=\"Long\" />\n" +
            //        "         </DataTemplate>\n" +
            //        "    </telerik:GridViewDataColumn.CellEditTemplate>\n" +
            //        "</telerik:GridViewDataColumn>\n";
            string PersianCalendarTemplate =
            "<telerik:GridViewDataColumn DataMemberBinding=\"{{Binding {1}}}\" Header=\"{0}\" \n {2} \n" +
            "Width=\"Auto\" >\n" +
            "   <telerik:GridViewDataColumn.CellTemplate>\n" +
            "        <DataTemplate>\n" +
            "            <controls:DatePicker IsEnabled=\"False\" CalendarInfo=\"{{StaticResource PersianCalendarInfo}}\" HorizontalAlignment=\"Stretch\" SelectedDate=\"{{Binding {1}}}\"  VerticalAlignment=\"Stretch\" Width=\"183\" FontFamily=\"Tahoma\" FlowDirection=\"RightToLeft\" SelectedDateFormat=\"Long\" />\n" +
            "        </DataTemplate>\n" +
            "    </telerik:GridViewDataColumn.CellTemplate>\n" +
            "    <telerik:GridViewDataColumn.CellEditTemplate>\n" +
            "        <DataTemplate>\n" +
            "            <controls:DatePicker CalendarInfo=\"{{StaticResource PersianCalendarInfo}}\" HorizontalAlignment=\"Stretch\" SelectedDate=\"{{Binding {1} , Mode=TwoWay}}\"  VerticalAlignment=\"Stretch\" Width=\"183\" FontFamily=\"Tahoma\" FlowDirection=\"RightToLeft\" SelectedDateFormat=\"Long\" />\n" +
            "         </DataTemplate>\n" +
            "    </telerik:GridViewDataColumn.CellEditTemplate>\n" +
            "</telerik:GridViewDataColumn>\n";



            if (Item.IsVirtual == true)
            {
                if (Item.IsButton == true)
                {
                    return string.Format(ButtonTemplate, Item.Translation, string.Format(ButtonSecurityTemplate, Item.PropertyName));
                }
                else
                {
                    return string.Format(VirtualNoBindingTemplate, Item.Translation, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                }
            }
            else if (Item.IsList == true)
            {
                if (Item.IsForeignKey == true) //load the list from foregin key entity
                {
                    string column = string.Empty;
                    //string ListEntityName = Item.ListTableName;
                    EntitySet entity = DAL.DAL.GetEntitySetByEntitySetTypeName(Item.ForeignEntityType);
                    string DataSourceName = this.DomainDataSourceManager.GetComboBoxDomainDataSourceName(entity);
                    string SelectedValueMemberPath = GetEntityKey(entity);
                    column = string.Format(ComboBoxTemplate2, Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, SelectedValueMemberPath, Item.DisplayMemberName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                    return column;
                }
                else // load the list from the referenced entity name
                {

                    //"<telerik:GridViewComboBoxColumn Header=\"{0}\" \n" +
                    //                 "DataMemberBinding=\"{{Binding {1}}}\"\n" +
                    //                 "UniqueName=\"{2}\"\n" +
                    //                 "ItemsSource=\"{{Binding {3}}}\"\n" +
                    //                 "SelectedValueMemberPath=\"{4}\"\n" +
                    //                 "DisplayMemberPath=\"{5}\" />\n";                                                          

                    string column = string.Empty;
                    string ListEntityName = Item.ListTableName;
                    EntitySet entity = DAL.DAL.GetEntitySetByEntitySetTypeName(ListEntityName);
                    string DataSourceName = this.DomainDataSourceManager.GetComboBoxDomainDataSourceName(entity);
                    string SelectedValueMemberPath = GetEntityKey(entity);
                    column = string.Format(ComboBoxTemplate2, Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, SelectedValueMemberPath, Item.DisplayMemberName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                    return column;
                }
            }
            else
            {
                string Column = string.Empty;
                switch (Item.TypeUsageName)
                {
                    case "int32":
                    case "Int32":
                    case "int":
                        Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                        break;
                    case "string":
                    case "String":
                        Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                        break;
                    case "Boolean":
                    case "bool":
                        Column = string.Format(CheckboxTemplate, Item.Translation, Item.PropertyName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                        break;
                    case "DateTime":
                        Column = string.Format(PersianCalendarTemplate, Item.Translation, Item.PropertyName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                        break;
                    default:
                        Column = string.Format(TextBlockTextBoxTemplate, Item.Translation, Item.PropertyName, string.Format(GridViewColumnSecurityTemplate, Item.PropertyName));
                        break;

                }
                return Column;
            }



        }
        #endregion

        private string GetEntityKey(EntitySet entity)
        {
            foreach (var item in entity.EntityMetaData)
            {
                var Item = item as EntityMetaData;
                if (Item.IsKey == true)
                {
                    return Item.PropertyName;
                }
            }
            throw new Exception((entity as EntitySet).EntityTypeName+" : No Primary Key Found!");
        }

    }
}
