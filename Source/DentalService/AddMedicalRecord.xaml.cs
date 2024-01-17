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
    /// Interaction logic for AddMedicalRecord.xaml
    /// </summary>
    public partial class AddMedicalRecord : Window
    {
        string cn;
        DentistM dentist;
        public AddMedicalRecord(string cnn, DentistM dt)
        {
            InitializeComponent();
            cn = cnn;
            dentist = dt;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            var screen = new Dentist(cn, dentist);
            this.Close();
            screen.Show();
        }
    }
}
