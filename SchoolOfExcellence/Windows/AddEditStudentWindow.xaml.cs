using BespokeFusion;
using Microsoft.Win32;
using SchoolOfExcellence.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public partial class AddEditStudentWindow : Window
    {
        public Student CurrentTeacher = new Student();

        public AddEditStudentWindow(Student selectedTeacher)
        {
            InitializeComponent();
            if (selectedTeacher != null)
            {
                CurrentTeacher = selectedTeacher;
                dpDate.SelectedDate = CurrentTeacher.DateOfBirth;
                dpDateStudy.SelectedDate = CurrentTeacher.DateStudy;
            }
            Title = CurrentTeacher.PersonnelNumber == 0 ? "Добавление студента" : "Редактирование студента";
            comboGrade.ItemsSource = DataAccess.GetGrades();
            DataContext = CurrentTeacher;
        }

        private void btnEditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                imageTeacher.Source = new BitmapImage(new Uri(file.FileName));
                CurrentTeacher.Image = File.ReadAllBytes(file.FileName);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTeacher.PersonnelNumber == 0)
            {
                DataAccess.SaveStudent(CurrentTeacher);
                MaterialMessageBox.Show("Информация сохранена!");
                Close();

            }
            else
            {
                DataAccess.SaveStudent(CurrentTeacher);
                MaterialMessageBox.Show("Информация сохранена!");
                Close();
            }

        }
    }
}
