using DentalService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddServiceRecord.xaml
    /// </summary>
    public partial class AddServiceRecord : Window
    {
        int ID;
        SqlConnection cn;
        DentistM dt;
        CustomerM cu;
        BindingList<DentalServiceM> _service = new BindingList<DentalServiceM>();
        public AddServiceRecord(SqlConnection connect, int idMR, DentistM dentist, CustomerM cus)
        {
            ID = idMR;
            cn = connect;
            dt = dentist;
            cu = cus;

            InitializeComponent();
            //get information of medicine
            var sql = "select * from DentalService";
            using (var command2 = new SqlCommand(sql, connect))
            {
                using (var reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idME = (int)reader["DentalServiceID"];
                        string name = (string)reader["ServiceName"];
                        int price = (int)reader["Price"];
                        
                        DentalServiceM rc = new DentalServiceM()
                        {
                            ServiceName = name,
                            DentalServiceId=idME,
                            Price = price,
                        };
                        _service.Add(rc);
                    }

                    Servicelist.ItemsSource = _service;
                }
            }
        }

        private void Option_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Service(object sender, RoutedEventArgs e)
        {
            //get data of information
            List<int> listIdOfService = new List<int>();
            foreach (var item in Servicelist.SelectedItems)
            {
                DentalServiceM service = item as DentalServiceM;
                listIdOfService.Add(service.DentalServiceId);
            }
            //insert data to database
            // use proc sp_addServiceToMRecord, truyền vào ID và listIdOfService
            for(int i = 0; i < listIdOfService.Count; i++)
            {
                //var sql = "exec sp_addServiceToMRecord @id,@idService";
                var sql = "exec addServiceToMRFixed @id,@idService";
                var command = new SqlCommand(sql, cn);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@idService", System.Data.SqlDbType.Int).Value = listIdOfService[i];
                int rowsAffected = command.ExecuteNonQuery();
            }

            var screen = new DetailRecord(cn, dt, cu, ID);
            this.Close();
            screen.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Quay về màn hình trước
            var screen = new DetailRecord(cn, dt, cu, ID);
            this.Close();
            screen.Show();
        }
    }
}
