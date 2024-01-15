using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Employee; 

public partial class EmployeeViewModel : ObservableRecipient
{
    private static EmployeeViewModel? instance;
    private DataAccess Accessor;
    public EmployeeViewModel(string connectionString, EmployeeM emp) {
        instance ??= this; 
        Employee = emp;
        Accessor = new DataAccess(connectionString);
        Customer = new CustomerM();
        SelectedFreeTimeSlot = null;
    }

    public static EmployeeViewModel GetInstance() {
        return instance ?? new EmployeeViewModel("", new EmployeeM());
    }

    public void SyncCommittedAppointmentList() {
        UpcommingAppointmentList.Clear();

        var data = Accessor.GetUpcommingAppointmentOfCustomerCommitted(Customer.CustomerID);
        foreach (var item in data) {
            UpcommingAppointmentList.Add(item);
        }
     
    }
    public void SyncUncommmittedAppointmentList() {
        var data = Accessor.GetUpcommingAppointmentOfCustomerUncommitted(Customer.CustomerID);
        UpcommingAppointmentList.Clear();
        foreach (var item in data) {
            UpcommingAppointmentList.Add(item);
        }
    }
    public void SyncCustomer(string phoneSearchText) {
        if(phoneSearchText.Length != 10) {
            return;
        }
        Debug.WriteLine(phoneSearchText);
        Customer = Accessor.GetCustomerByPhone(phoneSearchText);
        SyncCommittedAppointmentList();
    }

    public void SyncDentistFreeTimeSchedule(DateTime date, int startHour, int endHour) {
        var data = Accessor.GetDentistsFreeTimeSlots(date, startHour, endHour);
        Debug.WriteLine(data.Count);
        DentistFreeTimeSchedule.Clear();
        foreach(var item in data) {
            DentistFreeTimeSchedule.Add(item);
        }
    }

    public void CreatAppointment() {
        if(SelectedFreeTimeSlot == null) {
            return;
        }

        try {
            var appointment = new Appointment() {
                CustomerID = Customer.CustomerID,
                DentistId = SelectedFreeTimeSlot.DentistID,
                AppointmentDate = SelectedFreeTimeSlot.WorkingDay,
                StartTime = new TimeSpan(SelectedFreeTimeSlot.FreeHour, 0, 0),
                EndTime = new TimeSpan(SelectedFreeTimeSlot.FreeHour + 1, 0, 0)
            };
            Accessor.CreateAppointment(appointment);
        }
        catch (Exception) {
            throw;
        }  
    }
    
    [ObservableProperty]
    private EmployeeM employee;

    [ObservableProperty]
    private CustomerM customer;

    [ObservableProperty]
    private DentisFreeTimeSlot? selectedFreeTimeSlot;

    public ObservableCollection<Appointment> UpcommingAppointmentList { get; set; } = new();
    public ObservableCollection<DentisFreeTimeSlot> DentistFreeTimeSchedule { get; set; } = new();
    
    public List<int> HourList { get; set; } = new List<int>() { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

}
