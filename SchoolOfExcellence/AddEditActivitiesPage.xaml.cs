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
    public partial class AddEditActivitiesPage : Page
    {
        public Activity CurrentActivity = new Activity();
        public AddEditActivitiesPage(Activity act)
        {
            InitializeComponent();
            if (act != null)
            {
                CurrentActivity = act;
                lvTeachers.ItemsSource = DataAccess.GetTeachersInActivities(act.Id);
                lvStudents.ItemsSource = DataAccess.GetStudentsInActivities(act.Id);
            }

            DataContext = CurrentActivity;
            
        }

        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectTeacherPage(CurrentActivity));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
