using Microsoft.Win32;
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
    public partial class MyProfilePage : Page
    {
        public MyProfilePage()
        {
            InitializeComponent();
            DataContext = CurrentUser.User;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Connection.BdConnection.SaveChanges();
            MessageBox.Show("Информация сохранена!");
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(file.FileName));
                CurrentUser.User.Image = File.ReadAllBytes(file.FileName);
            }
        }
    }
}
