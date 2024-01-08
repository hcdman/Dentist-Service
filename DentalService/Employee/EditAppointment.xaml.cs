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
        DentistsDataGrid.ItemsSource = DentistFreeTimeSchedule;
    }

    public List<int> HourList { get; set; } = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
    public ObservableCollection<DentisFreeTime> DentistFreeTimeSchedule = new() {
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024,1,15), FreeHour=8},
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024,1,15), FreeHour=9},
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024, 1, 15), FreeHour=10},
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024, 1, 15), FreeHour=13},
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024, 1, 15), FreeHour=14},
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024, 1, 15), FreeHour=15},
        new() {DentistId=2, DentistName = "Conan", WorkingDay = new DateTime(2024, 1, 15), FreeHour=16},
        new() {DentistId=1, DentistName = "Hulk", WorkingDay = new DateTime(2024, 1, 15), FreeHour=13},
        new() {DentistId=1, DentistName = "Hulk", WorkingDay = new DateTime(2024, 1, 15), FreeHour=14},
        new() {DentistId=1, DentistName = "Hulk", WorkingDay = new DateTime(2024, 1, 15), FreeHour=15},
        new() {DentistId=1, DentistName = "Hulk", WorkingDay = new DateTime(2024, 1, 15), FreeHour=8},
        new() {DentistId=1, DentistName = "Hulk", WorkingDay = new DateTime(2024, 1, 15), FreeHour=9},
    };

}
