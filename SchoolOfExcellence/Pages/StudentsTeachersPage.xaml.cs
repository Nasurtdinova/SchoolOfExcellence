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
    public partial class StudentsTeachersPage : Page
    {
        public StudentsTeachersPage()
        {
            InitializeComponent();
            radioTeachers.IsChecked = true;
            dgTeachers.ItemsSource = DataAccess.GetTeachers();
            if (CurrentUser.Teacher != null)
                btnAddTeachers.Visibility = Visibility.Collapsed;
        }

        private void radioStudents_Click(object sender, RoutedEventArgs e)
        {
            teachers.Visibility = Visibility.Collapsed;
            dgStudents.Visibility = Visibility.Visible;
            dgStudents.ItemsSource = DataAccess.GetStudents();
        }

        private void radioTeachers_Click(object sender, RoutedEventArgs e)
        {
            dgStudents.Visibility = Visibility.Collapsed;
            teachers.Visibility = Visibility.Visible;
            dgTeachers.ItemsSource = DataAccess.GetTeachers();
        }

        private void btnAddTeachers_Click(object sender, RoutedEventArgs e)
        {
            CreateTeacherWindow create = new CreateTeacherWindow(null);
            create.Show();
            create.Closed += (s, eventarg) =>
            {
                dgTeachers.ItemsSource = DataAccess.GetTeachers();
            };
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void dgTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateTeacherWindow edit = new CreateTeacherWindow((sender as DataGrid).SelectedItem as Teacher);
            edit.Show();
            edit.Closed += (s, eventarg) =>
            {
                dgTeachers.ItemsSource = DataAccess.GetTeachers();
            };
        }
    }
}
