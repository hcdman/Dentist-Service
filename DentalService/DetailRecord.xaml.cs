using DentalService.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DetailRecord.xaml
    /// </summary>
    public partial class DetailRecord : Window
    {
        
        public DetailRecord(string connect, DentistM dentsit)
        {
            InitializeComponent();
            //get information of customer
            //get information medicine
            //get information dental service
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Medicine(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Service(object sender, RoutedEventArgs e)
        {

        }
    }
}
