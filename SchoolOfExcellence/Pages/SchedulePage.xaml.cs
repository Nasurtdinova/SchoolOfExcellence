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
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
            dgShedules.ItemsSource = DataAccess.GetSchedules().OrderBy(a=>a.Date);
        }

        private void addSchedule_Click(object sender, RoutedEventArgs e)
        {
            AddScheduleWindow add = new AddScheduleWindow();
            add.Show();
            add.Closed += (s, eventarg) =>
            {
                dgShedules.ItemsSource = DataAccess.GetSchedules();
            };
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
