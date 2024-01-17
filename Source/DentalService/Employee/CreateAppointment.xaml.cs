using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace DentalService.Employee; 
/// <summary>
/// Interaction logic for CreateAppointment.xaml
/// </summary>
public partial class CreateAppointment : Window {

    public EmployeeViewModel ViewModel { get; set; } = EmployeeViewModel.GetInstance();
    public CreateAppointment() {
        InitializeComponent();
        this.DataContext = ViewModel;
        ViewModel.DentistFreeTimeSchedule.Clear();
    }

    public void OnAppointmentDateChanged(object sender, SelectionChangedEventArgs e) {
        if(StartTimeComboBox.SelectedItem == null || EndTimeComboBox.SelectedItem == null) {
            return;
        }
        
        var startTime = (int)StartTimeComboBox.SelectedItem;
        var endTime = (int)EndTimeComboBox.SelectedItem;
        var date = (DateTime)AppointmentDatePicker.SelectedDate;
        ViewModel.SyncDentistFreeTimeSchedule(date, startTime, endTime);
    }

    public void OnStartTimeChanged(object sender, SelectionChangedEventArgs e) {
        if (AppointmentDatePicker.SelectedDate == null || EndTimeComboBox.SelectedItem == null) {
            return;
        }

        var startTime = (int)StartTimeComboBox.SelectedItem;
        var endTime = (int)EndTimeComboBox.SelectedItem;
        var date = (DateTime)AppointmentDatePicker.SelectedDate;
        ViewModel.SyncDentistFreeTimeSchedule(date, startTime, endTime);
    }

    public void OnEndTimeChanged(object sender, SelectionChangedEventArgs e) {
        if (AppointmentDatePicker.SelectedDate == null || StartTimeComboBox.SelectedItem == null) {
            return;
        }

        var startTime = (int)StartTimeComboBox.SelectedItem;
        var endTime = (int)EndTimeComboBox.SelectedItem;
        var date = (DateTime)AppointmentDatePicker.SelectedDate;
        ViewModel.SyncDentistFreeTimeSchedule(date, startTime, endTime);

    }

    private void CloseWindow(object sender, RoutedEventArgs e) {
        //close window
        this.Close();
    }

    private void CreateAppointmentClick(object sender, RoutedEventArgs e) {
        try {
            ViewModel.CreatAppointment();
            this.Close();
            ViewModel.SyncCommittedAppointmentList();
        }
        catch(Exception ex) {
            MessageBox.Show(ex.Message);
        }
        //Task.Run(ViewModel.SyncCommittedAppointmentList);
    }

    private void DentistsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        CreateAppointmentButton.IsEnabled = true;
    }
}
