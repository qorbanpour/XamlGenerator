using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamlGenerator.Component
{
    class RadDomainDataSource
    {
        //    <telerik:RadDomainDataSource x:Name="userDataSource" 
        //                                 AutoLoad="True"
        //                                 DataSourceName="GetUsersQuery" 
        //                                 >
        //        <telerik:RadDomainDataSource.DomainContext>
        //            <e:TestDomainContext />
        //        </telerik:RadDomainDataSource.DomainContext>
        //    </telerik:RadDomainDataSource>



        //--Details Grid
        //<telerik:RadDomainDataSource x:Name="detailOrdersDataSource" 
        //                             AutoLoad="False" 
        //                             DataSourceName="GetOrdersByCustomerID" >
        //    <telerik:RadDomainDataSource.DomainContext>
        //        <e:NorthwindDomainContext />
        //    </telerik:RadDomainDataSource.DomainContext>
        //    <telerik:RadDomainDataSource.QueryParameters>
        //        <telerik:QueryParameter ParameterName="customerID" Value="{Binding SelectedItem.CustomerID, ElementName=masterGridView}" />
        //    </telerik:RadDomainDataSource.QueryParameters>
        //</telerik:RadDomainDataSource>

        public string XamlNameSpace { get; private set; }
        public string XamlCode { get; private set; }
        public string CodeBehindMethods { get; private set; }
        private string WebProjectName { get; set; }
        private string Name { get; set; }
        private bool AutoLoad { get; set; }
        private string QueryName { get; set; }



        public RadDomainDataSource(string Name, string QueryName, bool AutoLoad)
        {
            this.CodeBehindMethods = string.Empty;
            this.WebProjectName = GlobalGeneratorSettings.SilverlightWebProjectName;
            this.XamlNameSpace = string.Format(" xmlns:e=\"clr-namespace:{0}\" ", WebProjectName);
            this.XamlNameSpace += " xmlns:telerik=\"http://schemas.telerik.com/2008/xaml/presentation\" ";
            this.Name = Name;
            this.QueryName = QueryName;
            this.AutoLoad = AutoLoad;

        }


        public void CreateRadDomainDataSource()
        {

            string xaml = " <telerik:RadDomainDataSource x:Name=\"{0}\"\n" +
                "AutoLoad=\"{1}\"\n" +
                "QueryName=\"{2}\" >\n" +
                "<telerik:RadDomainDataSource.DomainContext>\n" +
                "<e:{3} />" +
                "</telerik:RadDomainDataSource.DomainContext>\n" +
                "</telerik:RadDomainDataSource>\n";

            this.XamlCode = string.Format(xaml, this.Name, this.AutoLoad, this.QueryName, GlobalGeneratorSettings.DomainContextName);

        }
        public void CreateRadDomainDataSourceWithParameter(string ParameterName, string BindingPath, string MasterGridName)
        {
            string xaml = "<telerik:RadDomainDataSource x:Name=\"{0}\" \n" +
                                     "AutoLoad=\"True\" \n" +
                                     "QueryName=\"{1}\" >\n" +
                        "<telerik:RadDomainDataSource.DomainContext>\n" +
                        "<e:{5} />\n" +
                        "</telerik:RadDomainDataSource.DomainContext>\n" +
                        "<telerik:RadDomainDataSource.QueryParameters>\n" +
                        "<telerik:QueryParameter ParameterName=\"{2}\" Value=\"{{Binding {3}, ElementName={4}}}\" />\n" +
                        "</telerik:RadDomainDataSource.QueryParameters>\n" +
                        "</telerik:RadDomainDataSource>\n";

            this.XamlCode = string.Format(xaml, this.Name, this.QueryName, ParameterName, BindingPath, MasterGridName, GlobalGeneratorSettings.DomainContextName);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        public void CreateRadDomainDataSourceWithParameterInCodeBehind(string ParameterName)
        {

            //string xaml = " <telerik:RadDomainDataSource x:Name=\"{0}\"\n" +
            //    "AutoLoad=\"{1}\"\n" +
            //    "QueryName=\"{2}\" >\n" +
            //    "<telerik:RadDomainDataSource.DomainContext>\n" +
            //    "<e:{3} />" +
            //    "</telerik:RadDomainDataSource.DomainContext>\n" +
            //    "</telerik:RadDomainDataSource>\n";

            string xaml = " <telerik:RadDomainDataSource x:Name=\"{0}\"\n" +
          "AutoLoad=\"{1}\"\n" +
          "QueryName=\"{2}\" >\n" +
          "<telerik:RadDomainDataSource.DomainContext>\n" +
          "<e:{3} />" +
          "</telerik:RadDomainDataSource.DomainContext>\n" +
            "<telerik:RadDomainDataSource.QueryParameters>\n" +
                        "<telerik:QueryParameter ParameterName=\"{4}\"  />\n" +
                        "</telerik:RadDomainDataSource.QueryParameters>\n" +
          "</telerik:RadDomainDataSource>\n";

            this.XamlCode = string.Format(xaml, this.Name, this.AutoLoad, this.QueryName, GlobalGeneratorSettings.DomainContextName, ParameterName);
            string codeBehind =
                "protected override void OnNavigatedTo(NavigationEventArgs e)\n" +
                "{{\n" +


                "    if(PageSecurity.IsFormAccessValid == false)\n " +
                "       SystemSettings.Settings.NavigateToAccessDenied(this.NavigationService, null, null);\n" +
                "    else if (false) // Check to see if query string contains appropriate keys\n" +
                "    {{" +
                "          // Read Query String Here        \n" +

                "      //  {0}.QueryParameters.Add(\n" +
                "      //  new QueryParameter()\n" +
                "      //    {{\n" +
                "      //         ParameterName = \"{1}\",\n" +
                "      //         Value = NavigationContext.QueryString[\"{1}\"]\n" +
                "      //    }});\n" +

                "    }}\n" +

                "    else\n" +
                "    {{\n" +
                "           SystemSettings.Settings.NavigateToInvalidAccess(this.NavigationService, null, null);\n" +
                "    }}\n" +

                " }}\n";
            this.CodeBehindMethods = string.Format(codeBehind, this.Name, ParameterName);

        }



    }
}
