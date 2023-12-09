using ExerciseOopHierarchy.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy
{
    public class Restaurant
    {
        private List<Customer> _customers = new();
        private List<MenuItem> _menu = new();

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public MenuItem Add
    }
}
