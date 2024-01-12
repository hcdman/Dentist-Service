using DentalService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Dentist.xaml
    /// </summary>
    public partial class Dentist : Window
    {
        SqlConnection connection;
        int Id;
        DentistM _dentist;
        BindingList<DentistScheduleM> _scheduleDentist = new BindingList<DentistScheduleM>();
        BindingList<AppointmentM> _appointment = new BindingList<AppointmentM>();
        public Dentist(string cn, DentistM dentist)
        {
            InitializeComponent();
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

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
