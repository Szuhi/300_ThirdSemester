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

namespace NHLRoster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel VM;
        public MainWindow()
        {
            VM = ViewModel.Get();
            this.DataContext = VM;
            InitializeComponent();
        }

        private void btn_add(object sender, RoutedEventArgs e)
        {
            AddModWindow amw = new AddModWindow(); 
            if (amw.ShowDialog() == true)
            {
                VM.Bench.Add(amw.NewPlayer);
            }
        }

        private void btn_mod(object sender, RoutedEventArgs e)
        {
            if (VM.BenchSelected == null)
                return;
            (new AddModWindow(true)).ShowDialog();
        }

        private void btn_toField(object sender, RoutedEventArgs e)
        {
            if (VM.BenchSelected == null)
                return;
            if (VM.BenchSelected.Status != Status.Active)
                return;
            int[] db = new int[] { 1, 1, 1, 2, 1 };
            foreach (Player p in VM.Field)
                db[(int)p.Position]--;
            if (db[(int)VM.BenchSelected.Position] == 0)
                return;
            VM.Field.Add(VM.BenchSelected);
            VM.Bench.Remove(VM.BenchSelected);
        }

        private void btn_toBench(object sender, RoutedEventArgs e)
        {
            if (VM.BenchSelected == null)
                return;
            VM.Bench.Add(VM.FieldSelected);
            VM.Field.Remove(VM.FieldSelected);
        }
    }
}
