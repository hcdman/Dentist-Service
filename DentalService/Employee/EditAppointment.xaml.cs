using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DentalService.Employee; 
/// <summary>
/// Interaction logic for EditAppointment.xaml
/// </summary>
public partial class EditAppointment : Window {
    public EditAppointment() {
        InitializeComponent();
        this.DataContext = this;
    }

    public List<int> HourList { get; set; } = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
    public ObservableCollection<DentisFreeTimeSlot> DentistFreeTimeSchedule = new();

}
