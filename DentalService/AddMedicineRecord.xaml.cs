﻿using DentalService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddMedicineRecord.xaml
    /// </summary>
    
    public partial class AddMedicineRecord : Window
    {
        int ID;
        SqlConnection cn;
        DentistM dt;
        CustomerM cu;
        BindingList<MedicineM> _medicine = new BindingList<MedicineM>();
        public AddMedicineRecord(SqlConnection connect,int idMR,DentistM dentist,CustomerM cus)
        {
            ID = idMR;
            cn = connect;
            dt = dentist;
            cu = cus;

            InitializeComponent();
            //get information of medicine
            var sql = "select * from Medicine";
            using (var command2 = new SqlCommand(sql, connect))
            {
                using (var reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idME = (int)reader["MedicineID"];
                        string name = (string)reader["MedicineName"];
                        int price = (int)reader["Price"];
                        string Description = (string)reader["Description"];
                        int quantity = (int)reader["QuantityOnStock"];
                        DateTime exprire = (DateTime)reader["ExpirationDate"];
                        string date = exprire.ToString("dd-MM-yyyy");
                        MedicineM rc = new MedicineM()
                        {
                            MedicineID = idME,
                            MedicineName = name,
                            Price = price,
                            ExpirationDate = date,
                            Description = Description,
                            QuantityOnStock = quantity,
                        };
                        _medicine.Add(rc);
                    }

                    Medicinelist.ItemsSource = _medicine;
                }
            }
        }

        private void Option_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Medicine(object sender, RoutedEventArgs e)
        {
            var screen = new DetailRecord(cn, dt, cu, ID);
            this.Close();
            screen.Show();
        }
    }
}
