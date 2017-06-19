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

namespace MusicList
{
    /// <summary>
    /// Interaction logic for PlayListWindow.xaml
    /// </summary>
    public partial class PlayListWindow : Window
    {
        public PlayListWindow()
        {
            InitializeComponent();

            PlayList ll = ViewModel.Get().Selected;
            this.Title = ll.Name;
            this.DataContext = ll;
        }
    }
}
