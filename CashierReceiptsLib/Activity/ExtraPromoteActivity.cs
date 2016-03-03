using CashierReceiptsLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib.Activity
{
    public class ExtraPromoteActivity : PromoteActivity
    {
        public int ExtraCount { get; protected set; }

        public ExtraPromoteActivity(IPromoteAlgorithm promoteAlgorithm, int count, Product product)
            : base(promoteAlgorithm, count, product)
        {
            if (promoteAlgorithm.GetType() == typeof(ExtraAlgorithm))
            {
                var extraAlgorithm = promoteAlgorithm as ExtraAlgorithm;
                ExtraCount = count / extraAlgorithm.ConditionConut * extraAlgorithm.ReturnCount;
            }
        }
    }
}
