using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NHLRoster
{
    public enum Status { Active, Injured, Banned }
    public enum Position { Center, LeftWing, RightWing, Defense, Keeper }

    public abstract class Bindable : INotifyPropertyChanged
    {
        protected void OnPropertyChange([CallerMemberName] string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ViewModel : Bindable
    {
        static ViewModel _copy;
        public static ViewModel Get()
        {
            if (_copy == null)
                _copy = new ViewModel();
            return _copy;
        }

        ViewModel()
        {
            Bench = new ObservableCollection<Player>()
            {
                new Player() { Name = "Bob", Height = 190, Position = Position.Center, Status = Status.Active},
                new Player() { Name = "Thomas", Height = 290, Position = Position.Center, Status = Status.Active},
                new Player() { Name = "Robb", Height = 110, Position = Position.LeftWing, Status = Status.Injured},
                new Player() { Name = "Clark", Height = 189, Position = Position.RightWing, Status = Status.Active},
                new Player() { Name = "Peter", Height = 179, Position = Position.RightWing, Status = Status.Active},
                new Player() { Name = "Will", Height = 1900, Position = Position.Keeper, Status = Status.Active},
                new Player() { Name = "Soldier", Height = 189, Position = Position.Defense, Status = Status.Banned},
                new Player() { Name = "Parker", Height = 165, Position = Position.Defense, Status = Status.Injured},
                new Player() { Name = "Chris", Height = 190, Position = Position.Center, Status = Status.Active},
                new Player() { Name = "Man", Height = 210, Position = Position.LeftWing, Status = Status.Active},
                new Player() { Name = "Forest", Height = 205, Position = Position.Defense, Status = Status.Active},
                new Player() { Name = "Gump", Height = 190, Position = Position.Defense, Status = Status.Active},
            };

            Field = new ObservableCollection<Player>();
        }

        public ObservableCollection<Player> Bench { get; set; }
        public ObservableCollection<Player> Field { get; set; }
        public Player BenchSelected { get; set; }
        public Player FieldSelected { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public Status Status { get; set; }
        public Position Position { get; set; }

        // Because of AddModWindow we are placing all the status and position here          -----> Enum.GetValues
        public Array AllPosition { get { return Enum.GetValues(typeof(Position)); } }
        public List<Status> AllStatus { get { return new List<Status> { Status.Active, Status.Banned, Status.Injured }; } }
    }

    public class StatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Status s = (Status)value;
            if (s == Status.Active)
                return Brushes.LightGreen;
            if (s == Status.Banned)
                return Brushes.Red;
            if (s == Status.Injured)
                return Brushes.Yellow;
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IntToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int)value;
            int m = number / 100;
            int cm = number % 100;
            return m + "m " + cm + "cm ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TwoWay chain!!!
            string s = (string)value;
            string[] st = s.Split(' ');
            int m = int.Parse(st[0].Substring(0, st[0].Length - 1));
            int cm = int.Parse(st[1].Substring(0, st[1].Length - 2));
            return 100 * m + cm;
        }
    }
}
