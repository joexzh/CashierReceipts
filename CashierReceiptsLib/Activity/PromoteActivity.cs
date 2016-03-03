using CashierReceiptsLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib.Activity
{
    public abstract class PromoteActivity
    {
        public int Count { get; protected set; }
        public Product Product { get; protected set; }
        public double TotalPrice { get; protected set; }
        public double PromotePrice { get; protected set; }
        protected IPromoteAlgorithm PromoteAlgorithm { get; set; }
        public double Saved { get; protected set; }

        public PromoteActivity(IPromoteAlgorithm promoteAlgorithm, int count, Product product)
        {
            PromoteAlgorithm = promoteAlgorithm;
            Count = count;
            Product = product;

            TotalPrice = count * product.Price;
            PromotePrice = PromoteAlgorithm == null ? TotalPrice : PromoteAlgorithm.GetResult(count, product.Price);
            Saved = TotalPrice - PromotePrice;
        }
    }
}
