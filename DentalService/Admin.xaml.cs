using System.ComponentModel;
using System.Windows;

namespace DentalService
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    
    public partial class Admin : Window, INotifyPropertyChanged
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }
        public Admin(string userName)
        {
            InitializeComponent();
            DataContext = this;
            _userName = userName;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }

        private void ManageMedicine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageServices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
             //open Register.xaml
             var screen = new RegisterAccount();
             screen.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // close this window
            var screen = new MainWindow();
            //reset username and password
            screen.UserName.Text = "";
            screen.PassWord.Password = "";
            // open MainWindow.xaml
            screen.Show();
            this.Close();
        }
    }
}