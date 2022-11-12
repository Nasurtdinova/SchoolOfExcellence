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
using System.Windows.Shapes;

namespace SchoolOfExcellence
{
    public partial class HomeWindow : Page
    {
        public HomeWindow()
        {
            InitializeComponent();
            if (CurrentUser.User.IdRole == 1)
            {
                ItemTodayActivity.Visibility = Visibility.Collapsed;
                ItemMyGroups.Visibility = Visibility.Collapsed;
            }
            else
            {
                ItemReports.Visibility = Visibility.Collapsed;
                ItemSchedule.Visibility = Visibility.Collapsed;
                ItemActivities.Visibility = Visibility.Collapsed;
                ItemStudentsTeacher.Visibility = Visibility.Collapsed;
            }
            GridPrincipal.Navigate(new MainPage());
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    GridPrincipal.Navigate(new MainPage());
                    break;
                case "ItemReports":
                    GridPrincipal.Navigate(new ReportsPage());
                    break;
                case "ItemSchedule":
                    GridPrincipal.Navigate(new SchedulePage());
                    break;
                case "ItemActivities":
                    GridPrincipal.Navigate(new ActivitiesPage());
                    break;
                case "ItemAttendance":
                    GridPrincipal.Navigate(new AttendancePage());
                    break;
                case "ItemStudentsTeacher":
                    GridPrincipal.Navigate(new StudentsTeachersPage());
                    break;
                case "ItemTodayActivity":
                    GridPrincipal.Navigate(new TodayActivitiesPage());
                    break;
                case "ItemMyGroups":
                    GridPrincipal.Navigate(new MyGroupsPage());
                    break;
                default:
                    break;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Navigate(new MyProfilePage());
        }
    }
}
