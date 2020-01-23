using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTest
{

    public class Order : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Orderline> _lines;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Order()
        {
            _lines = new ObservableCollection<Orderline>();
            RaisePropertyChanged("Lines");
        }

        public ObservableCollection<Orderline> Lines
        {
            get            
            { 
                return _lines; 
            }
        }
    }

    public class Orderline: INotifyPropertyChanged
    {
        private string _itemcode = string.Empty;
        private decimal _quantity = 1m;
        private decimal _price = 1.09m;
        public event PropertyChangedEventHandler PropertyChanged;

        public Orderline()
        {

        }

        public Orderline( string itemcode, decimal quantity, decimal price)
        {
            Itemcode = itemcode;
            Quantity = quantity;
            Price = price;
        }

        public Orderline Clone()
        {
            return new Orderline(_itemcode, _quantity, _price);
        }

        public override string ToString()
        {
            return $"{Itemcode.PadRight(10)} - {Quantity} - {Price}";
        }

        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string Itemcode
        {
            get { return _itemcode; }
            set
            {
                if (value != _itemcode)
                {
                    _itemcode = value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string QuantityStr
        {
            get { return _quantity.ToString(); }
            set
            {
                if (value != _quantity.ToString())
                {
                    decimal temp;

                    if (Decimal.TryParse(value, out temp))
                    {
                        _quantity = temp;
                        RaisePropertyChanged();
                    }
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value != _price)
                {
                    _price = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string PriceStr
        {
            get { return _price.ToString(); }
            set
            {
                if (value != _price.ToString())
                {
                    decimal temp;

                    if (Decimal.TryParse(value, out temp))
                    {
                        _price = temp;
                        RaisePropertyChanged();
                    }
                }
            }
        }
    }
}
