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

namespace Labyrinth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessLogic BL;
        Stopwatch sw;

        public MainWindow()
        {
            InitializeComponent();
            BL = new BusinessLogic();
            this.DataContext = BL.VM;
            this.KeyDown += MainWindow_KeyDown;
            BL.EndOfGame += BL_EndOfGame;
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();
        }

        void BL_EndOfGame(object sender, EventArgs e)
        {
            sw.Stop();
            MessageBox.Show("Game Over!\nYour time: " + sw.ElapsedMilliseconds / 1000.0 + " s");
            BL.NextLevel();
            this.DataContext = BL.VM;
            sw.Restart();
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: BL.Move(-1, 0); break;
                case Key.Right: BL.Move(1, 0); break;
                case Key.Up: BL.Move(0, -1); break;
                case Key.Down: BL.Move(0, 1); break;
            }
        }
    }
}
