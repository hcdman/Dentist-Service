using DentalService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;


namespace DentalService.Employee; 
public class DataAccess {
    string ConnectionString { get; set; } 
    public DataAccess(string connectionString) {
        ConnectionString = connectionString;
    }

    public CustomerM GetCustomerByPhone(string phone) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = "SELECT * FROM Customer WHERE PhoneNumber = @phone";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@phone", phone);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        CustomerM customer = new();
            
        while (reader.Read()) {
            customer.CustomerID = (int)reader["CustomerID"];
            customer.FullName = (string)reader["FullName"];
            customer.CustomerAddress = (string)reader["CustomerAddress"];
            customer.PhoneNumber = (string)reader["PhoneNumber"];
            customer.Birthday = (string)reader["Birthday"];
        }
        reader.Close();
        return customer;
    }

    public List<Appointment> GetUpcommingAppointmentOfCustomerUncommitted(int customerId) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = "EXEC ReadAppointmentsByCustomerUncommitted @CustomerID = 1";
        SqlCommand command = new(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<Appointment> appointments = new();
        while (reader.Read()) {
            Appointment appointment = new() {
                AppointmentID = (int)reader["AppointmentID"],
                CustomerID = (int)reader["CustomerID"],
                DentistId = (int)reader["DentistId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
            appointments.Add(appointment);
        }
        reader.Close();
        return appointments;
    }
    public List<Appointment> GetUpcommingAppointmentOfCustomerCommitted(int customerId) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = "EXEC ReadAppointmentsByCustomerCommitted @CustomerID = 1";
        SqlCommand command = new(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<Appointment> appointments = new();
        while (reader.Read()) {
            Appointment appointment = new() {
                AppointmentID = (int)reader["AppointmentID"],
                CustomerID = (int)reader["CustomerID"],
                DentistId = (int)reader["DentistId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
            appointments.Add(appointment);
        }
        reader.Close();
        return appointments;
    }

    public List<DentisFreeTime> GetDentisFreeTime(DateTime date, TimeSpan startTime, TimeSpan endTime) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = "EXEC ReadDentistFreeTime @Date = @date, @StartTime = @startTime, @EndTime = @endTime";
        SqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("@date", date);
        command.Parameters.AddWithValue("@startTime", startTime);
        command.Parameters.AddWithValue("@endTime", endTime);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<DentisFreeTime> freeTimes = new();
        while (reader.Read()) {
            DentisFreeTime freeTime = new() {
                DentistID = (int)reader["DentistID"],
                DentistName = (string)reader["FullName"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
            freeTimes.Add(freeTime);
        }
        reader.Close();
        return freeTimes;
    }
}
