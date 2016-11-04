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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IntegratedSystem.Web;

namespace IntegratedSystem
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Accounting/Acct_Ac_tblHesabGorohMMD2", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var selected =EntitySetsRadGrid.SelectedItems;
            foreach (var item in selected)
            {
                var Item = item as EntitySet;
                MessageBox.Show(Item.EntityTypeName);
            }
        }
        
    }
}