using CashierReceiptsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashierReceiptsLib.Activity;
using WritingTemplate;

namespace CashierReceiptsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Tuple<IPromoteAlgorithm, Type>> typeMapping = new Dictionary<string, Tuple<IPromoteAlgorithm, Type>>
            {
                { "买二赠一" , new Tuple<IPromoteAlgorithm, Type>(new ExtraAlgorithm(2, 1), typeof(ExtraPromoteActivity)) },
                { "95折", new Tuple<IPromoteAlgorithm, Type>(new DiscountAlgorithm(95), typeof(DiscountPromoteActivity)) },
                { "正常价格", new Tuple<IPromoteAlgorithm, Type>(null, typeof(NoPromoteActivity))}
             };

            var fileOps = new FileOps(AppDomain.CurrentDomain.BaseDirectory);
            var productCounts = fileOps.ProductCount();
            var promoteTypeOrdered = fileOps.GetOrderedPromoteTypes();
            Dictionary<string, PromoteActivity> typePromoteActivity = new Dictionary<string, PromoteActivity>();

            foreach (var productCount in productCounts)
            {
                promoteTypeOrdered.ForEach(t =>
                {
                    var promoteDetails = fileOps.GetPromoteDetails(t);
                    foreach (var barcode in promoteDetails.Item1)
                    {
                        if (productCount.Item1.Barcode == barcode)
                        {
                            var promoteActivityInstance = (PromoteActivity)Activator.CreateInstance(
                                typeMapping[t].Item2,
                                productCount.Item2,
                                typeMapping[t].Item1);
                            typePromoteActivity.Add(t, promoteActivityInstance);
                            break;
                        }
                    }
                });
            }

            var builder = new OutputBuilder(typePromoteActivity);
            builder.Build();

            Console.ReadLine();

        }


    }
}
