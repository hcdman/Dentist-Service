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
    /// Interaction logic for UpdateScheduleDentist.xaml
    /// </summary>
    public partial class UpdateScheduleDentist : Window
    {
        DentistM _dentist;
        SqlConnection connection;
        string connect;
        public UpdateScheduleDentist( DentistScheduleM sche, SqlConnection cn, DentistM dt)
        {
            InitializeComponent();
            cn.Close();
            string connectionString = @"Server=.\SQLEXPRESS;
                                       Database = DentalClinicManagement;
                                       Trusted_Connection = yes";
            connect = connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
          
            _dentist = dt;
            this.DataContext = sche;
            apDate.SelectedDate = sche.WorkingDay.Equals("") ? DateTime.Now : DateTime.ParseExact(sche.WorkingDay, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
          
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            //update date
            try
            {
                //get data, run sql update data
                var screenn = new Dentist(connect,_dentist);
                //get data of information
                DateTime? selectedDate = apDate.SelectedDate;
                string newDate = selectedDate.Value.ToString("yyyy-MM-dd");
                
                var sql = @"use DentalClinicManagement
                            go
                            exec sp_Edit_APDATE  @Id,@newDate";
                var command = new SqlCommand(sql, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = _dentist.DentistID;
                command.Parameters.Add("@newDate", SqlDbType.VarChar).Value = newDate;
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update successful!");
                    this.Close();
                    screenn.Show();
                }
                else
                {
                    MessageBox.Show("Update failed. No rows affected.");
                }
            }
            catch (Exception ex)
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
