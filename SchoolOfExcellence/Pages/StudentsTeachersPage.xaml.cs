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
            
        }

        private void btnRemoveTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите уволить преподавателя?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var i = (sender as Button).DataContext as Teacher;
                i.IsActive = false;
                Connection.BdConnection.SaveChanges();
                MessageBox.Show("Преподаватель уволен!");
                dgTeachers.ItemsSource = DataAccess.GetTeachers();
            }
        }

        private void btnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            var i = (sender as Button).DataContext as Teacher;
            CreateTeacherWindow edit = new CreateTeacherWindow(i);
            edit.Show();
            edit.Closed += (s, eventarg) =>
            {
                dgTeachers.ItemsSource = DataAccess.GetTeachers();
            };
        }

        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите отчислить студента?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var i = (sender as Button).DataContext as Teacher;
                i.IsActive = false;
                Connection.BdConnection.SaveChanges();
                MessageBox.Show("Студент отчислен!");
                dgTeachers.ItemsSource = DataAccess.GetTeachers();
            }
        }

        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
