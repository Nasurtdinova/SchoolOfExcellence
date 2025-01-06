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
    /// <summary>
    /// Логика взаимодействия для AttendancePage.xaml
    /// </summary>
    public partial class AttendancePage : Page
    {
        List<Schedule> schedules = new List<Schedule>();
        public AttendancePage()
        {
            InitializeComponent();
            var listTeacher = DataAccess.GetTeachers();
            listTeacher.Insert(0, new Teacher()
            {
                FullName = "Все"
            });
            comboTeacher.ItemsSource = listTeacher;
            comboTeacher.SelectedIndex = 0;

            var listActivity = DataAccess.GetActivities();
            listActivity.Insert(0, new Activity()
            {
                Name = "Все"
            });
            comboActivity.ItemsSource = listActivity;
            comboActivity.SelectedIndex = 0;

            if (CurrentUser.Teacher != null)
            {
                dgShedules.ItemsSource = DataAccess.GetSchedulesPast().Where(a => a.TeacherActivity.Teacher == CurrentUser.Teacher).OrderBy(b => b.Date);
                columnTeacher.Visibility = Visibility.Collapsed;
            }
            else
                dgShedules.ItemsSource = DataAccess.GetSchedulesPast().OrderBy(a => a.Date);

            dpDate.DisplayDateEnd = DateTime.Now;
        }

        public void UpdateList()
        {
            //if (CurrentUser.User.IdRole == 2)
            //    schedules = DataAccess.GetSchedulesPast().Where(a => a.TeacherActivity.Teacher == CurrentUser.Teacher).OrderBy(b => b.Date).ToList();
            //else
            //    schedules = DataAccess.GetSchedulesPast().OrderBy(a => a.Date).ToList();

            if (comboActivity.SelectedIndex > 0)
                schedules = schedules.Where(a => a.TeacherActivity.Activity == comboActivity.SelectedItem as Activity).OrderBy(a => a.Date).ToList();
            if (comboTeacher.SelectedIndex > 0)
                schedules = schedules.Where(a => a.TeacherActivity.Teacher == comboTeacher.SelectedItem as Teacher).OrderBy(a => a.Date).ToList();
            if (dpDate.SelectedDate != null)
                schedules = schedules.Where(a => a.Date == dpDate.SelectedDate).ToList();
            dgShedules.ItemsSource = schedules;
        }

        private void dgShedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as DataGrid).SelectedItem as Schedule;
            if (a!= null && a.IsConducted == true)
            {
                AttendanceWindow atten = new AttendanceWindow(a);
                atten.Show();
            }
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void comboActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void comboTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
