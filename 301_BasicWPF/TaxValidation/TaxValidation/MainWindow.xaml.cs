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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaxValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string Validation()
        {
            double b = double.Parse(paid.Text);
            double a = double.Parse(tax.Text);
            double j = double.Parse(income.Text);

            double temp = j * a / 100;

            if (temp == b)
                return "OK!";
            if (temp > b)
                return "Underpaid";
            return "Overpaid!";
        }

        private void paid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sum != null)
                sum.Content = Validation();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Validation());
        }
    }
}
