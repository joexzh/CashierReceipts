using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib
{
    /// <summary>
    /// 打折
    /// </summary>
    public class DiscountAlgorithm : IPromoteAlgorithm
    {
        private int _discountPercent;

        public DiscountAlgorithm(int discountPercent)
        {
            _discountPercent = discountPercent;
        }

        public double GetResult(int count, double price)
        {
            return count * price * _discountPercent / 100d;
        }
    }
}
