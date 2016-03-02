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
        [TestMethod()]
        public void GetProductsTest()
        {
            var barcodes = FileOps.PromoteBarcodes;
            Assert.AreEqual(true, barcodes.Count>0);
        }

        [TestMethod()]
        public void GetPromoteBarcodesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOrderedPromoteTypesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ProductCountTest()
        {
            Assert.Fail();
        }
    }
}