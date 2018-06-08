using CutieShop.Models.DAOs;
using CutieShop.Models.Entities;
using CutieShop.Models.Exceptions;
using CutieShop.Models.JSONEntities.Settings;
using CutieShop.Models.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static CutieShop.Models.Extensions.StringExtension;
using static CutieShop.Models.Utils.RespBuilderUtils;
using static System.Guid;

#pragma warning disable 4014

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.ChatHandlers
{
    public partial class BuyReqHandler : ChatHandler
    {
        private readonly MailContent _mailContent;

        //There might be data validations for some steps. Remember, by jump into different step, MsgReply and other data should be also different. You may want to skip validation if you want to jump into other step to let it return its' message. 
        private bool _isSkipValidation;
        private bool _isUndoRequested => MsgQuery == "undo";

        public BuyReqHandler(Controller receiver, dynamic request, MailContent mailContent)
            : base(receiver, (object)request)
        {
            _mailContent = mailContent;
        }

        public override async Task<IActionResult> Result()
        {
            var currentStep = Storage.GetCurrentStep(MsgId);

            //Switch to next step = currentStep + 1
            switch (currentStep + 1)
            {
                #region step 1
                case 1:
                    Storage.AddOrUpdate(MsgId, 1, null);
                    using (var petTypeDAO = new PetTypeDAO())
                    {
                        var allPetTypes = (await petTypeDAO
                            .ReadAll(false))
                            .Select(x => x.Name)
                            .ToArray();

                        return Recv.Json(RespObj(RespType.QuickReplies,
                            "Bạn muốn sản phẩm cho thú cưng nào ạ?", allPetTypes));
                    }
                #endregion
                #region Step 2
                case 2:
                    //Check if answer is valid
                    if (!_isSkipValidation)
                    {
                        using (var petTypeDAO = new PetTypeDAO())
                        {
                            if (await (await petTypeDAO.ReadAll(false))
                                .Select(x => x.Name)
                                .AllAsync(x => x != MsgReply))
                            {
                                _isSkipValidation = true;
                                goto case 1;
                            }
                        }
                    }

                    Storage.AddOrUpdate(MsgId, 2, null);
                    Storage.AddOrUpdate(MsgId, 1, MsgReply);
                    return Recv.Json(RespObj(RespType.QuickReplies, "Bạn muốn mua gì cho bé ạ?",
                        new[] { "Đồ chơi", "Thức ăn", "Lồng", "phụ kiện" }));

                #endregion
                #region Step 3
                case 3:
                    //Check if answer is valid
                    // ReSharper disable once InvertIf
                    if (!_isSkipValidation)
                    {
                        if (new[] { "Đồ chơi", "Thức ăn", "Lồng", "phụ kiện" }.All(x => x != MsgReply))
                        {
                            _isSkipValidation = true;
                            goto case 2;
                        }

                        Storage.AddOrUpdateAndMoveNext(MsgId, MsgReply);
                    }

                    return Recv.Json(RespObj(RespType.QuickReplies,
                        "Bạn có thể cho mình biết mức giá bạn muốn tìm kiếm?",
                        new[] { "<100000", "100000 - 300000", ">300000 - 500000", ">500000" }));

                #endregion
                #region Step 4
                case 4:
                    //Check if answer is valid
                    if (!_isSkipValidation)
                    {
                        if (new[] {"<100000", "100000 - 300000", ">300000 - 500000", ">500000"}.All(x => x != MsgReply))
                        {
                            _isSkipValidation = true;
                            goto case 3;
                        }

                        Storage.AddOrUpdateAndMoveNext(MsgId, MsgReply);
                    }

                    //Find minimum and maximum price from step 3
                    int minimumPrice, maximumPrice;

                    switch (Storage[MsgId, 3])
                    {
                        case "<100000":
                            minimumPrice = 0;
                            maximumPrice = 99999;
                            break;
                        case "100000 - 300000":
                            minimumPrice = 100000;
                            maximumPrice = 300000;
                            break;
                        case ">300000 - 500000":
                            minimumPrice = 300001;
                            maximumPrice = 500000;
                            break;
                        default:
                            minimumPrice = 500001;
                            maximumPrice = int.MaxValue;
                            break;
                    }

                    //Find product in step 2, for pet in step 1
                    return await MessengerProductListResult(GetProductType(), minimumPrice, maximumPrice);

                #endregion
                #region Step 5
                case 5:
                    //Check if answer is valid
                    if (!_isSkipValidation)
                        using (var productDAO = new ProductDAO())
                            if (await productDAO.Read(MsgQuery, false) == null)
                            {
                                _isSkipValidation = true;
                                goto case 4;
                            }

                    Storage.AddOrUpdateAndMoveNext(MsgId, MsgQuery);

                    return Recv.Json(RespObj(RespType.Text, "Vui lòng nhập số lượng sản phẩm bạn muốn mua"));

                #endregion
                #region Step 6
                case 6:
                    if (!int.TryParse(MsgReply, out var res) || res < 1)
                        return Recv.Json(RespObj(RespType.Text,
                            "Số lượng nhập vào không hợp lệ. Vui lòng nhập lại"));

                    Storage.AddOrUpdateAndMoveNext(MsgId, MsgQuery);

                    return Recv.Json(MultiResp(RespObj(RespType.Text,
                            "Bạn có thể cho mình biết tên đăng nhập trên hệ thống Cutieshop được không ạ?\nNếu chưa có, bạn có thể gõ tên đăng nhập mới để chúng mình tạo tài khoản cho bạn"),
                        RespUndo()));

                #endregion
                #region Step 7
                case 7:
                    if (_isUndoRequested && Storage[MsgId, 6] == null)
                    {
                        Storage.StepBack(MsgId);
                        return Recv.Json(RespObj(RespType.Text, "Vui lòng nhập số lượng sản phẩm bạn muốn mua"));
                    }

                    //This step receive username first, then the email and address. So we need to keep the username to the storage for further uses, email will be used once in this step and can be queried by DAO easily in the future. 
                    //Checking null will prevent email from being overwritten to username in Storage

                    if (Storage[MsgId, 6] == null)
                    {
                        if (!MsgReply.IsPureAscii() || MsgReply.Contains(' '))
                            return Recv.Json(RespObj(RespType.Text, "Vui lòng nhập tên đăng nhập hợp lệ (không dấu, khoảng cách)"));
                        Storage.AddOrUpdate(MsgId, 6, MsgReply);
                    }

                    using (var userDAO = new UserDAO())
                    {
                        var user = await userDAO.ReadChild(Storage[MsgId, 6], true);
                        //If user is null, create a user, then ask customer their email
                        if (user == null)
                        {
                            Storage.AddOrUpdate(MsgId, 7, "userPassword", NewGuid().ToString().Substring(0, 6));
                            await userDAO.Create(new Auth
                            {
                                Username = Storage[MsgId, 6],
                                Password = Storage[MsgId, 7, "userPassword"]
                            });
                            await userDAO.CreateChild(new User
                            {
                                Username = Storage[MsgId, 6],
                                Email = string.Empty,
                                Address = string.Empty
                            });

                            await userDAO.Context.SaveChangesAsync();
                        }

                        user = await userDAO.ReadChild(Storage[MsgId, 6], true);

                        if (Storage[MsgId, 7, "fullName"] == null)
                        {
                            if (Storage[MsgId, 7, "isAskFullName"] == null)
                            {
                                Storage.AddOrUpdate(MsgId, 7, "isAskFullName", "1");
                                return Recv.Json(RespObj(RespType.Text, "Cho mình xin họ tên người nhận hàng?"));
                            }

                            if (MsgReply.Trim().Count(x => x == ' ') == 0)
                                return Recv.Json(RespObj(RespType.Text, "Vui lòng nhập đầy đủ họ tên"));

                            Storage.AddOrUpdate(MsgId, 7, "fullName", MsgReply);
                        }

                        //If email is empty, ask for email 
                        if (user.Email == string.Empty)
                        {
                            if (Storage[MsgId, 7, "isAskForEmail"] == null)
                            {
                                Storage.AddOrUpdate(MsgId, 7, "isAskForEmail", "1");
                                return Recv.Json(MultiResp(
                                    RespObj(RespType.Text, "Bạn hãy cho mình biết email nhé"), RespUndo()));
                            }

                            //Undo handling
                            if (_isUndoRequested)
                            {
                                Storage.AddOrUpdate(MsgId, 7, "fullName", null);
                                Storage.AddOrUpdate(MsgId, 7, "isAskForEmail", null);
                                return Recv.Json(RespObj(RespType.Text, "Cho mình xin họ tên người nhận hàng?"));
                            }

                            //Validate email
                            if (!MsgReply.IsEmail())
                                return Recv.Json(RespObj(RespType.Text, "Email không hợp lệ\nVui lòng nhập lại email"));

                            user.Email = MsgReply;
                            await userDAO.Context.SaveChangesAsync();
                        }

                        if (Storage[MsgId, 7, "phoneNo"] == null)
                            switch (Storage[MsgId, 7, "isAskForPhoneNo"])
                            {
                                case null:
                                    Storage.AddOrUpdate(MsgId, 7, "isAskForPhoneNo", "1");
                                    return Recv.Json(MultiResp(
                                        RespObj(RespType.Text, "Bạn cho mình xin số điện thoại ạ"), RespUndo()));
                                case "1":
                                    Storage.AddOrUpdate(MsgId, 7, "phoneNo", MsgReply);
                                    break;
                            }

                        if (_isUndoRequested)
                        {
                            user.Address = "";
                            await userDAO.Context.SaveChangesAsync();
                            Storage.AddOrUpdate(MsgId, 7, "phoneNo", null);
                            Storage.AddOrUpdate(MsgId, 7, "isAskForAddress", null);
                            return Recv.Json(RespObj(RespType.Text, "Bạn cho mình xin số điện thoại ạ"));
                        }

                        if (user.Address == string.Empty)
                        {
                            if (Storage[MsgId, 7, "isAskForAddress"] == null)
                            {
                                Storage.AddOrUpdate(MsgId, 7, "isAskForAddress", "1");
                                return Recv.Json(MultiResp(RespObj(RespType.Text, "Bạn cho mình xin địa chỉ"), RespUndo()));
                            }

                            user.Address = MsgReply;
                            await userDAO.Context.SaveChangesAsync();
                        }

                        //Ready to jump into step 8 (if exists) after this
                        Storage.AddOrUpdate(MsgId, 7, null);

                        using (var orderDAO = new OnlineOrderProductDAO(userDAO.Context))
                        {
                            var orderId = NewGuid().ToString();
                            await orderDAO.Create(orderId, Storage[MsgId, 7, "fullName"], user.Address, "10000", user.City, Storage[MsgId, 7, "phoneNo"], user.Email, user.Username, 0);
                            await orderDAO.CreateChild(Storage[MsgId, 4], orderId, int.Parse(Storage[MsgId, 5]));

                            Product buyProd;
                            using (var prdctDAO = new ProductDAO())
                                buyProd = await prdctDAO.Read(Storage[MsgId, 4], false);

                            var mailPrdctTbl = _mailContent.BuyReq.TableRow
                                .MultiReplace(("{0}", buyProd.Name), ("{1}", buyProd.Description), ("{2}", Storage[MsgId, 5]));

                            var mailBody = _mailContent.BuyReq.Body
                                .MultiReplace(("{0}", user.Username), ("{1}", mailPrdctTbl), ("{2}", orderId));

                            MailUtils.Send(user.Email, _mailContent.BuyReq.Subject, mailBody);

                            var reply = $"Mail xác nhận đã được gửi đến {user.Email}. Hãy xác nhận qua mail để hoàn tất đặt hàng nhé!";

                            //Send temporary password if customer create new account
                            if (Storage[MsgId, 7, "userPassword"] != null)
                                reply = $"Password tạm thời của bạn là {Storage[MsgId, 7, "userPassword"]}. Bạn nên vào trang chủ để thay đổi mật khẩu mặc định\n" + reply;

                            //Remove data in storage
                            Storage.RemoveId(MsgId);
                            return Recv.Json(RespObj(RespType.Text, reply));
                        }
                    }
                    #endregion
            }

            Storage.RemoveId(MsgId);
            throw new UnhandledChatException();
        }
    }
}