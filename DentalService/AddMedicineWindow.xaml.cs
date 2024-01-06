using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using Microsoft.Data.SqlClient;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for AddMedicineWindow.xaml
    /// </summary>
    public partial class AddMedicineWindow : Window
    {
        public AddMedicineWindow()
        {
            InitializeComponent();
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (txtMedicineName.Text == "" || txtUnit.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            var connectionString = ConfigurationManager
                .ConnectionStrings["DentalClinicManagementDbConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spAddMedicine", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MedicineName", txtMedicineName.Text);
                        cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                        cmd.Parameters.AddWithValue("@Prescription", txtPrescription.Text);
                        cmd.Parameters.AddWithValue(
                            "@QuantityOnStock",
                            int.Parse(txtQuantity.Text)
                        );
                        cmd.Parameters.AddWithValue(
                            "@ExpirationDate",
                            dpExpirationDate.SelectedDate
                        );
                        cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Medicine added successfully");
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"An error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}
