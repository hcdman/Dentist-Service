using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DentalService.Model;
using Microsoft.Data.SqlClient;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for ManageMedicineScreen.xaml
    /// </summary>
    public partial class ManageMedicineScreen : Window
    {
        ObservableCollection<MedicineM> medicines = new ObservableCollection<MedicineM>();
        ObservableCollection<MedicineM> expiredMedicines = new ObservableCollection<MedicineM>();

        public ManageMedicineScreen()
        {
            InitializeComponent();
            dgMedicines.ItemsSource = medicines;
            lbExpiredMedicines.ItemsSource = expiredMedicines;
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            medicines.Clear();

            var connectionString = ConfigurationManager
                .ConnectionStrings["DentalClinicManagementDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllMedicines", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var medicine = new MedicineM
                            {
                                MedicineID = reader.GetInt32(reader.GetOrdinal("MedicineID")),
                                MedicineName = reader.GetString(reader.GetOrdinal("MedicineName")),
                                Unit = reader.GetString(reader.GetOrdinal("Unit")),
                                Prescription = reader.GetString(reader.GetOrdinal("Prescription")),
                                QuantityOnStock = reader.GetInt32(
                                    reader.GetOrdinal("QuantityOnStock")
                                ),
                                ExpirationDate = reader
                                    .GetDateTime(reader.GetOrdinal("ExpirationDate"))
                                    .ToString("dd/MM/yyyy"),
                                Price = reader.GetInt32(reader.GetOrdinal("Price")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                            medicines.Add(medicine);
                        }
                    }
                }
            }

            // Load expired medicines
            expiredMedicines.Clear();

            using (SqlConnection con = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("spGetExpiredMedicines", con)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            var medicine = new MedicineM {
                                MedicineID = reader.GetInt32(reader.GetOrdinal("MedicineID")),
                                MedicineName = reader.GetString(reader.GetOrdinal("MedicineName")),
                                Unit = reader.GetString(reader.GetOrdinal("Unit")),
                                Prescription = reader.GetString(reader.GetOrdinal("Prescription")),
                                QuantityOnStock = reader.GetInt32(
                                    reader.GetOrdinal("QuantityOnStock")
                                ),
                                ExpirationDate = reader
                                    .GetDateTime(reader.GetOrdinal("ExpirationDate"))
                                    .ToString("dd/MM/yyyy"),
                                Price = reader.GetInt32(reader.GetOrdinal("Price")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                            expiredMedicines.Add(medicine);
                        }
                    }
                }
             }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AddMedicineWindow();
            screen.ShowDialog();
            LoadMedicines();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedicines.SelectedItem is MedicineM selectedMedicine)
            {
                var screen = new UpdateMedicineWindow(selectedMedicine);
                screen.ShowDialog();
                LoadMedicines();
            }
            else
            {
                MessageBox.Show("Please select a medicine to update.");
            }
        }

        private void btnDeleteExpired_Click(object sender, RoutedEventArgs e)
        {
            if (lbExpiredMedicines.SelectedItem is MedicineM selectedMedicine)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DentalClinicManagementDbConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteMedicine", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MedicineID", selectedMedicine.MedicineID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Medicine deleted successfully.");
                LoadMedicines();
            }
            else
            {
                MessageBox.Show("Please select a medicine to delete.");
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            if (dgMedicines.SelectedItem is MedicineM selectedMedicine) {
                var connectionString = ConfigurationManager.ConnectionStrings["DentalClinicManagementDbConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand("spDeleteMedicine", con)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MedicineID", selectedMedicine.MedicineID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Medicine deleted successfully.");
                LoadMedicines();
            } else {
                MessageBox.Show("Please select a medicine to delete.");
            }
        }
    }
}
