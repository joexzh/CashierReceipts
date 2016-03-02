using CashierReceiptsLib.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsConsole
{
    public class FileOps
    {
        static readonly string productsFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\data\products.json";
        static readonly string promoteFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\data\promote.json";
        static readonly string inputFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\data\input.json";

        static List<Product> products;
        static Dictionary<string, Tuple<List<string>, int>> promoteBarcodes;

        public static Dictionary<string, Tuple<List<string>, int>> PromoteBarcodes
        {
            get
            {
                if (promoteBarcodes == null)
                {
                    string json = File.ReadAllText(promoteFile);
                    return JsonConvert.DeserializeObject<Dictionary<string, Tuple<List<string>, int>>>(json);
                }
                return PromoteBarcodes;
            }
        }

        /// <summary>
        /// All products
        /// </summary>
        static public List<Product> Products
        {
            get
            {
                if (products == null)
                {
                    string json = File.ReadAllText(productsFile);
                    return JsonConvert.DeserializeObject<List<Product>>(json);
                }
                return products;
            }
        }


        public static IEnumerable<Product> GetProducts(Func<Product, bool> prediction)
        {
            return Products.Where(p => prediction(p));
        }

        public static Tuple<List<string>, int> GetPromoteDetails(string promoteType)
        {
            return PromoteBarcodes[promoteType];
        }

        public static List<string> GetOrderedPromoteTypes()
        {
            List<string> orderedPromoteTypes = new List<string>();
            var tempDict = new Dictionary<string, int>();

            PromoteBarcodes.ToList().ForEach(p => tempDict.Add(p.Key, p.Value.Item2));
            var orderedTemp = tempDict.OrderByDescending(t => t.Value);
            orderedTemp.ToList().ForEach(o => orderedPromoteTypes.Add(o.Key));
            return orderedPromoteTypes;
        }


        /// 从input转换获得商品, 数量
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<Product, int>> ProductCount()
        {
            var rawList = JsonConvert.DeserializeObject<List<string>>(inputFile);
            var barcodeCountDict = new Dictionary<string, int>();
            foreach (var rawItem in rawList)
            {
                var split = rawItem.Split('-');
                var barcode = rawItem.Split('-')[0];
                if (!barcodeCountDict.ContainsKey(barcode)) barcodeCountDict.Add(barcode, 0);

                if (split.Length > 1)
                {
                    int count;
                    if (int.TryParse(split[1], out count))
                    {
                        barcodeCountDict[rawItem] += count;
                    }
                }
                else
                {
                    barcodeCountDict[rawItem] += 1;
                }
            }

            var productCount = new List<Tuple<Product, int>>();
            foreach (var barcodeCount in barcodeCountDict)
            {
                productCount.Add(
                    new Tuple<Product, int>(
                        FileOps.GetProducts(x => x.Barcode == barcodeCount.Key).FirstOrDefault(),
                        barcodeCount.Value));
            }
            return productCount;
        }

    }
}
