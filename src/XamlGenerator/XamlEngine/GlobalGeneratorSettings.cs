using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamlGenerator
{
    class GlobalGeneratorSettings
    {
        public static string SilverlightProjectName { get {return _silverlightProjectName; } }
        public static string SilverlightWebProjectName { get { return _silverlightWebProjectName; } }
        public static string DomainContextName { get { return _domainContextName; } } //ex : TestDomainContext
        public static string SavePath { get { return _savePath; } }
        public static string SubSystemName { get { return _SubSystemName; } }

        private static string _silverlightProjectName="IntegratedSystem";// { get; set; }
        private static string _silverlightWebProjectName = "IntegratedSystem.Web";// { get; set; }
        private static string _domainContextName = "IntegratedSystemDomainContext";// { get; set; } //ex : TestDomainContext
        private static string _savePath = "D://xamlTest//";//
        private static string _SubSystemName = "Accounting";
        
    }
}
