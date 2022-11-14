using BespokeFusion;
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
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Password))
            {
                MaterialMessageBox.ShowError("Заполните данные!", "Предупреждение!");
            }
            else
            {
                if (DataAccess.IsCorrectUser(tbLogin.Text, tbPassword.Password))
                    NavigationService.Navigate(new HomeWindow());
                else
                    MaterialMessageBox.ShowError("Incorrect login or password");
            }
        }
    }
}
