using BespokeFusion;
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
            AddEditActivitiesWindow add = new AddEditActivitiesWindow(null);
            add.Show();
            add.Closed += (s, eventarg) =>
            {
                dgActivities.ItemsSource = DataAccess.GetActivities();
            };
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var i = (sender as Button).DataContext as Activity;
            AddEditActivitiesWindow edit = new AddEditActivitiesWindow(i);
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
            if (MessageBox.Show("Вы точно хотите удалить кружок?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var i = (sender as Button).DataContext as Activity;
                i.IsActive = false;
                foreach (var j in i.TeacherActivity)
                {
                    j.IsDeleted = true;
                    foreach (var k in j.StudentActivity)
                    {
                        k.IsActive = false;
                        Connection.BdConnection.SaveChanges();
                    }
                }
                Connection.BdConnection.SaveChanges();
                MaterialMessageBox.Show("Кружок успешно удален!");
                dgActivities.ItemsSource = DataAccess.GetActivities();
            }
        }
    }
}
