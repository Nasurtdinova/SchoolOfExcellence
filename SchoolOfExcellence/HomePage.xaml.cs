using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            if (CurrentUser.Teacher != null)
            {
                if (CurrentUser.Teacher.Image == null)
                    imgUser.Source = new BitmapImage(new Uri("C:\\Users\\201914\\source\\repos\\SchoolOfExcellence\\SchoolOfExcellence\\ProfileIcon.png"));
                else
                {
                    var stream = new MemoryStream(CurrentUser.Teacher.Image);
                    stream.Seek(0, SeekOrigin.Begin);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.EndInit();
                    imgUser.Source = image;
                }
                DataContext = CurrentUser.Teacher;
            }
            else
            {
                if (CurrentUser.Headmaster.Image == null)
                    imgUser.Source = new BitmapImage(new Uri("C:\\Users\\201914\\source\\repos\\SchoolOfExcellence\\SchoolOfExcellence\\ProfileIcon.png"));
                else
                {
                    var stream = new MemoryStream(CurrentUser.Headmaster.Image);
                    stream.Seek(0, SeekOrigin.Begin);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.EndInit();
                    imgUser.Source = image;
                }
                DataContext = CurrentUser.Headmaster;
            }
        }

        private void btnMyStudents_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
