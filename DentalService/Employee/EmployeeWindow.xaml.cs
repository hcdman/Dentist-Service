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

namespace DentalService.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        SqlConnection connection = new SqlConnection();
        string connectString;
        EmployeeM _emp;
        BindingList<AppointmentM> _appointment = new BindingList<AppointmentM>();

        public EmployeeWindow(string connect, EmployeeM emp)
        {
            connectString = connect;
            _emp = emp;
            connection = new SqlConnection(connect);
            connection.Open();
            this.DataContext = emp;
            InitializeComponent();
            //get data of appoint ment
            var sql2 = "select * from Appointment";
            using (var command3 = new SqlCommand(sql2, connection))
            {              
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
                        AppointmentM temp = new AppointmentM(idAP, app, startTimeString, endTimeString, idDentist, idCus, createby, status);
                        _appointment.Add(temp);
                    }
                    CustomerAppoitment.ItemsSource = _appointment;
                }
            }
        }


        private void CreateAppointment_Click(object sender, RoutedEventArgs e) {
            var screen = new CreateAppointment();
            screen.ShowDialog();
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e) {
            var screen = new EditAppointment();
            screen.ShowDialog();
        }

        private void InvoiceButton_Click(object sender, RoutedEventArgs e) {
            var screen = new Invoice();
            screen.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e) {

        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            AppointmentM tempp = _appointment[0];
            // Check if the cast was successful and the button is not null
            if (clickedButton != null)
            {

                object tagValue = clickedButton.Tag;

                if (tagValue != null)
                {

                    int scheduleId;
                    if (int.TryParse(tagValue.ToString(), out scheduleId))
                    {

                        for (int i = 0; i < _appointment.Count(); i++)
                        {
                            if (_appointment[i].AppointmentId == scheduleId)
                            {
                                tempp = _appointment[i];
                            }
                        }

                    }
                }
            }
            var screen = new UpdateAppE(tempp, connection, _emp);
            this.Close();
            screen.Show();
        }
    }
}
