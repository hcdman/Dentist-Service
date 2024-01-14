using DentalService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Dentist.xaml
    /// </summary>
    /// 
    public partial class Dentist : Window
    {
        SqlConnection connection =new SqlConnection();

        string connectString;
        int Id;
        DentistM _dentist;
        BindingList<DentistScheduleM> _scheduleDentist = new BindingList<DentistScheduleM>();
        BindingList<AppointmentM> _appointment = new BindingList<AppointmentM>();
        BindingList<MedicalRecord> _medical = new BindingList<MedicalRecord>();
        public Dentist(string cn, DentistM dentist)
        {
            InitializeComponent();
            connectString = cn;
            connection = new SqlConnection(cn);
            connection.Open();
            _dentist = dentist;
            this.DataContext= _dentist;
            //get data of dentist schedule
            var sql = "select * from DentistSchedule where DentistID = @idDentist";
            using (var command2 = new SqlCommand(sql, connection))
            {
                
                command2.Parameters.Add("@idDentist", SqlDbType.Int).Value = _dentist.DentistID;
                using (var reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idSchedule = (int)reader["ScheduleId"];
                        int idDentist = (int)reader["DentistID"];
                        DateTime WorkkingDay = (DateTime)reader["WorkingDay"];
                        string workDay = WorkkingDay.ToString("dd-MM-yyyy");
                        TimeSpan startTime = (TimeSpan)reader["StartTime"];
                        string startTimeString = startTime.ToString(@"hh\:mm");
                        TimeSpan endTime = (TimeSpan)reader["EndTime"];
                        string endTimeString = endTime.ToString(@"hh\:mm");
                        DentistScheduleM temp = new DentistScheduleM(idSchedule, idDentist, workDay, startTimeString, endTimeString);
                        _scheduleDentist.Add(temp);
                        // DentistM dentist = new DentistM(id, name, address, phone, birthday);
                    }
                    Schedule.ItemsSource = _scheduleDentist;
                }
            }
            //get data of appoint ment
            var sql2 = "select * from Appointment where DentistID = @idDentist";
            using (var command3 = new SqlCommand(sql2, connection))
            {

                command3.Parameters.Add("@idDentist", SqlDbType.Int).Value = _dentist.DentistID;
                using (var reader = command3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idAP = (int)reader["AppointmentID"];
                        int idDentist = (int)reader["DentistID"];
                        int idCus = (int)reader["CustomerID"];
                        DateTime apDate = (DateTime)reader["AppointmentDate"];
                        string app = apDate.ToString("dd-MM-yyyy");
                        string status = (string)reader["Status"];
                        bool createby = (bool)reader["CreatedByDentist"];
                        TimeSpan startTime = (TimeSpan)reader["StartTime"];
                        string startTimeString = startTime.ToString(@"hh\:mm");
                        TimeSpan endTime = (TimeSpan)reader["EndTime"];
                        string endTimeString = endTime.ToString(@"hh\:mm");
                        AppointmentM temp = new AppointmentM(idAP, app, startTimeString, endTimeString, idCus, idDentist, createby, status);
                        _appointment.Add(temp);
                        // DentistM dentist = new DentistM(id, name, address, phone, birthday);
                    }
                    DentistAppoitment.ItemsSource = _appointment;
                }
            }
            //get data of medical record
            var sql3 = "select * from MedicalRecord,Customer where DentistID = @idDentist and Customer.CustomerID=MedicalRecord.CustomerID";
            using (var command4 = new SqlCommand(sql3, connection))
            {

                command4.Parameters.Add("@idDentist", SqlDbType.Int).Value = _dentist.DentistID;
                using (var reader = command4.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["mrecordid"];
                        int idCus = (int)reader["CustomerID"];
                        string nameCus = (string)reader["FullName"];
                        DateTime mrDate = (DateTime)reader["MedicalRecordDate"];
                        string app = mrDate.ToString("dd-MM-yyyy");
                        string des = (string)reader["Description"];
                        var record = new MedicalRecord()
                        {
                            MRecordId = id,
                            CustomerId=idCus,
                            CustomerName=nameCus,
                            MedicalRecordDate=mrDate,
                            Description=des,
                        };

                        _medical.Add(record);
                                             
                    }
                    reader.Close();
                    Medical.ItemsSource = _medical;
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            AppointmentM tempp = _appointment[0] ;
            // Check if the cast was successful and the button is not null
            if (clickedButton != null)
            {
                
                object tagValue = clickedButton.Tag;

                if (tagValue != null)
                {
               
                    int scheduleId;
                    if (int.TryParse(tagValue.ToString(), out scheduleId))
                    {
                      
                        for(int i =0;i< _appointment.Count();i++)
                        {
                            if (_appointment[i].AppointmentId==scheduleId)
                            {
                                tempp= _appointment[i];
                            }
                        }
                      
                    }
                }
            }
            var screen = new UpdateAppointment(tempp,connectString,_dentist);
                this.Close();
                screen.Show();
            
        }

       
        private void DetailRecord(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            
            // Check if the cast was successful and the button is not null
            if (clickedButton != null)
            {

                object tagValue = clickedButton.Tag;

                if (tagValue != null)
                {

                    int mrID;
                    MedicalRecord record = _medical[0];
                   
                        
                    if (int.TryParse(tagValue.ToString(), out mrID))
                    {
                        for (int i = 0; i < _medical.Count(); i++)
                        {
                            if (_medical[i].MRecordId == mrID)
                            {
                                record = _medical[i];
                                break;
                            }
                        }
                        var sql = "select * from Customer where CustomerID = @idCus";
                        using (var command2 = new SqlCommand(sql, connection))
                        {

                            command2.Parameters.Add("@idCus", SqlDbType.Int).Value = record.CustomerId;
                            using (var reader = command2.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int idC = (int)reader["CustomerID"];
                                    string nameC = (string)reader["FullName"];
                                    DateTime birthdayC = (DateTime)reader["Birthday"];
                                    string phoneNumberC = (string)reader["PhoneNumber"];
                                    CustomerM cus = new CustomerM(idC, nameC, birthdayC, phoneNumberC);
                                    reader.Close();
                                    var screen = new DetailRecord(connection,_dentist,cus,mrID);
                                    this.Close();
                                    screen.Show();
                                }
                               
                            }
                        }


                    }
                }
            }
          
        }

        private void add_record(object sender, RoutedEventArgs e)
        {
            var screen = new AddMedicalRecord(connectString,_dentist);
            this.Close();
            screen.Show();
        }

        private void add_appointment(object sender, RoutedEventArgs e)
        {
            var screen = new AddAppointment(connectString, _dentist);
            this.Close();
            screen.Show();
        }

        private void UpdateSchedule(object sender, RoutedEventArgs e)
        {

            Button clickedButton = sender as Button;
            DentistScheduleM tempp = _scheduleDentist[0];
            // Check if the cast was successful and the button is not null
            if (clickedButton != null)
            {

                object tagValue = clickedButton.Tag;

                if (tagValue != null)
                {

                    int scheduleId;
                    if (int.TryParse(tagValue.ToString(), out scheduleId))
                    {

                        for (int i = 0; i < _scheduleDentist.Count(); i++)
                        {
                            if (_scheduleDentist[i].ScheduleId== scheduleId)
                            {
                                tempp = _scheduleDentist[i];
                            }
                        }

                    }
                }
            }
            var screen = new UpdateScheduleDentist(tempp, connectString, _dentist);
            this.Close();
            screen.Show();
        }
    }
}
