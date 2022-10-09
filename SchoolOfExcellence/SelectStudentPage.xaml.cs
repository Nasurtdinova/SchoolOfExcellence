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
    public partial class SelectStudentPage : Page
    {
        public Activity SelectedActivity { get; set; }
        public SelectStudentPage(Activity act)
        {
            InitializeComponent();
            SelectedActivity = act;
            comboStudent.ItemsSource = DataAccess.GetStudents();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            StudentActivity studentActivity = new StudentActivity()
            {
                Activity = SelectedActivity,
                Student = comboStudent.SelectedItem as Student,
                IsActive = true
            };
            Connection.BdConnection.StudentActivity.Add(studentActivity);
            Connection.BdConnection.SaveChanges();
            NavigationService.Navigate(new MyStudentsPage());
        }
    }
}
