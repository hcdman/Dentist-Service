using System;
using System.Configuration;
using System.Data;
using System.Windows;
using DentalService.Model;
using Microsoft.Data.SqlClient;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for UpdateMedicineWindow.xaml
    /// </summary>
    public partial class UpdateMedicineWindow : Window
    {
        MedicineM med = new MedicineM();

        public UpdateMedicineWindow(MedicineM med)
        {
            InitializeComponent();
            this.med = med;
            txtMedicineName.Text = med.MedicineName;
            txtUnit.Text = med.Unit;
            txtPrescription.Text = med.Prescription;
            txtQuantity.Text = med.QuantityOnStock.ToString();
            //Conver string to DatePicker
            dpExpirationDate.SelectedDate = med.ExpirationDate.Equals("") ? DateTime.Now : DateTime.ParseExact(med.ExpirationDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtPrice.Text = med.Price.ToString();
            txtDescription.Text = med.Description;
        }

        private void btnUpdateMedicine_Click(object sender, RoutedEventArgs e)
        {        
            try{
                var connectionString = ConfigurationManager
                .ConnectionStrings["DentalClinicManagementDbConnection"]
                .ConnectionString;
            
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdateMedicine", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MedicineID", med.MedicineID);
                        cmd.Parameters.AddWithValue("@MedicineName", txtMedicineName.Text);
                        cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                        cmd.Parameters.AddWithValue("@Prescription", txtPrescription.Text);
                        cmd.Parameters.AddWithValue("@QuantityOnStock", txtQuantity.Text);
                        cmd.Parameters.AddWithValue("@ExpirationDate", dpExpirationDate.SelectedDate);
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Update medicine successfully!");
                this.Close();
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
