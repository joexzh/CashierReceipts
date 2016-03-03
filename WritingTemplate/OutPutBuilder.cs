using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashierReceiptsLib.Activity;

namespace WritingTemplate
{
    public class OutputBuilder
    {
        Dictionary<string, PromoteActivity> _typePromoteActivity;

        public OutputBuilder(Dictionary<string, PromoteActivity> typePromoteActivity)
        {
            _typePromoteActivity = typePromoteActivity;
        }
        public void Build()
        { //TODO
        }
    }
}
