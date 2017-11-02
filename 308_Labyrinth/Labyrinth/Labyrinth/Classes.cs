using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Labyrinth
{
    public class BusinessLogic
    {
        int field;
        public event EventHandler EndOfGame;
        public ViewModel VM { get; set; }

        public BusinessLogic()
        {
            field = 1;
            VM = new ViewModel(field);
        }

        public void Move(int dx, int dy)
        {
            if (VM.Player.X + dx < 0 || VM.Player.X + dx >= VM.Map.GetLength(1) || VM.Player.Y + dy < 0 || VM.Player.Y + dy >= VM.Map.GetLength(0)
                || VM.Map[(int)VM.Player.Y + dy, (int)VM.Player.X + dx])
                return;

            VM.Player = new Point(VM.Player.X + dx, VM.Player.Y + dy);
            if (VM.Player == VM.Exit && EndOfGame != null)
                EndOfGame(this, EventArgs.Empty);
        }

        public void NextLevel()
        {
            field++;
            if (!(System.IO.File.Exists("L0" + field + ".lvl")))
                return;
            VM = new ViewModel(field);
        }
    }

    public class ViewModel : Bindable
    {
        public const int TILESIZE = 10;
        public bool[,] Map { get; set; }
        public Point Exit { get; set; }
        Point player;
        public Point Player { get { return player; } set { player = value; OPC(); } }
        public Brush WallBrush { get { return GetImage("_wall.bmp"); } }
        public Brush PlayerBrush { get { return GetImage("_player.bmp"); } }
        public Brush ExitBrush { get { return GetImage("_exit.bmp"); } }

        public ViewModel(int field)
        {
            string[] lines = System.IO.File.ReadAllLines("L0" + field + ".lvl");
            Map = new bool[int.Parse(lines[1]), int.Parse(lines[0])];
            for (int i = 2; i < lines.Length; i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (lines[i][j] == 'e')
                        Map[i - 2, j] = true;
                    else if (lines[i][j] == 'S')
                        Player = new Point(j, i - 2);
                    else if (lines[i][j] == 'F')
                        Exit = new Point(j, i - 2);
                }
            }
        }

        Brush GetImage(string path)
        {
            ImageBrush ib = new ImageBrush(new BitmapImage(new Uri(path, UriKind.Relative)));
            ib.TileMode = TileMode.Tile;
            ib.Viewport = new Rect(0, 0, ViewModel.TILESIZE, ViewModel.TILESIZE);
            ib.ViewportUnits = BrushMappingMode.Absolute;
            return ib;
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

    public class MapToGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool[,] m = (bool[,])value;
            GeometryGroup gg = new GeometryGroup();

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j])
                        gg.Children.Add(new RectangleGeometry(new Rect(j * ViewModel.TILESIZE, i * ViewModel.TILESIZE, ViewModel.TILESIZE, ViewModel.TILESIZE)));
                }
            }
            return gg;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PointToGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Point p = (Point)value;
            return new RectangleGeometry(new Rect(p.X * ViewModel.TILESIZE, p.Y * ViewModel.TILESIZE, ViewModel.TILESIZE, ViewModel.TILESIZE));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
