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
    /// <summary>
    /// Логика взаимодействия для AttendancePage.xaml
    /// </summary>
    public partial class AttendancePage : Page
    {
        public AttendancePage()
        {
            InitializeComponent();
            if (CurrentUser.User.IdRole == 2)
                dgShedules.ItemsSource = DataAccess.GetSchedulesPast().Where(a=> a.TeacherActivity.Teacher == CurrentUser.Teacher).OrderBy(b => b.Date);
            else
                dgShedules.ItemsSource = DataAccess.GetSchedulesPast().OrderBy(a => a.Date);
        }

        private void dgShedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as DataGrid).SelectedItem as Schedule;
            if (a.IsConducted == true)
            {
                AttendanceWindow atten = new AttendanceWindow(a);
                atten.Show();
            }
        }

    }
}
