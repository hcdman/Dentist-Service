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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        string connect;
        DentistM dentist;
        public UpdateAppointment(AppointmentM ap,string cn,DentistM dt)
        {
            InitializeComponent();
            connect = cn;
            dentist = dt;
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
            //get data, run sql update data
            var screen = new Dentist(connect, dentist);
            this.Close();
            screen.Show();
        }

       
    }
}
