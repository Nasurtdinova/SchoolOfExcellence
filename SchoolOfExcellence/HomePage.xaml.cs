using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = CurrentUser.User;          

            if (CurrentUser.User.IdRole == 1)
            {
                btnMyActivities.Visibility = Visibility.Collapsed;
                btnMyStudents.Visibility = Visibility.Collapsed;
                btnMyActivitiesToday.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnReports.Visibility = Visibility.Collapsed;
                btnSchedule.Visibility = Visibility.Collapsed;
                btnActivities.Visibility = Visibility.Collapsed;
                btnStudentsTeachers.Visibility = Visibility.Collapsed;
                btnActivitiesToday.Visibility = Visibility.Collapsed;
            }
        }

        private void btnMyStudents_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyGroupsPage());
        }

        private void btnActivities_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActivitiesPage());
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SchedulePage());
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStudentsTeachers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsTeachersPage());
        }

        private void btnEditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(openFile.FileName));
                CurrentUser.User.Image = File.ReadAllBytes(openFile.FileName);
                Connection.BdConnection.SaveChanges();
            }
        }

        private void btnMyActivitiesToday_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TodayActivitiesPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.User = null;
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
