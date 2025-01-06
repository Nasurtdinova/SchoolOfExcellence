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
    public partial class CreateTeacherWindow : Window
    {
        public Teacher CurrentTeacher = new Teacher();

        public CreateTeacherWindow(Teacher selectedTeacher)
        {
            InitializeComponent();
            if (selectedTeacher != null)
            {
                CurrentTeacher = selectedTeacher;
                dpDate.SelectedDate = CurrentTeacher.DateOfBirth;
            }
            Title = CurrentTeacher.PersonnelNumber == 0 ? "Добавление преподавателя" : "Редактирование преподавателя";
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
                DataAccess.SaveTeacher(CurrentTeacher);
                MaterialMessageBox.Show("Информация сохранена!");
                Close();

            }
            else
            {
                DataAccess.SaveTeacher(CurrentTeacher);
                MaterialMessageBox.Show("Информация сохранена!");
                Close();
            }

        }
    }
}
