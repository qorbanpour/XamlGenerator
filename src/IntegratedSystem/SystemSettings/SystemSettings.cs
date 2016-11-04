using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace IntegratedSystem.SystemSettings
{
    public class Settings
    {
        #region Navigate To Special Page
        public static void NavigateToInvalidAcess(NavigationService service, string SubSystemName,string Parameter)
        {
            service.Navigate(GetInvalidAccessUri(SubSystemName, Parameter));
        }
        public static void NavigateToAccessDenied(NavigationService service, string SubSystemName, string Parameter)
        {
            service.Navigate(GetAccessDeniedUri(SubSystemName, Parameter));
        }

        private static Uri GetAccessDeniedUri(string SubSystemName,string Parameter)
        {
            return new Uri("/AccessDenied", UriKind.Relative);
        }

        private static Uri GetInvalidAccessUri(string SubSystemName, string Parameter)
        {
            return new Uri("/InvalidAccess", UriKind.Relative);
        }
        #endregion

        #region ClientId
        public static int GetClientId()
        {
            return 1;
        }
        #endregion

        public static DateTime ClientNow()
        {
            //----- This should be change later
            return DateTime.Now;
        }

        public static int GetUserID()
        {
            return 1;
        }

        internal static int GetOraganizationID()
        {
            return 1;
        }
    }
}
