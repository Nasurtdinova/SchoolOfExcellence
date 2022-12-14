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
    public partial class SelectStudentPage : Window
    {
        public TeacherActivity SelectedActivity { get; set; }
        public SelectStudentPage(TeacherActivity act)
        {
            InitializeComponent();
            SelectedActivity = act;
            comboStudent.ItemsSource = DataAccess.GetStudents();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (comboStudent.SelectedItem != null)
            {
                StudentActivity studentActivity = new StudentActivity()
                {
                    TeacherActivity = SelectedActivity,
                    Student = comboStudent.SelectedItem as Student,
                    IsActive = true
                };
                var stud = DataAccess.GetStudentsActivitiesTotal().Where(a => a.TeacherActivity == studentActivity.TeacherActivity && a.Student == studentActivity.Student && a.IsActive == false).FirstOrDefault();
                if (DataAccess.GetStudentsActivities().Where(a => a.TeacherActivity == studentActivity.TeacherActivity && a.Student == studentActivity.Student).Count() != 0)
                    MaterialMessageBox.ShowError("Этот ученик уже состоит в этом кружке!");
                else if (stud != null)
                {
                    stud.IsActive = true;
                    Connection.BdConnection.SaveChanges();
                    Close();
                }
                else
                {
                    Connection.BdConnection.StudentActivity.Add(studentActivity);
                    Connection.BdConnection.SaveChanges();
                    Close();
                }
            }
            else
                MaterialMessageBox.ShowError("Выберите студента!", "Предупреждение!");
        }

        public void OnComboboxTextChanged(object sender, RoutedEventArgs e)
        {
            comboStudent.ItemsSource = DataAccess.GetStudents().Where(a => a.FullName.ToLower().Contains(comboStudent.Text.ToLower()));
        }
    }
}
