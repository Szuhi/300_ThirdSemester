using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace FlappyBird
{
    public class Game : FrameworkElement
    {
        Bird player;
        List<Wall> walls;
        int point;

        public Game()
        {
            Loaded += Game_Loaded;
        }

        void Game_Loaded(object sender, RoutedEventArgs e)
        {
            player = new Bird();
            walls = new List<Wall>();
            int disp = (int)(ActualWidth / 3);
            for (int i = 1; i <= 3; i++)
                walls.Add(new Wall(i * disp, ActualHeight));
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(20);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        void Dt_Tick(object sender, EventArgs e)
        {
            player.Move(ActualHeight);
            foreach (Wall o in walls)
            {
                o.Move(ActualWidth, ActualHeight);
                if (player.Collide(o))
                    point++;
            }
            InvalidateVisual();
        }

        public void Jump()
        {
            player.Jump();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (player != null)
                drawingContext.DrawGeometry(Brushes.Orange, new Pen(Brushes.Red, 2), player.Shape);
            if (walls != null)
                foreach (Wall o in walls)
                    drawingContext.DrawGeometry(Brushes.Green, new Pen(Brushes.Black, 2), o.Shape);
            FormattedText ft = new FormattedText("Points: " + point, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, new Typeface("Tahoma"), 12, Brushes.Black);
            drawingContext.DrawGeometry(Brushes.Black, null, ft.BuildGeometry(new Point(10, 10)));
        }
    }

    public abstract class GameElement
    {
        protected Geometry shape;
        protected Point kp;
        protected double angle;

        public Geometry Shape
        {
            get
            {
                TransformGroup tg = new TransformGroup();
                tg.Children.Add(new TranslateTransform(kp.X, kp.Y));
                tg.Children.Add(new RotateTransform(angle, kp.X, kp.Y));
                shape.Transform = tg;
                return shape;
            }
        }

        public bool Collide(GameElement ge)
        {
            return Geometry.Combine(Shape.GetFlattenedPathGeometry(), ge.Shape.GetFlattenedPathGeometry(), GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }

    public class Bird : GameElement
    {
        public const int R = 20;
        int dy;

        public Bird()
        {
            EllipseGeometry eg = new EllipseGeometry(new Point(0, 0), 20, 20);
            PathGeometry pg = new PathGeometry();
            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(10, 10);
            pf.Segments.Add(new LineSegment(new Point(30, 0), false));
            pf.Segments.Add(new LineSegment(new Point(10, -10), false));
            pg.Figures.Add(pf);
            shape = Geometry.Combine(eg, pg, GeometryCombineMode.Union, null);
            kp = new Point(50, 50);
        }

        public void Move(double ah)
        {
            kp = new Point(kp.X, kp.Y + dy);
            dy++;
            if (kp.Y + R >= ah)
            {
                kp.Y = ah - R;
                dy = 0;
            }
            angle = Math.Atan2(dy, R / 4) * 180.0 / Math.PI;
        }

        public void Jump()
        {
            dy -= 10;
        }
    }

    public class Wall : GameElement
    {
        static Random rnd = new Random();
        public Wall(int x, double ah)
        {
            Init(x, ah);
        }

        void Init(int x, double ah)
        {
            kp = new Point(x, rnd.Next(3 * Bird.R, (int)ah - 3 * Bird.R));
            RectangleGeometry rg1 = new RectangleGeometry(new Rect(-Bird.R, -kp.Y, 2 * Bird.R, kp.Y - 3 * Bird.R));
            RectangleGeometry rg2 = new RectangleGeometry(new Rect(-Bird.R, 3 * Bird.R, 2 * Bird.R, ah - kp.Y - 3 * Bird.R));
            shape = Geometry.Combine(rg1, rg2, GeometryCombineMode.Union, null);
        }

        public void Move(double aw, double ah)
        {
            kp.X--;
            if (kp.X + Bird.R < 0)
                Init((int)aw + Bird.R, ah);
        }
    }
}
