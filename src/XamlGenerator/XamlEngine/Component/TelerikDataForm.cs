using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.DataSourceManager;

namespace XamlGenerator.Component
{

    //<Grid>
    //<Grid.Resources>
    //<DataTemplate x:Key="MyTemplate">
    //<Grid>
    //<Grid.ColumnDefinitions>
    //    <ColumnDefinition/>
    //    <ColumnDefinition/>
    //</Grid.ColumnDefinitions>
    //<Grid.RowDefinitions>
    //    <RowDefinition/>
    //    <RowDefinition/>
    //</Grid.RowDefinitions>
    //<telerik:DataFormDataField Label="First Name" DataMemberBinding="{Binding FirstName, Mode=TwoWay}" />
    //<telerik:DataFormDataField Grid.Column="1" Label="Last Name" DataMemberBinding="{Binding LastName, Mode=TwoWay}" />
    //<telerik:DataFormCheckBoxField Grid.Column="1" Grid.Row="1" Label="Married" DataMemberBinding="{Binding IsMarried, Mode=TwoWay}" />
    //</Grid>
    //</DataTemplate>
    //</Grid.Resources>
    //<telerik:RadDataForm x:Name="DataForm1" ItemsSource="{Binding DataView, ElementName=MyRadDomainDataSource}"
    //                        AutoGenerateFields="False"
    //                        ReadOnlyTemplate="{StaticResource MyTemplate}"
    //                        EditTemplate="{StaticResource MyTemplate}"
    //                        NewItemTemplate="{StaticResource MyTemplate}">
    //</telerik:RadDataForm>
    //</Grid>

    class TelerikDataForm
    {
        #region Property
        private int TwoColumnsLimit = 8; // 0 and TwoColumnsLimit ==> 2 column
        private bool IsTwoColumns = false;
        private int FourColumnsLimit = 9; // between Fourfield and SixColumnsLimit ==> 4 column
        private bool IsFourColumns = false;
        private int SixColumnsLimit = 14;// More than sixField ==> 6 column
        private bool IsSixColumns = false;

        public string XamlNameSpace { get; set; }
        //public string XamlDataSource { get; set; }
        public string XamlCode { get; set; }
        public string CodeBehindMethods { get; set; }
        public string DataFormName { get; set; }  //------------ = EntitySetName + "RadDataForm"
        public string EntityTypeName { get; set; }
        public string EntitySetName { get; set; }
        private IEnumerable<EntityMetaData> MetaDatas { get; set; }
        private IDataSourceManager DomainDataSourceManager { get; set; }
        private string dataSourceName = null;
        public string DataSourceName { get { return this.dataSourceName; } set { this.dataSourceName = value; } }
        # endregion
        # region Private Fields
        private string DataFormDefinition = "<telerik:RadDataForm EditEnded=\"{0}_EditEnded\" FlowDirection=\"RightToLeft\" x:Name=\"{0}\"\n" +
                          "AutoGenerateFields=\"False\"\n" +
                          "ReadOnlyTemplate=\"{{StaticResource {1}}}\"\n" +
                          "EditTemplate=\"{{StaticResource {2}}}\"\n" +
                          "NewItemTemplate=\"{{StaticResource {3}}}\"\n" +
                          "ItemsSource=\"{{Binding DataView, ElementName={4}}}\">\n" +
                          "</telerik:RadDataForm>\n";
        

        private string  EditEndTemplate=

            "private void {0}_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)\n" +
            "{{\n" +
            "       if (this.{1}.HasChanges)\n" +
            "       {{\n" +
            "            {1}.SubmitChanges();\n" +
            "       }}\n" +
            "}}\n";






        private string TemplatePattern = "<Grid>\n" +
                                            "<Grid.Resources>\n" +
                                            "<DataTemplate x:Key=\"{0}\">\n" +
                                            "<Grid>\n" +
                                            "<Grid.ColumnDefinitions>\n" +
                                                 "{3}" +                                                
                                            "</Grid.ColumnDefinitions>\n" +
                                            "<Grid.RowDefinitions>\n" +
                                                 "{1}\n" +   //------- Number of rows should be calculated based on number of field a table has
                                            "</Grid.RowDefinitions>\n" +
                                            "{2}\n" +
                                            "</Grid>\n" +
                                            "</DataTemplate>\n" +
                                            "</Grid.Resources>\n";
        #endregion
        #region Constructor
        public TelerikDataForm(string EntityTypeName, string EntitySetName, IEnumerable<EntityMetaData> MetaDatas, ref IDataSourceManager DomainDataSourceManager)
        {
            this.MetaDatas = MetaDatas.OrderBy(e => e.FieldOrder);
            this.DataFormName = EntitySetName + "RadDataForm";
            this.EntityTypeName = EntityTypeName;
            this.EntitySetName = EntitySetName;
            this.DomainDataSourceManager = DomainDataSourceManager;
            GetColumnsDefinition(MetaDatas);//just to set Is*Columns
        }
        #endregion
        #region Public Methods
        public void CreateDataFormFromMetaData()
        {
            this.CodeBehindMethods = string.Empty;
            string code_behind = string.Empty;
            string xaml = string.Empty;

            string TemplateName = DataFormName + "Template";
            xaml = string.Format(DataFormDefinition, DataFormName, TemplateName, TemplateName, TemplateName, this.DomainDataSourceManager.GetDomainDataSourceName()); //each mode :read only, edit , new item can have different template.

            string DataTemplate = GetDataTemplate(MetaDatas, TemplatePattern, TemplateName);
            this.XamlCode = DataTemplate + xaml + "</Grid>\n";
            this.CodeBehindMethods = string.Format(EditEndTemplate, this.DataFormName, this.GetDataSourceName());
        }
        #endregion        
        #region Private Method
        private string GetDataSourceName()
        {
            if (string.IsNullOrEmpty(this.DataSourceName))
            {
                return this.DomainDataSourceManager.GetDomainDataSourceName();
            }
            else
                return this.DataSourceName;
        }
        private string GetDataTemplate(IEnumerable<EntityMetaData> MetaDatas, string TemplatePattern, string TemplateName)
        {
            string RowsDefinition = GetRows(MetaDatas);
            string ColumnsDefinition = GetColumnsDefinition(MetaDatas);
            string Columns = GetColumns(MetaDatas);
            return string.Format(TemplatePattern, TemplateName, RowsDefinition, Columns,ColumnsDefinition);
        }

        private string GetColumnsDefinition(IEnumerable<EntityMetaData> MetaDatas)
        {
            int RowsCount = GetNumberOfFields(MetaDatas);
            string columns = string.Empty;
            if (RowsCount <= TwoColumnsLimit)
            {
                columns += "<ColumnDefinition/>\n<ColumnDefinition/>\n";
                IsTwoColumns = true;
            }
            else if (RowsCount >= FourColumnsLimit && RowsCount <= SixColumnsLimit)
            {
                columns += "<ColumnDefinition/>\n<ColumnDefinition/>\n" + "<ColumnDefinition/>\n<ColumnDefinition/>\n";
                IsFourColumns = true;
            }
            else
            {
                columns += "<ColumnDefinition/>\n<ColumnDefinition/>\n" + "<ColumnDefinition/>\n<ColumnDefinition/>\n" +
                    "<ColumnDefinition/>\n<ColumnDefinition/>\n";
                IsSixColumns = true;
            }
            return columns;
        }

        private string GetColumns(IEnumerable<EntityMetaData> MetaDatas)
        {
            #region Security Template
            string DataFormSecurityTemplate= " Visibility=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=Visibility_{0}}}\" \n"+
                " IsReadOnly=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=IsReadOnly_{0}}}\"\n";
            //string GridViewColumnSecurityTemplate= " IsVisible=\"{{Binding  Converter={{StaticResource SecurityConverter}},ConverterParameter=BooleanVisibility_{0}}}\"\n"+
            //    " IsReadOnly=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=IsReadOnly_{0}}}\"\n";
            //string GridViewHeaderSecurityTemplate = " IsReadOnly=\"{{Binding IsFormReadOnly}}\" ";
            //string TextBlockSecurityTemplate= "Visibility=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=Visibility_{0}}}\" \n";
            string VisibilitySecurityTemplate = "Visibility=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=Visibility_{0}}}\" \n";
            string CheckBoxSecurityTemplate = " Visibility=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=Visibility_{0}}}\" \n" +
                " IsEnabled=\"{{Binding Converter={{StaticResource SecurityConverter}},ConverterParameter=IsReadOnly_{0}}}\"\n";
            #endregion
            //int NumberOfRows = GetNumberOfFields(MetaDatas);
            //  string TextBlockTemplate = "<TextBlock Text=\"{{Binding {0} }}\"  Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3} />\n";
              string TextBlockTemplate = "<TextBlock Margin=\"10,5,5,5\" Text=\"{0}\"  Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3} />\n";
              string TextBoxTemplate = "<TextBox Margin=\"10,5,5,5\" Text=\"{{Binding {0} , Mode=TwoWay}}\" Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3} />\n";
              string CheckBoxTemplate = "<CheckBox Margin=\"10,5,5,5\" IsChecked=\"{{Binding {0},Mode=TwoWay}}\" Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3} />";
              string ButtonTemplate = "<Button Margin=\"10,5,5,5\" Content=\"{0}\" Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3} /> ";
              string VirtualNoBindingTextBox = "<TextBox Margin=\"10,5,5,5\"  Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3} />\n";

              string ComboBox2Template = "<telerik:DataFormComboBoxField Margin=\"10,5,5,5\" Label=\"{0}\"\n {8} \n" +
                                            "DataMemberBinding=\"{{Binding {1}, Mode=TwoWay}}\">\n" +
                                            "<telerik:DataFormComboBoxField.Content>\n" +
                                            "<telerik:RadComboBox x:Name=\"{2}\"\n" +
                                            "ItemsSource=\"{{Binding DataView, ElementName={3}}}\"\n" +
                                            "SelectedItem=\"{{Binding {4}, Mode=TwoWay}}\"\n" +
                                            "SelectedValue=\"{{Binding {5}}}\"\n" +
                                            "SelectedValuePath=\"{6}\"\n" +
                                            "DisplayMemberPath=\"{7}\"\n " +                                         
                                            "EmptyText=\"Please select\"/>\n" +
                                        "</telerik:DataFormComboBoxField.Content>\n" +
                                    "</telerik:DataFormComboBoxField>\n";
                string ComboBox3Template =
                    "<telerik:RadComboBox  "+
                    "             {6} Margin=\"10,5,5,5\""+
					"			  ItemsSource=\"{{Binding DataView, ElementName={5}}}\" "+
                    "             SelectedValue=\"{{Binding {4}, Mode=TwoWay}}\"" +
					"			  SelectedValuePath=\"{0}\" Grid.Row=\"{2}\" Grid.Column=\"{3}\""+
                    "             DisplayMemberPath=\"{1}\"/>";


                string PersianCalendarTemplate =
                    "            <controls:DatePicker CalendarInfo=\"{{StaticResource PersianCalendarInfo}}\" HorizontalAlignment=\"Stretch\" SelectedDate=\"{{Binding {0} , Mode=TwoWay}}\"  VerticalAlignment=\"Stretch\" Width=\"183\" FontFamily=\"Tahoma\" FlowDirection=\"RightToLeft\" SelectedDateFormat=\"Long\" Grid.Row=\"{1}\" Grid.Column=\"{2}\" {3}/>\n";




                    //"<telerik:DataFormComboBoxField {6} Margin=\"10,5,5,5\" SelectedValuePath=\"{0}\" \n" +
                    //"								   DisplayMemberPath=\"{1}\"\n" +
                    //"								   Grid.Row=\"{2}\" Grid.Column=\"{3}\"\n" +
                    //"								   DataMemberBinding=\"{{Binding {4}, Mode=TwoWay}}\"\n " +
                    //"								   ItemsSource=\"{{Binding DataView, ElementName={5}}}\" />\n";


            if (IsTwoColumns)
            {
                #region 2 column

                int GridRow = 0;

              

                string columns = string.Empty;
                foreach (var Item in MetaDatas)
                {
                    if (Item.IsInVisible == true)
                    {
                        continue;
                    }
                    if (Item.IsVirtual == true)
                    {
                        if (Item.IsButton == true)
                        {
                            columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(ButtonTemplate, Item.PropertyName, GridRow, 1, string.Format(VisibilitySecurityTemplate, Item.PropertyName));
                        }
                        else
                        {

                            columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(VirtualNoBindingTextBox, Item.PropertyName, GridRow, 1, string.Format(DataFormSecurityTemplate, Item.PropertyName));
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

                            column = string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(ComboBox3Template, entity.EntityKey, Item.DisplayMemberName, GridRow, 1, Item.PropertyName, DataSourceName, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                            //column = string.Format(ComboBox2Template , Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, entity.EntityKey, Item.DisplayMemberName);
                           // return column;
                            columns += column;
                        }
                        else // load the list from the referenced entity name
                        {
                            //        "<telerik:DataFormComboBoxField SelectedValuePath=\"{0}\" \n" +
                            //"								   DisplayMemberPath=\"{1}\"\n" +
                            //"								   Grid.Row=\"{2}\" Grid.Column=\"{3}\"\n" +
                            //"								   DataMemberBinding=\"{{Binding {4}, Mode=TwoWay}}\"\n " +
                            //"								   ItemsSource=\"{{Binding DataView, ElementName={5}}}\" />\n";




                            string column = string.Empty;
                            string ListEntityName = Item.ListTableName;
                            EntitySet entity = DAL.DAL.GetEntitySetByEntitySetTypeName(ListEntityName);
                            string DataSourceName = this.DomainDataSourceManager.GetComboBoxDomainDataSourceName(entity);
                            column = string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(ComboBox3Template, entity.EntityKey, Item.DisplayMemberName, GridRow, 1, Item.PropertyName, DataSourceName, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                            //column = string.Format(ComboBox2Template, Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, entity.EntityKey, Item.DisplayMemberName);
                            //return column;
                            columns += column;
                        }
                    }
                    else
                    {
                        switch (Item.TypeUsageName)
                        {
                            case "int32":
                            case "Int32":
                            case"Int16":
                            case "int":
                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(TextBoxTemplate, Item.PropertyName, GridRow,1,string.Format(DataFormSecurityTemplate,Item.PropertyName));
                                break;

                            case "string":
                            case "String":

                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(TextBoxTemplate, Item.PropertyName, GridRow, 1, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                                break;

                            case "Boolean":
                            case "bool":
                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(CheckBoxTemplate, Item.PropertyName, GridRow, 1, string.Format(CheckBoxSecurityTemplate, Item.PropertyName));
                                break;

                            case "DateTime":

                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(PersianCalendarTemplate, Item.PropertyName, GridRow, 1, string.Format(CheckBoxSecurityTemplate, Item.PropertyName));
                                break;



                            default:
                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, 0, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(TextBoxTemplate, Item.PropertyName, GridRow, 1, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                                break;

                        }
                    }

                    GridRow++;

                }
                return columns;
                #endregion
            }
            else
            {
                #region 4 or 6 column

                int GridRow = 0;
                int GridColumn = -1;
                string columns = string.Empty;
                foreach (var Item in MetaDatas)
                {
                    if (Item.IsInVisible == true)
                    {
                        continue;
                    }
                    if (Item.IsVirtual == true)
                    {
                        if (Item.IsButton == true)
                        {
                            columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(ButtonTemplate, Item.PropertyName, GridRow, ++GridColumn,string.Format(VisibilitySecurityTemplate,Item.PropertyName));
                        }
                        else
                        {

                            columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(VirtualNoBindingTextBox, Item.PropertyName, GridRow, ++GridColumn, string.Format(DataFormSecurityTemplate, Item.PropertyName));
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
                            column = string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(ComboBox3Template, SelectedValueMemberPath, Item.DisplayMemberName, GridRow, ++GridColumn, Item.PropertyName, DataSourceName, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                            //column = string.Format(ComboBox2Template , Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, entity.EntityKey, Item.DisplayMemberName);
                            //return column;
                            columns += columns;
                        }
                        else // load the list from the referenced entity name
                        {
                            //        "<telerik:DataFormComboBoxField SelectedValuePath=\"{0}\" \n" +
                            //"								   DisplayMemberPath=\"{1}\"\n" +
                            //"								   Grid.Row=\"{2}\" Grid.Column=\"{3}\"\n" +
                            //"								   DataMemberBinding=\"{{Binding {4}, Mode=TwoWay}}\"\n " +
                            //"								   ItemsSource=\"{{Binding DataView, ElementName={5}}}\" />\n";




                            string column = string.Empty;
                            string ListEntityName = Item.ListTableName;
                            EntitySet entity = DAL.DAL.GetEntitySetByEntitySetTypeName(ListEntityName);
                            string DataSourceName = this.DomainDataSourceManager.GetComboBoxDomainDataSourceName(entity);
                            string SelectedValueMemberPath = GetEntityKey(entity);
                            column = string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(ComboBox3Template, SelectedValueMemberPath, Item.DisplayMemberName, GridRow, ++GridColumn, Item.PropertyName, DataSourceName, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                            //column = string.Format(ComboBox2Template, Item.Translation, Item.PropertyName, Item.Translation, DataSourceName, entity.EntityKey, Item.DisplayMemberName);
                         //  return column;
                            columns += column;
                        }
                    }
                    else
                    {
                        switch (Item.TypeUsageName)
                        {
                            case "int32":
                            case "Int32":
                            case "int":
                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(TextBoxTemplate, Item.PropertyName, GridRow, ++GridColumn, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                                break;

                            case "string":
                            case "String":

                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(TextBoxTemplate, Item.PropertyName, GridRow, ++GridColumn, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                                break;

                            case "Boolean":
                            case "bool":
                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(CheckBoxTemplate, Item.PropertyName, GridRow, ++GridColumn, string.Format(CheckBoxSecurityTemplate, Item.PropertyName));
                                break;

                            case "DateTime":

                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(PersianCalendarTemplate, Item.PropertyName, GridRow, ++GridColumn, string.Format(CheckBoxSecurityTemplate, Item.PropertyName));
                                break;



                            default:
                                columns += string.Format(TextBlockTemplate, Item.Translation, GridRow, ++GridColumn, string.Format(VisibilitySecurityTemplate, Item.PropertyName)) +
                                string.Format(TextBoxTemplate, Item.PropertyName, GridRow, ++GridColumn, string.Format(DataFormSecurityTemplate, Item.PropertyName));
                                break;

                        }
                    }

                    
                    if (IsFourColumns)
                    {
                        if (GridColumn == 3)
                        {
                            GridColumn = -1;
                            GridRow++;
                        }
                    }
                    if (IsSixColumns)
                    {
                        if (GridColumn == 5)
                        {
                            GridColumn = -1;
                            GridRow++;
                        }
                    }

                }
                return columns;
                #endregion
            }

        }

        /// <summary>
        /// This method used for internal layout of the Data Grid data template.
        /// </summary>
        /// <param name="MetaDatas"></param>
        /// <returns></returns>
        private string GetRows(IEnumerable<EntityMetaData> MetaDatas)
        {
            string Rows = string.Empty;
            if (IsTwoColumns)
            {
                foreach (var item in MetaDatas)
                {
                    if (!(item.IsInVisible == true))
                    {
                        Rows += "<RowDefinition/>\n";
                    }
                }
            }
            else if (IsFourColumns)
            {
                int i = 0;
                foreach (var item in MetaDatas)
                {
                    if (!(item.IsInVisible == true))
                    {
                        if (i % 2 == 0)
                        {
                            Rows += "<RowDefinition/>\n";
                        }
                        i++;
                    }
                }
                Rows += "<RowDefinition/>\n";
            }
            else if (IsSixColumns)
            {
                int i = 0;
                foreach (var item in MetaDatas)
                {
                    if (!(item.IsInVisible == true))
                    {
                        if (i % 3 == 0)
                        {
                            Rows += "<RowDefinition/>\n";
                        }
                        i++;
                    }
                }
                Rows += "<RowDefinition/>\n";
            }
            else // if is*Column is not set yet
            {
                throw new Exception(); 
            }
            return Rows;
        }

        private int GetNumberOfFields(IEnumerable<EntityMetaData> MetaDatas)
        {

            int Rows = 0;
            foreach (var item in MetaDatas)
            {
                if (!(item.IsInVisible == true))
                    Rows++;
            }
            return Rows;
        }

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
            throw new Exception("No Primary Key Found!");
        }

        //------------------------ Moved to DataSourceManager-----------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------
       
        #endregion
    }
}
