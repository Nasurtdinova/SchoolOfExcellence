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
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
            dgPopularDestinations.ItemsSource = DataAccess.GetActivities().OrderByDescending(a=>a.Count);
        }

        private void comboTypeReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboTypeReport.SelectedIndex == 0)
            {
                dgPopularDestinations.ItemsSource = DataAccess.GetActivities().OrderByDescending(a => a.Count);
                dgActiveStudents.Visibility = Visibility.Collapsed;
                dgPopularDestinations.Visibility = Visibility.Visible;
            }
            else if (comboTypeReport.SelectedIndex == 1)
            {
                dgActiveStudents.ItemsSource = DataAccess.GetStudents().OrderByDescending(a=>a.CountActivity);
                dgActiveStudents.Visibility = Visibility.Visible;
                dgPopularDestinations.Visibility = Visibility.Collapsed;
            }
        }
    }
}
