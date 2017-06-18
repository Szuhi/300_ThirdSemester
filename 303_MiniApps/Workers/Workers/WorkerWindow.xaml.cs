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

namespace Workers
{
    /// <summary>
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public Worker NewWorker { get; private set; }
        Worker d;

        public WorkerWindow(Worker d)
        {
            InitializeComponent();
            this.d = d;
            if(d != null)
            {
                txtName.Text = d.Name;
                chkSick.IsChecked = d.Sick;
                chkVacation.IsChecked = d.Vacation;
            }
        }

        public WorkerWindow() : this(null) { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (d != null)
            {
                d.Name = txtName.Text;
                d.Sick = chkSick.IsChecked.Value;
                d.Vacation = chkVacation.IsChecked.Value;
            }
            else
                NewWorker = new Worker() { Name = txtName.Text, Sick = chkSick.IsChecked.Value, Vacation = chkVacation.IsChecked.Value };

            DialogResult = true;
        }
    }
}
