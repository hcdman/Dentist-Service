using CommunityToolkit.Mvvm.ComponentModel;
using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Employee; 

public class EmployeeViewModel : ObservableObject
{
    private static EmployeeViewModel? instance;
    public EmployeeViewModel(string connectionString, EmployeeM emp) {
        instance ??= this; 

        Employee = emp;
        ConnectionString = connectionString;
        SyncAppointmentList();
    }

    public static EmployeeViewModel GetInstance() {
        return instance ?? new EmployeeViewModel("", new EmployeeM());
    }

    private void SyncAppointmentList() {
        using SqlConnection connection = new(ConnectionString);
        connection.Open();
        SqlCommand command = new(ReadUncommittedAppointmentProc, connection);
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
            Appointment appointment = new() {
                AppointmentID = (int)reader["AppointmentID"],
                CustomerID = (int)reader["CustomerID"],
                DentistId = (int)reader["DentistId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
                UncommittedUpcommingAppointmentList.Add(appointment);
        }
        reader.Close();

        command = new(ReadCommittedAppointmentProc, connection);
        using SqlDataReader reader2 = command.ExecuteReader();
        while (reader2.Read()) {
            Appointment appointment = new() {
                AppointmentID = (int)reader2["AppointmentID"],
                CustomerID = (int)reader2["CustomerID"],
                DentistId = (int)reader2["DentistId"],
                AppointmentDate = (DateTime)reader2["AppointmentDate"],
                StartTime = (TimeSpan)reader2["StartTime"],
                EndTime = (TimeSpan)reader2["EndTime"]
            };
            CommittedUpcommingAppointmentList.Add(appointment);
        }
    }



    const string ReadUncommittedAppointmentProc = "EXEC ReadAppointmentsByCustomerUncommitted @CustomerID = 1";
    const string ReadCommittedAppointmentProc = "EXEC ReadAppointmentsByCustomerCommitted @CustomerID = 1";

    private string ConnectionString;
    public EmployeeM Employee { get; set; }
    public ObservableCollection<Appointment> CommittedUpcommingAppointmentList { get; set; } = new();
    public ObservableCollection<Appointment> UncommittedUpcommingAppointmentList { get; set; } = new();

}
