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
using IntegratedSystem.Web;
using System.ServiceModel.DomainServices.Client;


namespace IntegratedSystem
{
    public partial class UpdateMetaData : Page
    {
        static int Result = 0;
        IntegratedSystemDomainContext ctx = new IntegratedSystemDomainContext();
        public UpdateMetaData()
        {
            InitializeComponent();
            ctx.Load<IntegratedSystem.Web.EntitySet>(ctx.GetEntitySetsQuery(), LoadList, null);

        }

        public void LoadList(LoadOperation lo)
        {

            List<ListBoxItem> items = new List<ListBoxItem>();
            foreach (var item in lo.Entities)
            {
                ListBoxItem boxItem = new ListBoxItem();
                boxItem.Content = (item as IntegratedSystem.Web.EntitySet).EntityTypeName;
                boxItem.Tag = item;
                items.Add(boxItem);


            }


            MyList.ItemsSource = items;

        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void updateClicked(object sender, RoutedEventArgs e)
        {

            //if(MyList == null)
            // MessageBox.Show("1");
            //if(MyList.SelectedItems == null)
            //    MessageBox.Show("2");
            //else
            //    MessageBox.Show("C:"+MyList.SelectedItems.Count);           

            foreach (var item in MyList.SelectedItems)
            {

                String entityTypeName = (String)(item as ListBoxItem).Content;
                ctx.Load<EntityMetaData>(ctx.GetMetaDataUpdateQueryQuery(entityTypeName), UpdateResult, null);

            }
        }
        private void UpdateResult(LoadOperation op) {
            Result++;
       
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Result+"");
        }

    }
}
