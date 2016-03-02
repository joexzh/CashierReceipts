using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsLib
{
    /// <summary>
    /// 满conditionCount数量送freeCount数量
    /// </summary>
    public class ExtraAlgorithm : IPromoteAlgorithm
    {
        private int _conditionCount;
        private int _returnCount;

        public int ConditionConut { get { return _conditionCount; } }
        public int ReturnCount { get { return _returnCount; } }

        public ExtraAlgorithm(int conditionCount, int returnCount)
        {
            if (conditionCount < 1 && returnCount < 1)
                throw new ArgumentException("conditionCount and return Count must be bigger than zero");

            _conditionCount = conditionCount;
            _returnCount = returnCount;
        }

        public double GetResult(int count, double price)
        {
            return (count - (count / _conditionCount * _returnCount)) * price;
        }
    }
}
