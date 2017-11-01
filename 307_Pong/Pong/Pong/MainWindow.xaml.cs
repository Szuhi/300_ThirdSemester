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
using System.Windows.Threading;

namespace Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel VM;
        public MainWindow()
        {
            InitializeComponent();
            VM = new ViewModel();
            this.DataContext = VM;
            KeyDown += MainWindow_KeyDown;
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: VM.Slider.Move(-5, (int)(this.Content as Canvas).ActualWidth); break;
                case Key.Right: VM.Slider.Move(+5, (int)(this.Content as Canvas).ActualWidth); break;
                case Key.Space: AddBall(); break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(20);
            dt.Tick += dt_Tick;
            dt.Start();
            AddBall();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            foreach (Sphere s in VM.Balls)
            {
                if (s.Move((int)(this.Content as Canvas).ActualHeight, (int)(this.Content as Canvas).ActualWidth, VM.Slider))
                {
                    VM.Lifes--;
                    s.Init();
                }
            }
        }

        void AddBall()
        {
            Ellipse e = new Ellipse();
            Sphere s = new Sphere();

            e.DataContext = s;                  
            e.SetBinding(Canvas.LeftProperty, new Binding("Shape.X"));
            e.SetBinding(Canvas.TopProperty, new Binding("Shape.Y"));
            e.SetBinding(Ellipse.WidthProperty, new Binding("Shape.Width"));
            e.SetBinding(Ellipse.HeightProperty, new Binding("Shape.Height"));
            e.SetBinding(Ellipse.FillProperty, new Binding("Colour"));

            VM.Balls.Add(s);
            (this.Content as Canvas).Children.Add(e);
        }
    }
}
