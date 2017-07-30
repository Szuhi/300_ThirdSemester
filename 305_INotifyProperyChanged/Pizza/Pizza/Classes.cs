using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class ViewModel : Bindable
    {
        public List<PizzaItem> Items { get; set; }
        public BindingList<PizzaItem> Extras { get; set; }
        PizzaItem selectedItem;
        public PizzaItem SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged("FullPrice"); }
        }
        public int FullPrice
        {
            get
            {
                int sum = 0;
                sum += (SelectedItem != null) ? SelectedItem.Price : 0;
                foreach (PizzaItem e in Extras)
                    if (e.Prop)
                        sum += e.Price;
                return sum;
            }
        }

        public ViewModel()
        {
            Items = new List<PizzaItem>()
            {
                new PizzaItem() { Name="25 cm", Price=800},
                new PizzaItem() { Name="32 cm", Price=1100},
                new PizzaItem() { Name="Giant (45 cm)", Price=1500},
            };
            Extras = new BindingList<PizzaItem>()
            {
                new PizzaItem() { Name="Cheese", Price=100},
                new PizzaItem() { Name="Ham", Price=250},
                new PizzaItem() { Name="Pepper", Price=50},
                new PizzaItem() { Name="Onion", Price=120},
                new PizzaItem() { Name="Tomato", Price=180},
            };

            Extras.ListChanged += Extras_ListChanged;
        }

        private void Extras_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged("FullPrice");
        }
    }

    public class PizzaItem : Bindable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        bool prop;
        public bool Prop
        {
            get { return prop; }
            set { prop = value; OnPropertyChanged(); }
        }
    }

    public abstract class Bindable: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
    }
}
