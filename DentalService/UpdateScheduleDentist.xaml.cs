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
    /// Interaction logic for UpdateScheduleDentist.xaml
    /// </summary>
    public partial class UpdateScheduleDentist : Window
    {
        DentistM _dentist;
        string connect;
        public UpdateScheduleDentist( DentistScheduleM sche, string connect, DentistM dt)
        {
            InitializeComponent();
            this.connect = connect;
            _dentist = dt;
            this.DataContext = sche;
            apDate.SelectedDate = sche.WorkingDay.Equals("") ? DateTime.Now : DateTime.ParseExact(sche.WorkingDay, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
          
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            var screen = new Dentist(connect, _dentist);
        }
    }
}
