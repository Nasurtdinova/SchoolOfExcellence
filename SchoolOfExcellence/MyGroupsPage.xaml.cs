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
    public partial class MyGroupsPage : Page
    {
        public MyGroupsPage()
        {
            InitializeComponent();
            dgActivities.ItemsSource = DataAccess.GetActivitiesInTeacher(CurrentUser.Teacher.Id);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void dgActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as DataGrid).SelectedItem as TeacherActivity;
            dgStudents.ItemsSource = DataAccess.GetStudentsInActivities(a.Id);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SelectStudentPage select = new SelectStudentPage(dgActivities.SelectedItem as TeacherActivity);
            select.Show();
            select.Closed += (s, eventarg) =>
            {
                dgStudents.ItemsSource = DataAccess.GetStudentsInActivities((dgActivities.SelectedItem as TeacherActivity).Id);
            };
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var student = (sender as Button).DataContext as StudentActivity;
            student.IsActive = false;
            Connection.BdConnection.SaveChanges();
        }
    }
}
