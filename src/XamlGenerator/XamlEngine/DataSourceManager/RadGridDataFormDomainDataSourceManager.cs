using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.Component;

namespace XamlGenerator.DataSourceManager
{
    class RadGridDataFormDomainDataSourceManager : IDataSourceManager
    {
        #region Property
        private Dictionary<string, RadDomainDataSource> DataSources; //-- key: Query Name, Value: stored RadDomainDataSource, if any
        private string EntityTypeName { get; set; }
        private string EntitySetName { get; set; }
        
      
        #endregion


        #region Constructor
        public RadGridDataFormDomainDataSourceManager(string EntityTypeName, string EntitySetName)
        {
            this.EntitySetName = EntitySetName;
            this.EntityTypeName = EntityTypeName;
            this.DataSources = new Dictionary<string, RadDomainDataSource>();
            //this.dataSourceQuery = null;
        }
        #endregion

      
        public void GetNewDomainDataSource(string Name, string QueryName, bool AutoLoad)
        {
            RadDomainDataSource value = null;
            if (!this.DataSources.TryGetValue(QueryName, out value))
            {
                RadDomainDataSource radDomainDataSource = new RadDomainDataSource(Name, QueryName, AutoLoad);
                radDomainDataSource.CreateRadDomainDataSource();
                this.DataSources.Add(QueryName, radDomainDataSource);
         
            }
 
        }

        public string GetDataSourceXaml()
        {
            string retVal = string.Empty;
            foreach (var item in DataSources)
            {
                retVal += item.Value.XamlCode;
            }
            return retVal;
        }

        public string GetDataSourceCodeBehindMethods()
        {
            string retVal = string.Empty;
            foreach (var item in DataSources)
            {
                retVal += item.Value.CodeBehindMethods;
            }
            return retVal;
        }

        public string GetDataSourceNameSpace()
        {
            string retVal = string.Empty;
            foreach (var item in DataSources)
            {
                retVal = item.Value.XamlNameSpace;
                break;
            }
            return retVal;

        }

        public string GetDomainDataSourceName()
        {
            string DataSourceName = GetDataSourceQueryName() + "DataSource";
            this.GetNewDomainDataSource(DataSourceName, GetDataSourceQueryName(), true);
            return DataSourceName;
        }

        public string GetDataSourceQueryName()
        {
           
            return "Get" + this.EntitySetName + "Query";

        }

      
        public void GetNewDetailsDomainDataSource(string Name, string QueryName, bool AutoLoad, string ParameterName, string BindingPath, string MasterGridName)
        {
            throw new NotImplementedException();
        }

      
        public string GetDetailsDomainDataSourceName(string ParameterName, string BindingPath, string MasterGridName, string ParentName)
        {
            throw new NotImplementedException();
        }

        public string GetDetailsDataSourceQueryName(string ParentName)
        {
            throw new NotImplementedException();
        }


        public void UpdateEntityInfo(string EntityTypeName, string EntitySetName)
        {
            throw new NotImplementedException();
        }


        public void SetMasterEntitySetTypeName(string ParentEntitySetName)
        {
            throw new NotImplementedException();
        }


        public string GetComboBoxDomainDataSourceName(EntitySet entitySet)
        {
            string DataSourceName = "Get" + entitySet.EntitySetName + "Query" + "DataSource";
            string QueryName = "Get" + entitySet.EntitySetName + "Query";
            this.GetNewComboBoxDomainDataSource(DataSourceName, QueryName, true);
            return DataSourceName;
        }
        public void GetNewComboBoxDomainDataSource(string Name, string QueryName, bool AutoLoad)
        {
            RadDomainDataSource value = null;
            if (!this.DataSources.TryGetValue(QueryName, out value))
            {
                RadDomainDataSource radDomainDataSource = new RadDomainDataSource(Name, QueryName, AutoLoad);
                radDomainDataSource.CreateRadDomainDataSource();
                this.DataSources.Add(QueryName, radDomainDataSource);

            }

        }
    }
}
