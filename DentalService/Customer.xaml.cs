using DentalService.Employee;
using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        public BindingList<MedicalRecord> medicalRecords;
        public Customer(SqlConnection cn, CustomerM cus)
        {
            InitializeComponent();
            _customer =cus;
            connection = cn;
            this.DataContext = _customer;
            connection.Close();
            string connectionString = @"Server=.\SQLEXPRESS;
                                       Database = DentalClinicManagement;
                                       Trusted_Connection = yes";
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "select * from MedicalRecord join Dentist on MedicalRecord.dentistid = dentist.dentistid";
            var command = new SqlCommand(sql, connection);

            int count = -1;
            medicalRecords = new BindingList<MedicalRecord>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["mrecordid"];
                    string fullName = (string)reader["fullname"];
                    DateTime date = (DateTime)reader["MedicalRecordDate"];
                    string description = (string)reader["Description"];
                    var record = new MedicalRecord()
                    {
                        MRecordId = id,
                        DentistName = fullName,
                        Description = description,
                        MedicalRecordDate = date,
                    };

                    medicalRecords.Add(record);
                }
                reader.Close();
            }

            recordsTable.ItemsSource = medicalRecords;
        }

        private void CreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            var screen = new CreateAppointment();
            screen.ShowDialog();
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            var screen = new EditAppointment();
            screen.ShowDialog();
        }

        private void InvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new Invoice();
            screen.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
