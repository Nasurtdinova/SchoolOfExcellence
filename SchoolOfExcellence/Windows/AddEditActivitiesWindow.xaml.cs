using BespokeFusion;
using SchoolOfExcellence.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(act.Code);
            }
            Title = CurrentActivity.Code == 0 ? "Добавление дисциплины" : "Редактирование дисциплины";
            DataContext = CurrentActivity;           
        }

        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            SelectTeacherPage select = new SelectTeacherPage(CurrentActivity);
            select.Show();
            select.Closed += (s, eventarg) =>
            {
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(CurrentActivity.Code);
            };
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(CurrentActivity);

            if (!Validator.TryValidateObject(CurrentActivity, context, results, true))
            {
                foreach (var error in results)
                    MaterialMessageBox.ShowError(error.ErrorMessage);
            }
            else
            {
                DataAccess.SaveActivity(CurrentActivity);
                MaterialMessageBox.Show("Информация сохранена!");
                Close();
            }
        }

        private void btnRemoveTeacher_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as TeacherActivity;
            if (MessageBox.Show($"Вы точно хотите чтобы {a.Teacher.FullName} не вел(-а) {a.Activity.Name}?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {                
                a.IsDeleted = true;
                Connection.BdConnection.SaveChanges();
                MaterialMessageBox.Show($"{a.Teacher.FullName} больше не ведет {a.Activity.Name}!");
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(CurrentActivity.Code);
            }
        }
    }
}
