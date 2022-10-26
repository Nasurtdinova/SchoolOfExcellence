using SchoolOfExcellence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolOfExcellence
{
    public partial class ActivitiesPage : Page
    {
        public ActivitiesPage()
        {
            InitializeComponent();
            dgActivities.ItemsSource = DataAccess.GetActivities();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditActivitiesPage add = new AddEditActivitiesPage(null);
            add.Show();
            add.Closed += (s, eventarg) =>
            {
                dgActivities.ItemsSource = DataAccess.GetActivities();
            };
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var i = (sender as Button).DataContext as Activity;
            AddEditActivitiesPage edit = new AddEditActivitiesPage(i);
            edit.Show();
            edit.Closed += (s, eventarg) =>
            {
                dgActivities.ItemsSource = DataAccess.GetActivities();
            };
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
