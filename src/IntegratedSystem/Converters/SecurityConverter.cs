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
using System.Windows.Data;

namespace IntegratedSystem
{
    public class SecurityConverter : IValueConverter
    {
        private static Security securityObj ;
        public static Security SecurityObj { set { securityObj = value; } }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value.GetType() == typeof(Security))
            {

                securityObj = value as Security;
            }

            if (parameter == null)
            {
                return ((bool)value == true) ? Visibility.Visible : Visibility.Collapsed;

            }


            else
            {

               

               
                String parameterString = parameter.ToString();
                if (parameterString.Equals("Initialization")) {

                    return Visibility.Visible;
                }
                else if (parameterString.Equals("IsFormReadOnly")) {

                    return securityObj.IsFormReadOnly;
                
                }
                else if (parameterString.StartsWith("Visibility_"))
                {

                    String propertyName = parameterString.Substring("Visibility_".Length);
                    if (value.GetType() == typeof(Security))
                    {
                        return (value as Security).IsPropertyVisible(propertyName) ? Visibility.Visible : Visibility.Collapsed; ;
                    }
                    else
                    {
                        return securityObj.IsPropertyVisible(propertyName) ? Visibility.Visible : Visibility.Collapsed; ;
                    }

                }
                else if (parameterString.StartsWith("BooleanVisibility_"))
                {

                    String propertyName = parameterString.Substring("BooleanVisibility_".Length);
                    if (value.GetType() == typeof(Security))
                    {
                        return (value as Security).IsPropertyVisible(propertyName);
                    }
                    else
                    {
                        return securityObj.IsPropertyVisible(propertyName);
                    }



                }

                else if (parameterString.StartsWith("IsReadOnly_"))
                {

                    String propertyName = parameterString.Substring("IsReadOnly_".Length);
                    if (value.GetType() == typeof(Security))
                    {
                        return (value as Security).IsPropertyReadOnly(propertyName);
                    }
                    else
                    {
                        return securityObj.IsPropertyReadOnly(propertyName);
                    }

                }
               
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
