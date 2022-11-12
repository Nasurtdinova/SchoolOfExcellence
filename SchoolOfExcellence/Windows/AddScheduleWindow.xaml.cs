using BespokeFusion;
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
            comboTeachers.ItemsSource = DataAccess.GetTeachers();
            dpDate.DisplayDateStart = DateTime.Now;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.GetSchedules().Where(a => a.Date.Value.Date == DateTime.Now.Date && a.Cabinet == comboCabinet.SelectedItem as Cabinet && a.LessonStartTime.Value.Ticks == tbLessonStart.SelectedTime.Value.Ticks || a.LessonEndTime.Value.Ticks >= tbLessonEnd.SelectedTime.Value.Ticks).Count() != 0)
            {
                MaterialMessageBox.ShowError("В этом кабинете в это время проводится другой кружок!");
            }
            else if (DataAccess.GetSchedules().Where(a => a.LessonStartTime == tbLessonStart.SelectedTime.Value.TimeOfDay && a.TeacherActivity == DataAccess.GetTeachersActivities().Where(b => b.Activity == comboActivity.SelectedItem as Activity && b.Teacher == comboTeachers.SelectedItem as Teacher).FirstOrDefault()).Count() != 0)
                MaterialMessageBox.ShowError("У этого учителя в это время уже есть кружок!");
            else
            {               
                Schedule sch = new Schedule()
                {
                    TeacherActivity = DataAccess.GetTeachersActivities().Where(a => a.Activity == comboActivity.SelectedItem as Activity && a.Teacher == comboTeachers.SelectedItem as Teacher).FirstOrDefault(),
                    Cabinet = comboCabinet.SelectedItem as Cabinet,
                    Date = dpDate.SelectedDate,
                    IsSkipped = false,
                    LessonEndTime = tbLessonEnd.SelectedTime.Value.TimeOfDay,
                    LessonStartTime = tbLessonStart.SelectedTime.Value.TimeOfDay
                };
                DataAccess.AddSchedule(sch);
                MaterialMessageBox.Show("Информация сохранена!");
                Close();
            }
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

            tbLessonEnd.SelectedTime = tbLessonStart.SelectedTime + a.Duration;
        }

        private void tbLessonStart_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (comboActivity.SelectedItem != null)
                tbLessonEnd.SelectedTime = tbLessonStart.SelectedTime + (comboActivity.SelectedItem as Activity).Duration;
        }
    }
}
