using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashierReceiptsLib.Model;

namespace CashierReceiptsLib.Activity
{
    public class NoPromoteActivity : PromoteActivity
    {
        public NoPromoteActivity(IPromoteAlgorithm promoteAlgorithm, int count, Product product) : base(promoteAlgorithm, count, product)
        {
        }
    }
}
