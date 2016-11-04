using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.Component;

namespace XamlGenerator.DataSourceManager
{
    class RadMasterDetailsGridDomainDataSourceManager : IDataSourceManager
    {
        #region Property
        private Dictionary<string, RadDomainDataSource> DataSources; //-- key: Query Name, Value: stored RadDomainDataSource, if any
        private string EntityTypeName { get; set; }
        private string EntitySetName { get; set; }
        private string ParentEntitySetName { get; set; }
        #endregion

        #region Constructor
        public RadMasterDetailsGridDomainDataSourceManager(string EntityTypeName, string EntitySetName)
        {
            this.EntitySetName = EntitySetName;
            this.EntityTypeName = EntityTypeName;
            this.DataSources = new Dictionary<string,RadDomainDataSource>();
        }
        #endregion
        /// <summary>
        /// Pass the master entityset to this method. this information is required for building details domain data source
        /// </summary>
        /// <param name="ParentEntitySetName"></param>
        public void SetMasterEntitySetTypeName(string ParentEntitySetName)
        {
            this.ParentEntitySetName = ParentEntitySetName;
        }

        public void UpdateEntityInfo(string EntityTypeName, string EntitySetName)
        {
            this.EntitySetName = EntitySetName;
            this.EntityTypeName = EntityTypeName;
        }

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

        public string GetDetailsDomainDataSourceName(string ParameterName, string BindingPath, string MasterGridName,string ChildName)
        {
            string DataSourceName = GetDetailsDataSourceQueryName(ChildName) + "DataSource";
            this.GetNewDetailsDomainDataSource(DataSourceName, GetDetailsDataSourceQueryName(ChildName), true, ParameterName, BindingPath, MasterGridName);
            return DataSourceName;
        }

        public void GetNewDetailsDomainDataSource(string Name, string QueryName, bool AutoLoad, string ParameterName, string BindingPath, string MasterGridName)
        {
            RadDomainDataSource value = null;
            if (!this.DataSources.TryGetValue(QueryName, out value))
            {
                RadDomainDataSource radDomainDataSource = new RadDomainDataSource(Name, QueryName, AutoLoad);
                radDomainDataSource.CreateRadDomainDataSourceWithParameter(ParameterName, BindingPath, MasterGridName);
                this.DataSources.Add(QueryName, radDomainDataSource);
            }
        }

        public string GetDetailsDataSourceQueryName(string ChildName)
        {
            return "Get" + ChildName + "By" + this.ParentEntitySetName + "Query";
        }
        //--------------
        public string GetComboBoxDomainDataSourceName(EntitySet entitySet)
        {            
            string DataSourceName ="Get"+entitySet.EntitySetName+"Query" + "DataSource";
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
