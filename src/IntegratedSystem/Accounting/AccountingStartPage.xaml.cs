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
    public partial class CodingStartPage : Page
    {
        public CodingStartPage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void CodingStartPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Accounting/CondingStartPage", UriKind.Relative));
        }

        

    }
}
