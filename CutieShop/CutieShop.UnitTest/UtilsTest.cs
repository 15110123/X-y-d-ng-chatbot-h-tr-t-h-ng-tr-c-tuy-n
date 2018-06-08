using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CutieShop.Models.Extensions.StringExtension;

namespace CutieShop.UnitTest
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void IsPureAsciiTest()
        {
            //Is true
            Assert.IsTrue("xin chao cac ban".IsPureAscii());

            //Is false
            Assert.IsFalse("xin chào".IsPureAscii());
        }
    }
}
