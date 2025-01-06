using BespokeFusion;
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
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeWindow());
        }

        private void btnPrepod_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Teacher = DataAccess.GetTeachers().FirstOrDefault();
            NavigationService.Navigate(new HomeWindow());
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Student = DataAccess.GetStudents().FirstOrDefault();
            NavigationService.Navigate(new HomeWindow());
        }
    }
}
