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
    public EmployeeViewModel ViewModel { get; set; }
    public EmployeeWindow(string connectionString, EmployeeM emp)
    {
        InitializeComponent();
        ViewModel = new EmployeeViewModel(connectionString, emp);
        this.DataContext = ViewModel;
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

    private void OnCustomerPhoneChanged(object sender, TextChangedEventArgs e) {
        ViewModel.SyncCustomer(CustomerPhoneTextBox.Text);
        if(ViewModel.Customer.CustomerID != 0) {
            CreateAppointmentButton.IsEnabled = true;
            EditAppointmentButton.IsEnabled = true;
        }
    }

    private void DirtyReadClick(object sender, RoutedEventArgs e) {
        ViewModel.SyncUncommmittedAppointmentList();
    }

    private void ReadCommittedClick(object sender, RoutedEventArgs e) {
        LoadingLabel.Visibility = Visibility.Visible;
        ViewModel.SyncCommittedAppointmentList();
        LoadingLabel.Visibility = Visibility.Hidden;
    }
}
