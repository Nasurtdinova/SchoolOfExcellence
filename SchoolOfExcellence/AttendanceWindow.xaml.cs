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
    public partial class AttendanceWindow : Window
    {
        public AttendanceWindow(Schedule selectedSchedule)
        {
            InitializeComponent();

            dgAttendance.ItemsSource = DataAccess.GetSkipVisits().Where(a => a.Schedule == selectedSchedule).ToList();
        }
    }
}
