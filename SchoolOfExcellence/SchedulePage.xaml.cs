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
            dgMonday.ItemsSource = DataAccess.GetSchedule("Понедельник");
            dgTuesday.ItemsSource = DataAccess.GetSchedule("Вторник");
            dgWednesday.ItemsSource = DataAccess.GetSchedule("Среда");
            dgThursday.ItemsSource = DataAccess.GetSchedule("Четверг");          
            dgFriday.ItemsSource = DataAccess.GetSchedule("Пятница");
            dgSaturday.ItemsSource = DataAccess.GetSchedule("Суббота");
            dgSunday.ItemsSource = DataAccess.GetSchedule("Воскресенье");
        }

        private void addSchedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSchedulePage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
