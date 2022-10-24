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
    public partial class SelectTeacherPage : Window
    {
        public Activity CurrentActivity = new Activity();
        public SelectTeacherPage(Activity act)
        {
            InitializeComponent();
            CurrentActivity = act;
            comboTeachers.ItemsSource = DataAccess.GetTeachers();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            TeacherActivity teacherActivity = new TeacherActivity()
            {
                Activity = CurrentActivity,
                Teacher = comboTeachers.SelectedItem as Teacher
            };
            Connection.BdConnection.TeacherActivity.Add(teacherActivity);
            Connection.BdConnection.SaveChanges();
            Close();
        }
    }
}
