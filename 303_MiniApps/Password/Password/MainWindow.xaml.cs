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

namespace Password
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool pushed = false;
        string pw = "";
        Random rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += MainWindow_MouseDown;
            MouseUp += MainWindow_MouseUp;
            MouseMove += MainWindow_MouseMove;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if(pushed && e.Source is Label && !pw.Contains((e.Source as Label).Content.ToString()))
            {
                pw += (e.Source as Label).Content.ToString();
                (e.Source as Label).Background = Brushes.Yellow;
            }
            if (e.Source is Label)
                (e.Source as Label).BorderBrush = new SolidColorBrush(Color.FromRgb((byte)rng.Next(0, 256), (byte)rng.Next(0, 256), (byte)rng.Next(0, 256)));
        }

        private void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;
            pushed = false;
            MessageBox.Show("Your password: " + pw);

            pw = "";
            foreach (object o in (this.Content as Grid).Children)
                (o as Label).Background = Brushes.LightGray;
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                pushed = true;
        }
    }
}
