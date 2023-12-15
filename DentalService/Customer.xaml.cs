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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        SqlConnection connection;
        int Id;
        CustomerM _customer;
        public Customer(SqlConnection cn, CustomerM cus)
        {
            InitializeComponent();
            _customer =cus;
            connection = cn;
            this.DataContext = _customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }
    }
}
