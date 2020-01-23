using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTest
{
    public class ViewModelOrders
    {
        private readonly Order _order;
        private Orderline _line;

        public ViewModelOrders()
        {
            _order = new Order();
            _line = new Orderline();
        }

        public void AddLine()
        {
            _order.Lines.Add(_line.Clone());
        }


        public void Defaults()
        {
            _line.Itemcode = "";
            _line.Quantity = 1m;
            _line.Price = 1.09m;
        }

        public void ClearLines()
        {
            _order.Lines.Clear();
        }

        public Order Order
        { 
            get {return _order;}
        }

        public Orderline Line
        {
            get {  return _line; } 
        }
    }
}
