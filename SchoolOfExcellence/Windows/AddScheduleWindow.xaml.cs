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
            comboTeachers.ItemsSource = DataAccess.GetTeachers();
            comboGrades.ItemsSource = DataAccess.GetGrades();
            dpDate.DisplayDateStart = DateTime.Now;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (comboActivity.SelectedItem == null)
                MaterialMessageBox.Show("Заполните дисциплину!");
            else if (comboTeachers.SelectedItem == null)
                MaterialMessageBox.Show("Заполните преподавателя!");
            else if (string.IsNullOrEmpty(comboCabinet.Text))
                MaterialMessageBox.Show("Заполните кабинет!");
            else if (dpDate.SelectedDate == null)
                MaterialMessageBox.Show("Заполните дату!");
            else if (tbLessonStart.SelectedTime == null)
                MaterialMessageBox.Show("Заполните время начала!");
            else
            {
                if (DataAccess.GetSchedules().Where(a => a.Date.Value.Date == dpDate.SelectedDate.Value.Date && a.Cabinet == Convert.ToInt32(comboCabinet.Text) && a.LessonStartTime.Value.Ticks <= tbLessonStart.SelectedTime.Value.Ticks).Count() != 0)
                    MaterialMessageBox.ShowError("В этом кабинете в это время проводится другая дисциплина!");
                else if (DataAccess.GetSchedules().Where(a => a.LessonStartTime == tbLessonStart.SelectedTime.Value.TimeOfDay && a.TeacherActivity == DataAccess.GetTeachersActivities().Where(b => b.Activity == comboActivity.SelectedItem as Activity && b.Teacher == comboTeachers.SelectedItem as Teacher).FirstOrDefault()).Count() != 0)
                    MaterialMessageBox.ShowError("У этого преподавателя в это время уже есть пара!");
                else
                {
                    Schedule sch = new Schedule()
                    {
                        TeacherActivity = DataAccess.GetTeachersActivities().Where(a => a.Activity == comboActivity.SelectedItem as Activity && a.Teacher == comboTeachers.SelectedItem as Teacher).FirstOrDefault(),
                        Cabinet = Convert.ToInt32(comboCabinet.Text),
                        Grade = comboGrades.SelectedItem as Grade,
                        Date = dpDate.SelectedDate,
                        IsConducted = false,
                        //LessonEndTime = tbLessonEnd.SelectedTime.Value.TimeOfDay,
                        LessonStartTime = tbLessonStart.SelectedTime.Value.TimeOfDay
                    };
                    DataAccess.AddSchedule(sch);
                    MaterialMessageBox.Show("Информация сохранена!");
                    Close();
                }
            }
        }

        private void comboTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Teacher;
            comboActivity.ItemsSource = DataAccess.GetActivitiesInTeacher(a.PersonnelNumber).Select(b=>b.Activity);
        }

        private void comboActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Activity;
            comboTeachers.ItemsSource = DataAccess.GetTeachersInActivities(a.Code).Select(b=>b.Teacher);

            //tbLessonEnd.SelectedTime = tbLessonStart.SelectedTime + new TimeSpan(1,30,0);
        }

        private void tbLessonStart_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            //if (comboActivity.SelectedItem != null)
            //    tbLessonEnd.SelectedTime = tbLessonStart.SelectedTime + (comboActivity.SelectedItem as Activity).Duration;
        }
    }
}
