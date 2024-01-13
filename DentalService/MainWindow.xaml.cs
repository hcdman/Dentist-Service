using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Server=.\SQLEXPRESS;
                                       Database = DentalClinicManagement;
                                       Trusted_Connection = yes";
            //var connectionString = ConfigurationManager.ConnectionStrings["TaiMSIConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            //get role 

            ComboBoxItem typeItem = (ComboBoxItem)Role.SelectedItem;
            string role = typeItem.Content.ToString();

            var sql = "";
            //check role
            switch (role)
            {
                case "Admin":
                    sql = "select * from Administrator a where a.Username = @userName and a.AdminPassword = @passWord ";
                    break;
                case "Dentist":
                    sql = "select * from Dentist a where a.PhoneNumber = @userName and a.DentistPassword = @passWord ";
                    break;
                case "Customer":
                    sql = "select * from Customer a where a.PhoneNumber = @userName and a.CustomerPassword = @passWord ";
                    break;
                case "Employee":
                    sql = "select * from Employee a where a.PhoneNumber = @userName and a.EmployeePassword = @passWord ";
                    break;
            }

            var command = new SqlCommand(sql, connection);

            //get username and password
            string userName = UserName.Text;
            string passWord = PassWord.Password;
            command.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@passWord", SqlDbType.VarChar).Value = passWord;
            var reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    switch (role)
                    {
                        case "Admin":
                            var screen = new Admin(userName);
                            this.Close();
                            screen.Show();
                            break;
                        case "Dentist":
                            int id = (int)reader["DentistID"];
                            string name = (string)reader["FullName"];
                            string address = (string)reader["DentistAddress"];
                            string phone = (string)reader["PhoneNumber"];
                            DateTime birthdayR = (DateTime)reader["BirthDay"];
                            //string birthdayString = birthday.ToString("yyyy-MM-dd");
                            string birthday = birthdayR.ToString("dd-MM-yyyy");
                            DentistM dentist = new DentistM(id, name, address, phone, birthday);
                            var screen_2 = new Dentist(connectionString, dentist);
                            this.Close();
                            reader.Close();
                            screen_2.Show();
                            break;
                        case "Customer":
                            int idC = (int)reader["CustomerID"];
                            string nameC = (string)reader["FullName"];
                            DateTime birthdayC = (DateTime)reader["Birthday"];
                            string phoneNumberC = (string)reader["PhoneNumber"];
                            CustomerM cus = new CustomerM(idC, nameC, birthdayC, phoneNumberC);
                            var screen_3 = new Customer(connection, cus);
                            this.Close();
                            screen_3.Show(); break;
                        case "Employee":
                            int idE = (int)reader["EmployeeID"];
                            string nameE = (string)reader["FullName"];
                            EmployeeM emp = new EmployeeM(idE, nameE);
                            var screen_4 = new Employee.EmployeeWindow(connection, emp);
                            this.Close();
                            screen_4.Show(); break;
                    }

                }
                else
                {
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác !");
                }
            }
            finally
            {
                connection.Close();
                
            }
            
        }
    }
}