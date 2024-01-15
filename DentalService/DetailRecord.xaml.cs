using DentalService.Model;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Interaction logic for DetailRecord.xaml
    /// </summary>
    public partial class DetailRecord : Window
    {
        SqlConnection connection;
        int ID;
        string cnString;
        CustomerM cus;
        DentistM _dentist;
        BindingList<RecordMedicine> _medicine = new BindingList<RecordMedicine>();
        BindingList<RecordService> _service = new BindingList<RecordService>();
        public DetailRecord(SqlConnection connect, DentistM d, CustomerM customer,int mrID)
        {
            InitializeComponent();
            connection = connect;
            this.DataContext = customer;
            cus = customer;
            _dentist = d;
            ID = mrID;
            //var connectionString = ConfigurationManager.ConnectionStrings["TaiMSIConnectionString"].ConnectionString;
            //get information medicine
            var sql = "select * from MedicalRecord_Medicine,Medicine where MedicalRecord_Medicine.MRecordID= @idMR and MedicalRecord_Medicine.MedicineID=Medicine.MedicineID";
            using (var command2 = new SqlCommand(sql, connect))
            {
                command2.Parameters.Add("@idMR", SqlDbType.Int).Value = mrID;
                using (var reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idMRC = (int)reader["MRecordID"];
                        int idME = (int)reader["MedicineID"];
                        string name = (string)reader["MedicineName"];
                        int price = (int)reader["Price"];
                        int quantity = (int)reader["Quantity"];
                        RecordMedicine rc = new RecordMedicine(idMRC, idME, name, price, quantity);
                        _medicine.Add(rc);
                    }
                 
                    Medicinelist.ItemsSource = _medicine;
                }
            }
            //get information dental service
            var sql1 = "select * from MedicalRecord_DentalService,DentalService where MedicalRecord_DentalService.MRecordID= @idMR and MedicalRecord_DentalService.MRecordID=DentalService.DentalServiceID";
            using (var command3 = new SqlCommand(sql1, connect))
            {
                command3.Parameters.Add("@idMR", SqlDbType.Int).Value = mrID;
                using (var reader = command3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idMRC = (int)reader["MRecordID"];
                        int idME = (int)reader["DentalServiceID"];
                        string name = (string)reader["ServiceName"];
                        int price = (int)reader["Price"];
       
                        RecordService rc = new RecordService(idMRC, idME, name, price);
                        _service.Add(rc);
                    }

                    Servicelist.ItemsSource = _service;
                }
            }

            var sqlTotalPrice = "select * from Invoice where MedicalRecord = @idMR";
            using (var command3 = new SqlCommand(sqlTotalPrice, connect))
            {
                command3.Parameters.Add("@idMR", SqlDbType.Int).Value = mrID;
                using (var reader = command3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int price = (int)reader["TotalCost"];

                        totalPriceTxt.Text = price.ToString();
                    }

                  
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Medicine(object sender, RoutedEventArgs e)
        {
            // id, connect
            var screen = new AddMedicineRecord(connection, ID,_dentist,cus);
            this.Close();
            screen.Show();
        }

        private void Add_Service(object sender, RoutedEventArgs e)
        {
            // id, connect
            var screen = new AddServiceRecord(connection, ID, _dentist, cus);
            this.Close();
            screen.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
