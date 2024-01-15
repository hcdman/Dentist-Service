using DentalService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
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
            customer.Birthday = ((DateTime)reader["Birthday"]).ToString("dd/MM/yyyy");
        }
        reader.Close();
        connection.Close();
        return customer;
    }
    public List<Appointment> GetUpcommingAppointmentOfCustomerUncommitted(int customerId) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = $"EXEC SP_ReadAppointmentsOfCustomerUncommitted @CustomerID = {customerId}";
        SqlCommand command = new(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<Appointment> appointments = new();
        while (reader.Read()) {
            Appointment appointment = new() {
                CustomerID = (int)reader["CustomerID"],
                DentistId = (int)reader["DentistId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
            appointments.Add(appointment);
        }
        reader.Close();
        connection.Close();
        return appointments;
    }
    public List<Appointment> GetUpcommingAppointmentOfCustomerCommitted(int customerId) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = $"EXEC SP_ReadAppointmentsOfCustomerCommitted @CustomerID = {customerId}";
        SqlCommand command = new(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<Appointment> appointments = new();
        while (reader.Read()) {
            Appointment appointment = new() {
                CustomerID = (int)reader["CustomerID"],
                DentistId = (int)reader["DentistId"],
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };


            appointments.Add(appointment);
        }
        reader.Close();
        connection.Close();
        return appointments;
    }

    public List<DentisFreeTimeSlot> GetDentistsFreeTimeSlots(DateTime date, int startTime, int endTime) {
        List<DentisFreeTimeSlot> dentisFreeTimes = new();

        var scheduletList = GetDentistsSchedule(date);
        foreach (var s in scheduletList) {
            var dentistAppointments = GetDentistAppointments(s.DentistId, date);
            var freeTimeSlots = GetFreeTimeSlots(s, startTime, endTime, dentistAppointments);
            dentisFreeTimes.AddRange(freeTimeSlots);
        }

        return dentisFreeTimes;
    }

    private List<DentisFreeTimeSlot> GetFreeTimeSlots(DentistSchedule s, int startFilterTime, int endFilterTime, List<Appointment> dentistAppointments) {
        List<DentisFreeTimeSlot> result = new();

        List<int> dentistWorkingHour = new List<int>();
        for(int i = s.StartTime.Hours; i < s.EndTime.Hours ; i++) {
            dentistWorkingHour.Add(i);
        }

        if(startFilterTime >= s.EndTime.Hours || endFilterTime <= s.StartTime.Hours) {
            
        }
        else {
            int first = startFilterTime>=s.StartTime.Hours ? startFilterTime : s.StartTime.Hours;
            int end = endFilterTime <= s.EndTime.Hours ? endFilterTime : s.EndTime.Hours;
            for (int j = first; j < end; j++) {
                if (!dentistWorkingHour.Contains(j)) {
                    break;
                }
                else {
                    DentisFreeTimeSlot freeTimeSlot = new() {
                        DentistID = s.DentistId,
                        DentistName = "Dentist " + s.DentistId,
                        WorkingDay = s.WorkingDay,
                        FreeHour = j
                    };
                    result.Add(freeTimeSlot);
                }
            }
        }
        return result;
    }

    private List<Appointment> GetDentistAppointments(int dentistId, DateTime date) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = $"Select * from Appointment where DentistId = {dentistId} and AppointmentDate = '{date.ToString("yyyy-MM-dd")}'";
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
        connection.Close();

        return appointments;

    }

    private List<DentistSchedule> GetDentistsSchedule(DateTime date) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = $"Select * from DentistSchedule where workingday = '{date.ToString("yyyy-MM-dd")}'";
        SqlCommand command = new(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<DentistSchedule> schedules = new();
        while (reader.Read()) {
            DentistSchedule schedule = new() {
                ScheduleId = (int)reader["ScheduleId"],
                DentistId = (int)reader["DentistId"],
                WorkingDay = (DateTime)reader["WorkingDay"],
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
            schedules.Add(schedule);
        }
        reader.Close();
        connection.Close();
        return schedules;
    }
    
    public void CreateAppointment(Appointment appointment) {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string sql = $"EXEC SP_CreateAppointment @CustomerID = {appointment.CustomerID}, @DentistId = {appointment.DentistId}, @AppointmentDate = '{appointment.AppointmentDate.ToString("yyyy-MM-dd")}', @StartTime = '{appointment.StartTime}', @EndTime = '{appointment.EndTime}'";
        SqlCommand command = new(sql, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

}
