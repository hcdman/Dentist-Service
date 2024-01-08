using DentalService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DentalService.Employee;

/// <summary>
/// Interaction logic for InvoicePage.xaml
/// </summary>
public partial class Invoice : Window
{
    public Invoice()
    {
        InitializeComponent();
        ServiceDataGrid.ItemsSource = ServiceList;
        MedicineDataGrid.ItemsSource = MedicineList;
        ExaminationFeeTextBlock.Text = ExaminationFee.ToString();
        TotalPaymentTextBlock.Text = TotalPayment.ToString();


    }

    public ObservableCollection<DentalServiceM> ServiceList = new() {
        new DentalServiceM() {ServiceName = "Gold Teeth", SoldQuantity= 3, Price=100},

        new DentalServiceM() {ServiceName = "Diamond Teeth", SoldQuantity= 3, Price=1000},
    };

    public ObservableCollection<MedicineM> MedicineList = new() {
        //dummy data
        new MedicineM() { MedicineName="Pharadol", Price=50, SoldQuantity=3},
        new MedicineM() { MedicineName="RGB", Price=70, SoldQuantity=2},
    };

    //public int ServicePayment {
    //    get => {
    //        int total = 0;
    //        foreach(var ser in ServiceList) {
    //            total += ser.
    //        }
    //    }
    //}
    public int ExaminationFee = 100;

    public int TotalPayment = 10000;
}


