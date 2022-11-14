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
        public User CurrentUser = new User();

        public CreateTeacherWindow(Teacher selectedTeacher)
        {
            InitializeComponent();
            if (selectedTeacher != null)
            {
                CurrentTeacher = selectedTeacher;
                CurrentUser = selectedTeacher.User;
                password.Password = CurrentUser.Password;
            }
            Title = CurrentTeacher.Id == 0 ? "Создание учителя" : "Редактирование учителя";
            DataContext = CurrentUser;
        }

        private void btnEditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                imageTeacher.Source = new BitmapImage(new Uri(file.FileName));
                CurrentUser.Image = File.ReadAllBytes(file.FileName);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Password = password.Password;
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(CurrentUser);

            if (!Validator.TryValidateObject(CurrentUser, context, results, true))
            {
                foreach (var error in results)
                    MaterialMessageBox.ShowError(error.ErrorMessage);
            }
            else
            {
                if (CurrentTeacher.Id == 0)
                {
                    CurrentTeacher.User = CurrentUser;
                    CurrentTeacher.User.IdRole = 2;
                    if (DataAccess.IsTrueLogin(tbLogin.Text))
                    {
                        DataAccess.SaveTeacher(CurrentTeacher);
                        MaterialMessageBox.Show("Информация сохранена!");
                        Close();
                    }
                    else
                        MaterialMessageBox.Show("Такой логин уже существует!");
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
}
