using DentalService.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdateAppE.xaml
    /// </summary>
    
    public partial class UpdateAppE : Window
    {
        string connect;
        SqlConnection connection;
        AppointmentM app;
        EmployeeM emp;
        public UpdateAppE(AppointmentM ap, SqlConnection cn, EmployeeM dt)
        {
            InitializeComponent();
            app = ap;
            cn.Close();
            string connectionString = @"Server=.\SQLEXPRESS;
                                       Database = DentalClinicManagement;
                                       Trusted_Connection = yes";
            connect = connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            
            
           
            emp = dt;
            apDate.SelectedDate = ap.AppointmentDate.Equals("") ? DateTime.Now : DateTime.ParseExact(ap.AppointmentDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            this.DataContext = ap;
            //status
            for (int i = 0; i < Status.Items.Count; i++)
            {
                ComboBoxItem currentItem = (ComboBoxItem)Status.Items[i];
                string value = currentItem.Content.ToString();

                if (value == ap.Status)
                {
                    Status.SelectedIndex = i;
                    break;
                }
            }

        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            try
            { 
            //get data, run sql update data
            var screen = new Employee.EmployeeWindow(connect, emp);
            //get data of information
            int newDentistID = 0;
            int.TryParse(dent.Text, out newDentistID);
            var sql = "exec sp_Edit_APDENTIST @id,@newDentist";
            var command = new SqlCommand(sql, connection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = app.AppointmentId;
            command.Parameters.Add("@newDentist", SqlDbType.VarChar).Value = newDentistID;
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update successful!");
                    this.Close();
                    screen.Show();
                }
                else
                {
                    MessageBox.Show("Update failed. No rows affected.");
                }
        }
        catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close(); // Close the connection in the finally block to ensure it is closed even if an exception occurs.
            }
        }
    }
}
