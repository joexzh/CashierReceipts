using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib
{
    public interface IPromoteAlgorithm
    {
        double GetResult(int count, double price);
    }
}
