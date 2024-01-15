using System;
using System.Collections.Generic;
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
    /// Interaction logic for InputQuantiTyDialog.xaml
    /// </summary>
    public partial class InputQuantiTyDialog : Window
    {
        public string Answer { get; set; }
        public string MedicineName { get; set; }

        public InputQuantiTyDialog(string medicineName)
        {
            InitializeComponent();
            MedicineName = medicineName;
            Title = "Nhập số lượng thuốc " + MedicineName;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Answer = QuantityTextBox.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
