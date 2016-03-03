using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib.Model
{
    public class Product
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public string Unit { get; protected set; }
        public string Barcode { get; protected set; }

        public Product(string name, double price, string unit)
        {
            Name = name;
            Price = price;
            Unit = unit;
        }

        public Product()
        {

        }
    }
}
