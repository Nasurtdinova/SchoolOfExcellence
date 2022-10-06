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
    public partial class AddSchedulePage : Page
    {
        public AddSchedulePage()
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
                Activity = comboActivity.SelectedItem as Activity,
                Teacher = comboTeachers.SelectedItem as Teacher,
                Cabinet = comboCabinet.SelectedItem as Cabinet,
                DayOfWeek = comboDayOfWeek.SelectedItem as DayOfWeek
            };
            DataAccess.AddSchedule(schedule);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void comboTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Teacher;
            List<Activity> act = new List<Activity>();
            foreach (var i in DataAccess.GetActivitiesInTeacher(a.Id))
                act.Add(i.Activity);
            comboActivity.ItemsSource = act;
        }

        private void comboActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Activity;
            List<Teacher> teac = new List<Teacher>();
            foreach (var i in DataAccess.GetTeachersInActivities(a.Id))
                teac.Add(i.Teacher);
            comboTeachers.ItemsSource = teac;
        }
    }
}
