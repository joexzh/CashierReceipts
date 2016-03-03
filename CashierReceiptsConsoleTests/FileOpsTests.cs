using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashierReceiptsConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierReceiptsConsole.Tests
{
    [TestClass()]
    public class FileOpsTests
    {
        FileOps fileOps;

        [TestInitialize]
        public void Initial()
        {
            var appPath = @"E:\Joe\git\github\CashierReceipts\CashierReceipts\data\";
            fileOps = new FileOps(appPath);
        }

        [TestMethod()]
        public void GetProductsTest()
        {

            var products = fileOps.Products;
            Assert.AreEqual(true, products.Count > 0);
        }

        [TestMethod()]
        public void GetPromoteBarcodesTest()
        {
            var barcodes = fileOps.PromoteBarcodes;
            Assert.AreEqual(true, barcodes.Count > 0);
        }

        [TestMethod()]
        public void GetOrderedPromoteTypesTest()
        {
            var orderedPromoteTypes = fileOps.GetOrderedPromoteTypes();
            Assert.AreEqual(true, orderedPromoteTypes.Count > 0);
        }

        [TestMethod()]
        public void ProductCountTest()
        {
            var productCount = fileOps.ProductCount();
            Assert.AreEqual(true, productCount.Count > 0);
        }

        [TestMethod()]
        public void GetPromoteDetailsTest_Buy2Return1()
        {
            var promoteDetails = fileOps.GetPromoteDetails("买二赠一");
            Assert.AreEqual(true, promoteDetails.Item1.Count > 0);
        }

        [TestMethod()]
        public void GetPromoteDetailsTest_95Discount()
        {
            var promoteDetails = fileOps.GetPromoteDetails("95折");
            Assert.AreEqual(true, promoteDetails.Item1.Count > 0);
        }
    }
}