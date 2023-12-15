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

namespace DentalService
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        SqlConnection connection;
        int Id;
        EmployeeM _employee;
        public Employee (SqlConnection cn, EmployeeM emp)
        {
            InitializeComponent();
            _employee = emp;
            connection = cn;
            this.DataContext = _employee;
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }
    }
}
