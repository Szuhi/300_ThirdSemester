using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel VM;
        Stopwatch sw;

        public MainWindow()
        {
            InitializeComponent();
            VM = new ViewModel();
            DataContext = VM;
            VM.BL.GameEnds += BL_GameEnds;
        }

        void BL_GameEnds(bool equal)
        {
            sw.Stop();
            MessageBox.Show("The game ends!\n" + (equal ? "Draw!." : "Winner: " + VM.BL.Player) + "\nTime: " + (double)sw.ElapsedMilliseconds / 1000 + " mp");
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition((Image)this.Content);
            int w_3 = (int)(((Image)this.Content).ActualWidth / 3);
            int h_3 = (int)(((Image)this.Content).ActualHeight / 3);
            VM.BL.step((int)p.X / w_3, (int)p.Y / h_3);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();
        }
    }
}
