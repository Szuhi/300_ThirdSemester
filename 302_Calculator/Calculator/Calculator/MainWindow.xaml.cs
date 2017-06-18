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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double op1;
        string op;
        bool mustDelete;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Number_Click(object sender, RoutedEventArgs e)
        {
            if(txtResult.Text == "0" || mustDelete)
            {
                txtResult.Clear();
                mustDelete = false;
            }
            txtResult.Text += (sender as Button).Content;
        }

        private void btn_Task_Click(object sender, RoutedEventArgs e)
        {
            if (op != null)
                txtResult.Text = Count().ToString();
            op1 = double.Parse(txtResult.Text);
            op = (sender as Button).Content.ToString();
            mustDelete = true;
        }

        private void btn_Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtResult.Text = Count().ToString();
            }
            catch (DivideByZeroException ex)
            { MessageBox.Show("Divided by zero: " + ex.Message); }
            catch (Exception ex)
            { MessageBox.Show("Hiba: " + ex.Message); }
        }

        double Count()
        {
            double op2 = double.Parse(txtResult.Text);

            switch(op)
            {
                case "+": return op1 + op2;
                case "-": return op1 - op2;
                case "*": return op1 * op2;
                case "/":
                    if (op2 == 0)
                        throw new DivideByZeroException("Ops!");
                    else
                        return op1 / op2;
            }

            return 0;   // Instead of default in the switch
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text != "0")
                txtResult.Text = "0";
            else
                op = null;
        }

        private void btn_Decade_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.Contains(",") == false)
                txtResult.Text += ",";
        }

        private void btn_Negation_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text[0] == '-')
                txtResult.Text = txtResult.Text.Substring(1);
            else
                txtResult.Text = "-" + txtResult.Text;
        }
    }
}
