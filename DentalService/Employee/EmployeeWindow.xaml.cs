using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace DentalService.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow(SqlConnection cn, EmployeeM emp)
        {
            InitializeComponent();
        }



        private void CreateAppointment_Click(object sender, RoutedEventArgs e) {
            var screen = new CreateAppointment();
            screen.ShowDialog();
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e) {
            var screen = new EditAppointment();
            screen.ShowDialog();
        }

        private void InvoiceButton_Click(object sender, RoutedEventArgs e) {
            var screen = new Invoice();
            screen.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
