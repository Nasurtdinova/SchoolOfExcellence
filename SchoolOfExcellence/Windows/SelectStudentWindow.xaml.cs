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
            StudentActivity studentActivity = new StudentActivity()
            {
                TeacherActivity = SelectedActivity,
                Student = comboStudent.SelectedItem as Student,
                IsActive = true
            };
            if (DataAccess.GetStudentsActivities().Where(a => a.TeacherActivity == studentActivity.TeacherActivity && a.Student == studentActivity.Student).Count() != 0)
            {
                MessageBox.Show("Этот ученик уже состоит в этом кружке!");
            }
            else
            {
                Connection.BdConnection.StudentActivity.Add(studentActivity);
                Connection.BdConnection.SaveChanges();
                Close();
            }
        }
    }
}
