using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace IntegratedSystem
{
    public partial class CondingStartPage : Page
    {
        public CondingStartPage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void AddGorooh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabGorohMMD2", UriKind.Relative));
        }

        private void AddGoroohTafsily_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblGoroohTafsilyMMD2", UriKind.Relative));
            
        }

        private void addGoroohMarkazButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblGoroohMarakezMMD2", UriKind.Relative));
            
        }

    }
}
