using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
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

namespace DentalService.Employee;

public partial class EmployeeWindow : Window
{

    public EmployeeWindow(string connectionString, EmployeeM emp)
    {
        InitializeComponent();
        this.DataContext = new EmployeeViewModel(connectionString, emp);
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
        var screen = new MainWindow();
        this.Close();
        screen.Show();
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

    }
}
