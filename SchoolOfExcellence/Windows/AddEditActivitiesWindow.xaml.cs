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
    public partial class AddEditActivitiesWindow : Window
    {
        public Activity CurrentActivity = new Activity();
        public AddEditActivitiesWindow(Activity act)
        {
            InitializeComponent();
            if (act != null)
            {
                CurrentActivity = act;
                var date= new DateTime(act.Duration.Value.Ticks);
                tpDuration.SelectedTime = date;
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(act.Id);
                lvStudents.ItemsSource = DataAccess.GetStudentsInActivities(act.Id);
            }
            Title = CurrentActivity.Id == 0 ? "Добавление кружка" : "Редактирование кружка";
            DataContext = CurrentActivity;           
        }

        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            SelectTeacherPage select = new SelectTeacherPage(CurrentActivity);
            select.Show();
            select.Closed += (s, eventarg) =>
            {
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(CurrentActivity.Id);
            };
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CurrentActivity.Duration = tpDuration.SelectedTime.Value.TimeOfDay;
            DataAccess.SaveActivity(CurrentActivity);
            MaterialMessageBox.Show("Информация сохранена!");
            Close();
        }

        private void btnRemoveTeacher_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as TeacherActivity;
            if (MessageBox.Show($"Вы точно хотите чтобы {a.Teacher.User.FullName} не проводил(-а) {a.Activity.Name}?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {                
                a.IsDeleted = true;
                Connection.BdConnection.SaveChanges();
                MaterialMessageBox.Show($"{a.Teacher.User.FullName} больше не проводит {a.Activity.Name}!");
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(CurrentActivity.Id);
            }
        }
    }
}
