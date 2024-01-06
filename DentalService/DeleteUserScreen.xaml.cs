using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for DeleteUserScreen.xaml
    /// </summary>
    public partial class DeleteUserScreen : Window
    {
        private SqlConnection connection;
        private string selectedTab = "Dentist";
        private List<Model.CustomerM> customers = new List<Model.CustomerM>();
        private List<Model.DentistM> dentists = new List<Model.DentistM>();
        private List<Model.EmployeeM> employees = new List<Model.EmployeeM>();

        public DeleteUserScreen()
        {
            InitializeComponent();
            LoadData();
            UpdateDataGrid();
        }


        private void UpdateDataGrid()
        {
            switch (selectedTab)
            {
                case "Dentist":
                    DentistDataGrid.ItemsSource = dentists;
                    break;
                case "Customer":
                    CustomerDataGrid.ItemsSource = customers;
                    break;
                case "Employee":
                    EmployeeDataGrid.ItemsSource = employees;
                    break;
            }
        }

        private async Task LoadData()
        {
            dentists.Clear();
            customers.Clear();
            employees.Clear();

            var connectionString = ConfigurationManager
                .ConnectionStrings["DentalClinicManagementDbConnection"]
                .ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SelectUserRoleInformation", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserRole", selectedTab);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (selectedTab == "Dentist")
                            {
                                var dentist = new Model.DentistM
                                {
                                    DentistID = reader.GetInt32(reader.GetOrdinal("DentistID")),
                                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                    DentistAddress = reader.GetString(
                                        reader.GetOrdinal("DentistAddress")
                                    ),
                                    PhoneNumber = reader.GetString(
                                        reader.GetOrdinal("PhoneNumber")
                                    ),
                                    Birthday = reader.GetDateTime(reader.GetOrdinal("BirthDay")).ToString("dd/MM/yyyy")
                                };
                                dentists.Add(dentist);
                            }
                            else if (selectedTab == "Customer")
                            {
                                var customer = new Model.CustomerM
                                {
                                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                    CustomerAddress = reader.GetString(
                                        reader.GetOrdinal("CustomerAddress")
                                    ),
                                    PhoneNumber = reader.GetString(
                                        reader.GetOrdinal("PhoneNumber")
                                    ),
                                    Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday")).ToString("dd/MM/yyyy")
                                };
                                customers.Add(customer);
                            }
                            else if (selectedTab == "Employee")
                            {
                                var employee = new Model.EmployeeM
                                {
                                    EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                    EmployeeAddress = reader.GetString(
                                        reader.GetOrdinal("EmployeeAddress")
                                    ),
                                    PhoneNumber = reader.GetString(
                                        reader.GetOrdinal("PhoneNumber")
                                    ),
                                    Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday")).ToString("dd/MM/yyyy")
                                };
                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int? recordId = null;
            switch (selectedTab)
            {
                case "Dentist":
                    if (DentistDataGrid.SelectedItem is Model.DentistM selectedDentist)
                    {
                        recordId = selectedDentist.DentistID;
                    }
                    break;
                case "Customer":
                    if (CustomerDataGrid.SelectedItem is Model.CustomerM selectedCustomer)
                    {
                        recordId = selectedCustomer.CustomerID;
                    }
                    break;
                case "Employee":
                    if (EmployeeDataGrid.SelectedItem is Model.EmployeeM selectedEmployee)
                    {
                        recordId = selectedEmployee.EmployeeID;
                    }
                    break;
            }

            if (recordId.HasValue)
            {
                var connectionString = ConfigurationManager
                    .ConnectionStrings["DentalClinicManagementDbConnection"]
                    .ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (
                        SqlCommand command = new SqlCommand("DeleteRecordByRoleAndID", connection)
                    )
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserRole", selectedTab);
                        command.Parameters.AddWithValue("@RecordID", recordId.Value);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa thành công!");
                var deleteScreen = new DeleteUserScreen();
                deleteScreen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.");
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = (TabControl)sender;
            var selectedTabItem = (TabItem)tabControl.SelectedItem;

            switch (selectedTabItem.Header)
            {
                case "Dentist":
                    selectedTab = "Dentist";
                    break;
                case "Customer":
                    selectedTab = "Customer";
                    break;
                case "Employee":
                    selectedTab = "Employee";
                    break;
            }

            LoadData();
            UpdateDataGrid();
        }

    }
}
