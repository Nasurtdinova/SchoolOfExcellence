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
    public partial class AddScheduleWindow : Window
    {
        public AddScheduleWindow()
        {
            InitializeComponent();
            comboActivity.ItemsSource = DataAccess.GetActivities();
            comboCabinet.ItemsSource = DataAccess.GetCabinets();
            comboDayOfWeek.ItemsSource = DataAccess.GetDaysOfWeek();
            comboTeachers.ItemsSource = DataAccess.GetTeachers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedule = new Schedule()
            {
                TeacherActivity = DataAccess.GetTeachersActivities().Where(a => a.Activity == comboActivity.SelectedItem as Activity && a.Teacher == comboTeachers.SelectedItem as Teacher).FirstOrDefault(),
                Cabinet = comboCabinet.SelectedItem as Cabinet,
                DayOfWeek = comboDayOfWeek.SelectedItem as Database.DayOfWeek
            };
            DataAccess.AddSchedule(schedule);
        }

        private void comboTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Teacher;
            comboActivity.ItemsSource = DataAccess.GetActivitiesInTeacher(a.Id).Select(b=>b.Activity);
        }

        private void comboActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Activity;
            comboTeachers.ItemsSource = DataAccess.GetTeachersInActivities(a.Id).Select(b=>b.Teacher);
        }
    }
}
