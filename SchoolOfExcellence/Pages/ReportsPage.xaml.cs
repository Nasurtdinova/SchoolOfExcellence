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
using Excel = Microsoft.Office.Interop.Excel;

namespace SchoolOfExcellence
{
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();           
        }

        private void comboTypeReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboTypeReport.SelectedIndex == 0)
            {
                dgPopularDestinations.ItemsSource = DataAccess.GetGrades().OrderByDescending(a => a.Attendance);
                dgActiveStudents.Visibility = Visibility.Collapsed;
                dgPopularDestinations.Visibility = Visibility.Visible;
                dgCountSubject.Visibility = Visibility.Collapsed;
            }
            else if (comboTypeReport.SelectedIndex == 1)
            {
                dgActiveStudents.ItemsSource = DataAccess.GetStudents().OrderByDescending(a => a.Attendance);
                dgActiveStudents.Visibility = Visibility.Visible;
                dgPopularDestinations.Visibility = Visibility.Collapsed;
                dgCountSubject.Visibility = Visibility.Collapsed;
            }
            else if (comboTypeReport.SelectedIndex == 2)
            {
                dgCountSubject.ItemsSource = DataAccess.GetTeachers().OrderByDescending(a => a.CountSubject);
                dgActiveStudents.Visibility = Visibility.Collapsed;
                dgPopularDestinations.Visibility = Visibility.Collapsed;
                dgCountSubject.Visibility = Visibility.Visible;
            }
            tbNull.Visibility = Visibility.Collapsed;
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            if (comboTypeReport.SelectedItem != null && comboTypeReport.SelectedIndex == 0)
            {             
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                int startRowIndex = 1;

                worksheet.Cells[1][startRowIndex] = "Название";
                worksheet.Cells[2][startRowIndex] = "Количество человек";
                startRowIndex++;

                //var results = DataAccess.GetActivities().OrderByDescending(a => a.Count);
                //foreach (var result in results)
                //{
                //    worksheet.Cells[1][startRowIndex] = result.Name;
                //    worksheet.Cells[2][startRowIndex] = result.Count;
                //    startRowIndex++;
                //}
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
                application.Visible = true;
            }
            else if (comboTypeReport.SelectedItem != null && comboTypeReport.SelectedIndex == 1)
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                int startRowIndex = 1;
                worksheet.Rows.HorizontalAlignment = HorizontalAlignment.Center;
                worksheet.Rows.VerticalAlignment = HorizontalAlignment.Center;
                worksheet.Cells[1][startRowIndex] = "ФИО";
                worksheet.Cells[2][startRowIndex] = "Класс";
                worksheet.Cells[3][startRowIndex] = "Количество кружков";
                worksheet.Cells[4][startRowIndex] = "Посещаемость кружков";
                startRowIndex++;

                //var results = DataAccess.GetStudents().OrderByDescending(a => a.CountActivity);
                //foreach (var result in results)
                //{
                //    worksheet.Cells[1][startRowIndex] = result.FullName;
                //    worksheet.Cells[2][startRowIndex] = result.Grade.Name;
                //    worksheet.Cells[3][startRowIndex] = result.CountActivity;
                //    string attendance = string.Empty;
                //    foreach(var i in result.StudentActivityTrue)
                //    {
                //        attendance = attendance + $"{i.TeacherActivity.Activity.Name} {i.Attendance}" + Environment.NewLine;
                //    }
                //    worksheet.Cells[4][startRowIndex] = attendance;
                //    startRowIndex++;
                //}
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
                application.Visible = true;
            }
            else if (comboTypeReport.SelectedItem != null && comboTypeReport.SelectedIndex == 2)
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                int startRowIndex = 1;

                worksheet.Cells[1][startRowIndex] = "ФИО";
                worksheet.Cells[2][startRowIndex] = "Количество проведенных кружков";
                worksheet.Cells[3][startRowIndex] = "Количество не проведенных кружков";
                startRowIndex++;

                //var results = DataAccess.GetTeachers().OrderByDescending(a => a.CountSubject);
                //foreach (var result in results)
                //{
                //    worksheet.Cells[1][startRowIndex] = result.User.FullName;
                //    worksheet.Cells[2][startRowIndex] = result.CountSubject;
                //    worksheet.Cells[3][startRowIndex] = result.CountNoSubject;
                //    startRowIndex++;
                //}
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
                application.Visible = true;
            }
            else
                MaterialMessageBox.ShowError("Выберите тип!", "Предупреждение");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
