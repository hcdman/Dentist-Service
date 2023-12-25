using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for RegisterAccount.xaml
    /// </summary>
    public partial class RegisterAccount : Window
    {

        public RegisterAccount()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAccountType = ((ComboBoxItem)AccountTypeComboBox.SelectedItem)?.Content?.ToString();
            var name = NameTextBox.Text;
            var phoneNumber = PhoneNumberTextBox.Text;
            var password = PasswordBox.Password;
            var address = AddressTextBox.Text;
            var birthDate = BirthDatePicker.SelectedDate;

            // Validate Input
            if (!ValidateInput(name, phoneNumber, password, address, birthDate))
            {
                return;
            }

            var connectionString = ConfigurationManager.ConnectionStrings["DentalClinicManagementDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            var sql = "";

            switch (selectedAccountType)
            {
                case "Employee":
                    sql = "insert into Employee (FullName, EmployeeAddress, PhoneNumber, Birthday, EmployeePassword) " +
                        "values (@name, @address, @phoneNumber, @birthDate, @password)";
                    break;
                case "Dentist":
                    sql = "insert into Dentist (FullName, DentistAddress, PhoneNumber, Birthday, DentistPassword) " +
                        "values (@name, @address, @phoneNumber, @birthDate, @password)"; ;
                    break;
                case "Customer":
                    sql = "insert into Customer (FullName, CustomerAddress, PhoneNumber, Birthday, CustomerPassword) " +
                        "values (@name, @address, @phoneNumber, @birthDate, @password)";
                    break;
            }   

            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@birthDate", birthDate);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();

            MessageBox.Show("Account created successfully!");
        }

        private bool ValidateInput(string name, string phoneNumber, string password, string address, DateTime? birthDate)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(address) ||
                birthDate == null)
            {
                MessageBox.Show("All fields are required.");
                return false;
            }

            // số điện thoại phải là số và có 10 chữ số
            if (!long.TryParse(phoneNumber, out long phoneNumberLong) || phoneNumber.Length != 10)
            {
                MessageBox.Show("Phone number must be a number and have 10 digits.");
                return false;
            }

            // ngày sinh phải nhỏ hơn ngày hiện tại
            if (birthDate > DateTime.Now)
            {
                MessageBox.Show("Birth date must be less than current date.");
                return false;
            }

            // password phải có ít nhất 8 ký tự
            if (password.Length < 8)
            {
                MessageBox.Show("Password must have at least 8 characters.");
                return false;
            }

            return true;
        }
        private void AccountTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
