using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy
{
    internal class Order
    {
        private List<MenuItem> _items = new List<MenuItem>();

        public void addItem(MenuItem item)
        {
           this._items.Add(item);
        }

        public decimal getTotal(List<MenuItem> items)
        {
            decimal total = 0;
            foreach(MenuItem item in items)
            {
                total += item.Price;    
            }
            return total;
        }

        public IReadOnlyCollection<MenuItem> Items => this._items.AsReadOnly();
            }


    }

