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
            if (CurrentUser.Teacher != null)
            {
                tbPersonnelNumber.Text = CurrentUser.Teacher.PersonnelNumber.ToString();
                tbFullName.Text = CurrentUser.Teacher.FullName;
                tbDateOfBirth.Text = CurrentUser.Teacher.DateOfBirth.Value.ToShortDateString();
                tbPhoneNumber.Text = CurrentUser.Teacher.PhoneNumber;
                tbSeniority.Text = CurrentUser.Teacher.Seniority.ToString();
                tbGrade.Visibility = Visibility.Collapsed;
                textGrade.Visibility = Visibility.Collapsed;
                tbDateStudy.Visibility = Visibility.Collapsed;
                textDateStudy.Visibility = Visibility.Collapsed;
                DataContext = CurrentUser.Teacher;
            }
            if (CurrentUser.Student != null)
            {
                tbPersonnelNumber.Text = CurrentUser.Student.PersonnelNumber.ToString();
                tbFullName.Text = CurrentUser.Student.FullName;
                tbDateOfBirth.Text = CurrentUser.Student.DateOfBirth.Value.ToShortDateString();
                tbPhoneNumber.Text = CurrentUser.Student.PhoneNumber;
                tbGrade.Text = CurrentUser.Student.Grade.Name.ToString();
                tbDateStudy.Text = CurrentUser.Student.DateStudy.Value.ToShortDateString();
                tbSeniority.Visibility = Visibility.Collapsed;
                textSeniority.Visibility = Visibility.Collapsed;
                DataContext = CurrentUser.Student;
            }
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
                if (CurrentUser.Teacher != null)
                {
                    CurrentUser.Teacher.Image = File.ReadAllBytes(file.FileName);
                    Connection.BdConnection.SaveChanges();
                }

                if (CurrentUser.Student != null)
                {
                    CurrentUser.Student.Image = File.ReadAllBytes(file.FileName);
                    Connection.BdConnection.SaveChanges();
                }
            }
        }
    }
}
