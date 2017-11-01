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

namespace NHLRoster
{
    /// <summary>
    /// Interaction logic for AddModWindow.xaml
    /// </summary>
    public partial class AddModWindow : Window
    {
        public Player NewPlayer { get; set; }
        public AddModWindow(bool mod = false)
        {
            if (mod)
                this.DataContext = ViewModel.Get().FieldSelected;
            else
            {
                NewPlayer = new Player();
                this.DataContext = NewPlayer;
            }
            InitializeComponent();
        }

        private void btn_ok(object sender, RoutedEventArgs e)
        {
            txtname.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtheight.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cmbstatus.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
            cmbposition.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
            this.DialogResult = true;
        }

        private void btn_cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void txtnev_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
                if (!char.IsLetter(c) && c != ' ')
                    e.Handled = true;
        }
    }
}
