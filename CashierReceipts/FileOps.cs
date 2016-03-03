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
        private readonly string productsFile;
        private readonly string promoteFile;
        private readonly string inputFile;

        private List<Product> products;
        private Dictionary<string, Tuple<List<string>, int>> promoteBarcodes;

        public Dictionary<string, Tuple<List<string>, int>> PromoteBarcodes
        {
            get
            {
                if (promoteBarcodes == null)
                {
                    string json = File.ReadAllText(promoteFile);
                    promoteBarcodes =  JsonConvert.DeserializeObject<Dictionary<string, Tuple<List<string>, int>>>(json);
                }
                return promoteBarcodes;
            }
        }

        /// <summary>
        /// All products
        /// </summary>
        public List<Product> Products
        {
            get
            {
                if (products == null)
                {
                    string json = File.ReadAllText(productsFile);
                    products = JsonConvert.DeserializeObject<List<Product>>(json);
                }
                return products;
            }
        }

        public FileOps(string fileFolder)
        {
            productsFile = Path.Combine(fileFolder, "products.json");
            promoteFile = Path.Combine(fileFolder, "promote.json");
            inputFile = Path.Combine(fileFolder, "input.json");
        }


        public IEnumerable<Product> GetProducts(Func<Product, bool> prediction)
        {
            return Products.Where(p => prediction(p));
        }

        public Tuple<List<string>, int> GetPromoteDetails(string promoteType)
        {
            return PromoteBarcodes[promoteType];
        }

        public List<string> GetOrderedPromoteTypes()
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
        public List<Tuple<Product, int>> ProductCount()
        {
            var rawList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(inputFile));
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
                        barcodeCountDict[barcode] += count;
                    }
                }
                else
                {
                    barcodeCountDict[barcode] += 1;
                }
            }

            var productCount = new List<Tuple<Product, int>>();
            foreach (var barcodeCount in barcodeCountDict)
            {
                productCount.Add(
                    new Tuple<Product, int>(
                        GetProducts(x => x.Barcode == barcodeCount.Key).FirstOrDefault(),
                        barcodeCount.Value));
            }
            return productCount;
        }

    }
}
