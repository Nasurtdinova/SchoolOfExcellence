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
using System.Windows.Shapes;

namespace SchoolOfExcellence
{
    public partial class MarkPresentWindow : Window
    {
        public Schedule CurrentSchedule = new Schedule();
        public MarkPresentWindow(Schedule schedule)
        {
            InitializeComponent();
            if (schedule != null)
                CurrentSchedule = schedule;
            if (DataAccess.GetSkipVisits().Where(a => a.Schedule == CurrentSchedule).Count() != 0)
            {
                dgEditStudents.Visibility = Visibility.Visible;
                dgAddStudents.Visibility = Visibility.Collapsed;
                dgEditStudents.ItemsSource = DataAccess.GetSkipVisits().Where(a => a.Schedule == CurrentSchedule).ToList();
            }
            else
            {
                dgAddStudents.Visibility = Visibility.Visible;
                dgEditStudents.Visibility = Visibility.Collapsed;
                dgAddStudents.ItemsSource = CurrentSchedule.TeacherActivity.StudentActivity.Select(a => a.Student).ToList();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.GetSkipVisits().Where(a => a.Schedule == CurrentSchedule).Count() == 0)
            {
                var list = dgAddStudents.ItemsSource as List<Student>;
                foreach (var i in list)
                {
                    SkipVisit skipVisit = new SkipVisit()
                    {
                        Schedule = CurrentSchedule,
                        Student = i,
                        IsVisited = i.IsVisited,
                        Reason = i.Reason
                    };
                    Connection.BdConnection.SkipVisit.Add(skipVisit);
                    Connection.BdConnection.SaveChanges();
                }
            }
            else
            {
                foreach (var i in dgEditStudents.ItemsSource)
                    Connection.BdConnection.SaveChanges();
            }
            MaterialMessageBox.Show("Информация сохранена!");
        }

        private void checkMark_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as CheckBox).DataContext as Student;
            if ((sender as CheckBox).IsChecked == true)
                a.IsVisited = true;
            else
                a.IsVisited = false;
            dgAddStudents.ItemsSource = CurrentSchedule.TeacherActivity.StudentActivity.Select(b => b.Student).ToList();
        }

        private void checkMark_Click_1(object sender, RoutedEventArgs e)
        {
            var a = (sender as CheckBox).DataContext as SkipVisit;
            if ((sender as CheckBox).IsChecked == true)
                a.IsVisited = true;
            else
                a.IsVisited = false;
            dgEditStudents.ItemsSource = DataAccess.GetSkipVisits().Where(b => b.Schedule == CurrentSchedule).ToList();
        }
    }
}
