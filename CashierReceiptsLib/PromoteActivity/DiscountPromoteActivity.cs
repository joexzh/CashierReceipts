using CashierReceiptsLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib.ConcretePromote
{
    public class DiscountPromoteActivity : PromoteActivity
    {
        public DiscountPromoteActivity(IPromoteAlgorithm promoteAlgorithm, int count, Product product) 
            : base(promoteAlgorithm, count, product)
        {
            
        }
        
    }
}
