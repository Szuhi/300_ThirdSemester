using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Pong
{
    public class ViewModel : Bindable
    {
        public ViewModel()
        {
            Balls = new List<Sphere>();
            Slider = new Bat();
            Lifes = 5;
        }

        int lifes;
        public List<Sphere> Balls { get; set; }
        public Bat Slider { get; set; }
        public int Lifes { get { return lifes; } set { lifes = value; OPC(); } }
    }

    public class Sphere : Bindable
    {
        static Random rnd = new Random();
        int dx, dy;
        public Sphere()
        {
            dx = 3; dy = 2;
            Init();
        }

        Rect shape;
        public Rect Shape { get { return shape; } set { shape = value; OPC(); } }
        public Brush Colour { get; set; }

        public bool Move(int ch, int cw, Bat u)
        {
            Shape = new Rect(Shape.X + dx, Shape.Y + dy, Shape.Height, Shape.Width);
            if (Shape.Top <= 0 || Shape.IntersectsWith(u.Shape))
                dy = -dy;
            if (Shape.Left <= 0 || Shape.Right >= cw)
                dx = -dx;
            if (Shape.Top >= ch)                                      
                return true;
            return false;
        }

        public void Init()
        {
            Shape = new Rect(100, 100, 40, 40);
            Colour = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256)));
        }
    }

    public class Bat : Bindable
    {
        public Bat()
        {
            Shape = new Rect(300, 300, 100, 10);
        }

        Rect shape;
        public Rect Shape { get { return shape; } set { shape = value; OPC(); } }

        public void Move(int dx, int cw)
        {
            if (Shape.Left + dx >= 0 && Shape.Right + dx <= cw)
                Shape = new Rect(dx + Shape.X, Shape.Y, Shape.Width, Shape.Height);
        }
    }

    public abstract class Bindable : INotifyPropertyChanged
    {
        protected void OPC([CallerMemberName] string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
