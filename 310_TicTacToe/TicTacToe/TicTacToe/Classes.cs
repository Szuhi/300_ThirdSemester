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

namespace TicTacToe
{
    enum FieldType { Empty, X, O };

    class Field
    {
        public const int N = 3;
        FieldType[,] m;

        public Field()
        {
            m = new FieldType[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    m[i, j] = FieldType.Empty;
        }

        public FieldType Get(int x, int y)
        {
            return m[y, x];
        }

        public void Set(int x, int y, FieldType ft)
        {
            m[y, x] = ft;
        }
    }

    class Game : Bindable
    {
        public delegate void GameEndsEventHnadler(bool equal);
        public event GameEndsEventHnadler GameEnds;

        public FieldType Player { get; private set; }
        public Field Fields { get; private set; }

        bool end;

        public Game()
        {
            Player = FieldType.X;
            Fields = new Field();
            end = false;
        }

        public void step(int x, int y)
        {
            if (end)
                return;
            if (x >= Field.N || y >= Field.N)
                return;
            if (Fields.Get(x, y) != FieldType.Empty)
                return;
            Fields.Set(x, y, Player);
            OnPropChanged("Fields");

            if (SomeoneWon())
            {
                if (GameEnds != null)
                    GameEnds(false);
                end = true;
            }
            else if (FieldIsFull())
            {
                if (GameEnds != null)
                    GameEnds(true);
            }
            else
            {
                SwitchPlayer();
            }

        }

        void SwitchPlayer()
        {
            Player = (Player == FieldType.X) ? FieldType.O : FieldType.X;
        }

        bool SomeoneWon()
        {
            if (Fields.Get(0, 0) != FieldType.Empty && Fields.Get(0, 0) == Fields.Get(1, 0) && Fields.Get(1, 0) == Fields.Get(2, 0))
                return true;
            if (Fields.Get(0, 1) != FieldType.Empty && Fields.Get(0, 1) == Fields.Get(1, 1) && Fields.Get(1, 1) == Fields.Get(2, 1))
                return true;
            if (Fields.Get(0, 2) != FieldType.Empty && Fields.Get(0, 2) == Fields.Get(1, 2) && Fields.Get(1, 2) == Fields.Get(2, 2))
                return true;
            if (Fields.Get(0, 0) != FieldType.Empty && Fields.Get(0, 0) == Fields.Get(0, 1) && Fields.Get(0, 1) == Fields.Get(0, 2))
                return true;
            if (Fields.Get(1, 0) != FieldType.Empty && Fields.Get(1, 0) == Fields.Get(1, 1) && Fields.Get(1, 1) == Fields.Get(1, 2))
                return true;
            if (Fields.Get(2, 0) != FieldType.Empty && Fields.Get(2, 0) == Fields.Get(2, 1) && Fields.Get(2, 1) == Fields.Get(2, 2))
                return true;
            if (Fields.Get(0, 0) != FieldType.Empty && Fields.Get(0, 0) == Fields.Get(1, 1) && Fields.Get(1, 1) == Fields.Get(2, 2))
                return true;
            if (Fields.Get(2, 0) != FieldType.Empty && Fields.Get(2, 0) == Fields.Get(1, 1) && Fields.Get(1, 1) == Fields.Get(0, 2))
                return true;
            return false;
        }

        bool FieldIsFull()
        {
            for (int i = 0; i < Field.N; i++)
                for (int j = 0; j < Field.N; j++)
                    if (Fields.Get(i, j) == FieldType.Empty)
                        return false;
            return true;
        }
    }

    class ViewModel
    {
        public Game BL { get; set; }

        public ViewModel()
        {
            BL = new Game();
        }
    }

    abstract class Bindable : INotifyPropertyChanged
    {
        protected void OnPropChanged([CallerMemberName]string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class FieldToDrawingConverter : IValueConverter
    {
        const int TILE = 100;
        static string[] images = new string[] {
            @"themes\theme2\n.jpg",
            @"themes\theme2\x.jpg",
            @"themes\theme2\o.jpg"
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Field f = (Field)value;
            DrawingImage di = new DrawingImage();
            DrawingGroup dg = new DrawingGroup();
            for (int i = 0; i < Field.N; i++)
                for (int j = 0; j < Field.N; j++)
                {
                    Brush colour;
                    colour = new ImageBrush(new BitmapImage(new Uri(images[(int)f.Get(i, j)], UriKind.Relative)));
                    dg.Children.Add(new GeometryDrawing(colour, new Pen(Brushes.Black, 2), new RectangleGeometry(new Rect(i * TILE, j * TILE, TILE, TILE))));
                }
            di.Drawing = dg;
            return di;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
