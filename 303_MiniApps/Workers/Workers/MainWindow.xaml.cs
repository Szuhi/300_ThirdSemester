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

namespace Workers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Worker d1 = new Worker();
            d1.Name = "Small Steve";
            d1.Vacation = true;
            lstWorkers.Items.Add(d1);

            Worker d2 = new Worker() { Name = "Big Ben", Sick = true };
            lstWorkers.Items.Add(d2);

            lstWorkers.Items.Add(new Worker() { Name = "Black Bob" });
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {
            WorkerWindow ww = new WorkerWindow();
            if (ww.ShowDialog() == true)
                lstWorkers.Items.Add(ww.NewWorker);
        }

        private void btn_Remove(object sender, RoutedEventArgs e)
        {
            lstWorkers.Items.Remove(lstWorkers.SelectedItem);
        }

        private void btn_Modify(object sender, RoutedEventArgs e)
        {
            if (lstWorkers.SelectedItem == null)
                return;
            WorkerWindow ww = new WorkerWindow(lstWorkers.SelectedItem as Worker);
            if (ww.ShowDialog() == true)
                lstWorkers.Items.Refresh();
        }

        private void btn_RemoveAll(object sender, RoutedEventArgs e)
        {
            lstWorkers.Items.Clear();
        }
    }
}
