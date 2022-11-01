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
    public partial class SchedulePage : Page
    {
        List<Schedule> schedules = new List<Schedule>();
        public SchedulePage()
        {
            InitializeComponent();
            dgShedules.ItemsSource = DataAccess.GetSchedules().OrderBy(a=>a.Date);
            var listTeacher = DataAccess.GetTeachers();
            listTeacher.Insert(0, new Teacher()
            {
                User = new User() { FullName="Все"}
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
        }

        private void addSchedule_Click(object sender, RoutedEventArgs e)
        {
            AddScheduleWindow add = new AddScheduleWindow();
            add.Show();
            add.Closed += (s, eventarg) =>
            {
                UpdateList();
            };
        }

        public void UpdateList()
        {
            schedules = DataAccess.GetSchedules().OrderBy(a => a.Date).ToList();
            if (comboActivity.SelectedIndex > 0)
                schedules = schedules.Where(a => a.TeacherActivity.Activity == comboActivity.SelectedItem as Activity).OrderBy(a => a.Date).ToList();
            if (comboTeacher.SelectedIndex > 0)
                schedules = schedules.Where(a => a.TeacherActivity.Teacher == comboTeacher.SelectedItem as Teacher).OrderBy(a => a.Date).ToList();
            dgShedules.ItemsSource = schedules;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void comboActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void comboTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
