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
    public partial class TodayActivitiesPage : Page
    {
        public TodayActivitiesPage()
        {
            InitializeComponent();
            dgTodayActivities.ItemsSource = DataAccess.GetSchedules().Where(a => a.Date.Value.Date == DateTime.Now.Date && a.TeacherActivity.Teacher == CurrentUser.Teacher);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnMarkPresent_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as Schedule;
            MarkPresentWindow mark = new MarkPresentWindow(a);
            mark.Show();
            mark.Closed += (s, eventarg) =>
            {
                dgTodayActivities.ItemsSource = DataAccess.GetSchedules().Where(b => a.Date.Value.Date == DateTime.Now.Date && b.TeacherActivity.Teacher == CurrentUser.Teacher);
            };
        }

        private void checkSkip_Checked(object sender, RoutedEventArgs e)
        {
            var a = (sender as CheckBox).DataContext as Schedule;
            if ((sender as CheckBox).IsChecked == true)
                a.IsConducted = true;
            else
                a.IsConducted = false;
            Connection.BdConnection.SaveChanges();
            dgTodayActivities.ItemsSource = DataAccess.GetSchedules().Where(b => b.Date.Value.Date == DateTime.Now.Date && b.TeacherActivity.Teacher == CurrentUser.Teacher);
        }

        private void tbReason_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = (sender as TextBox).DataContext as Schedule;
            a.Reason = (sender as TextBox).Text;
            Connection.BdConnection.SaveChanges();
        }
    }
}
