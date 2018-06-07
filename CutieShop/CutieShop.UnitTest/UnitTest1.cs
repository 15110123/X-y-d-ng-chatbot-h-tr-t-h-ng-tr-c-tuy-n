using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CutieShop.Models.Utils.RespBuilderUtils;
using static CutieShop.Models.Extensions.StringExtension;

namespace CutieShop.UnitTest
{
    [TestClass]
    public class ChatResponseTest
    {
        [TestMethod]
        public void MultiResponseTest()
        {
            var res = MultiResp(RespObj(RespType.Text,
                    "Bạn có thể cho mình biết tên đăng nhập trên hệ thống Cutieshop được không ạ?\nNếu chưa có, bạn có thể gõ tên đăng nhập mới để chúng mình tạo tài khoản cho bạn"),
            RespObj(RespType.Button, "Click để quay lại", btnTitle: "Quay lại", btnPayload: "undo"));
            Console.WriteLine(res);
            Assert.Fail();
        }

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
