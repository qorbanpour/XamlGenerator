using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamlGenerator.DataSourceManager
{
    interface IDataSourceManager
    {
         void GetNewDomainDataSource(string Name, string QueryName, bool AutoLoad);
         string GetDataSourceXaml();
         string GetDataSourceCodeBehindMethods();
         string GetDataSourceNameSpace();
         string GetDomainDataSourceName();
         string GetDataSourceQueryName();
         string GetDetailsDomainDataSourceName(string ParameterName, string BindingPath, string MasterGridName, string ParentName);
         void  GetNewDetailsDomainDataSource(string Name, string QueryName, bool AutoLoad, string ParameterName, string BindingPath, string MasterGridName);
         string GetDetailsDataSourceQueryName(string ParentName);
         void UpdateEntityInfo(string EntityTypeName, string EntitySetName);
         void SetMasterEntitySetTypeName(string ParentEntitySetName);
         string GetComboBoxDomainDataSourceName(EntitySet entitySet);
         void GetNewComboBoxDomainDataSource(string Name, string QueryName, bool AutoLoad);
     
    }
}
