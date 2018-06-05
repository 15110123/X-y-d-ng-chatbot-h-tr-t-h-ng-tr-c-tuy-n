using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutieShop.Models.DAOs;
using CutieShop.Models.Entities;
using CutieShop.Models.Exceptions;
using CutieShop.Models.Helpers;
using CutieShop.Models.JSONEntities.Settings;
using CutieShop.Models.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CutieShop.Models.Utils.RespBuilderUtils;
using static CutieShop.Models.Utils.TextUtils;

#pragma warning disable 4014

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.ChatHandlers
{
    public class BuyReqHandler : ChatHandler
    {
        private readonly MailContent _mailContent;

        //There might be data validations for some steps. Remember, by jump into different step, MsgReply and other data should be also different. You may want to skip validation if you want to jump into other step to let it return its' message. 
        private bool _isSkipValidation;

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
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 1, null);
                        using (var petTypeDAO = new PetTypeDAO())
                        {
                            var allPetTypes = (await petTypeDAO
                                .ReadAll(false))
                                .Select(x => x.Name)
                                .ToArray();

                            return Receiver.Json(RespObject(RespType.QuickReplies,
                                "Bạn muốn sản phẩm cho thú cưng nào ạ?", allPetTypes));
                        }
                    }
                #endregion
                #region Step 2
                case 2:
                    {
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

                        Storage.AddOrUpdateToStorage(MsgId, 2, null);
                        Storage.AddOrUpdateToStorage(MsgId, 1, MsgReply);
                        return Receiver.Json(RespObject(RespType.QuickReplies, "Bạn muốn mua gì cho bé ạ?",
                            new[] { "Đồ chơi", "Thức ăn", "Lồng", "phụ kiện" }));
                    }
                #endregion
                #region Step 3
                case 3:
                    {
                        //Check if answer is valid
                        if (!_isSkipValidation)
                        {
                            if (new[] { "Đồ chơi", "Thức ăn", "Lồng", "phụ kiện" }.All(x => x != MsgReply))
                            {
                                _isSkipValidation = true;
                                goto case 2;
                            }
                        }

                        Storage.AddOrUpdateToStorage(MsgId, 3, null);
                        Storage.AddOrUpdateToStorage(MsgId, 2, MsgReply);

                        return Receiver.Json(RespObject(RespType.QuickReplies,
                            "Bạn có thể cho mình biết mức giá bạn muốn tìm kiếm?",
                            new[] { "<100000", "100000 - 300000", ">300000 - 500000", ">500000" }));
                    }
                #endregion
                #region Step 4

                case 4:
                    {
                        //Check if answer is valid
                        if (!_isSkipValidation)
                        {
                            if (new[] { "<100000", "100000 - 300000", ">300000 - 500000", ">500000" }.All(x =>
                                  x != MsgReply))
                            {
                                _isSkipValidation = true;
                                goto case 3;
                            }
                        }

                        Storage.AddOrUpdateToStorage(MsgId, 4, null);
                        Storage.AddOrUpdateToStorage(MsgId, 3, MsgReply);

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
                    }
                #endregion
                #region Step 5

                case 5:
                    {
                        //Check if answer is valid
                        if (!_isSkipValidation)
                        {
                            using (var productDAO = new ProductDAO())
                            {
                                if (await productDAO.Read(MsgQuery, false) == null)
                                {
                                    _isSkipValidation = true;
                                    goto case 4;
                                }
                            }
                        }

                        Storage.AddOrUpdateToStorage(MsgId, 5, null);
                        Storage.AddOrUpdateToStorage(MsgId, 4, MsgQuery);

                        return Receiver.Json(RespObject(RespType.Text, "Vui lòng nhập số lượng sản phẩm bạn muốn mua"));
                    }
                #endregion
                #region Step 6
                case 6:
                    {
                        if (!int.TryParse(MsgReply, out var res) || res < 1)
                        {
                            return Receiver.Json(RespObject(RespType.Text, "Số lượng nhập vào không hợp lệ. Vui lòng nhập lại"));
                        }
                        Storage.AddOrUpdateToStorage(MsgId, 6, null);
                        Storage.AddOrUpdateToStorage(MsgId, 5, MsgQuery);

                        return Receiver.Json(MultiResp(RespObject(RespType.Text,
                            "Bạn có thể cho mình biết tên đăng nhập trên hệ thống Cutieshop được không ạ?\nNếu chưa có, bạn có thể gõ tên đăng nhập mới để chúng mình tạo tài khoản cho bạn"), RespUndo()));
                    }
                #endregion
                #region Step 7

                case 7:
                    {
                        if (IsUndoRequested() && Storage[MsgId, 6] == null)
                        {
                            Storage.StepBack(MsgId);
                            return Receiver.Json(RespObject(RespType.Text, "Vui lòng nhập số lượng sản phẩm bạn muốn mua"));
                        }

                        //This step receive username first, then the email and address. So we need to keep the username to the storage for further uses, email will be used once in this step and can be queried by DAO easily in the future. 
                        //Checking null will prevent email from being overwritten to username in Storage

                        if (Storage[MsgId, 6] == null)
                        {
                            if (!IsPureAscii(MsgReply) || MsgReply.Contains(' '))
                                return Receiver.Json(RespObject(RespType.Text, "Vui lòng nhập tên đăng nhập hợp lệ (không dấu, khoảng cách)"));

                            Storage.AddOrUpdateToStorage(MsgId, 6, MsgReply);
                        }

                        using (var userDAO = new UserDAO())
                        {
                            var user = await userDAO.ReadChild(Storage[MsgId, 6], true);
                            //If user is null, create a user, then ask customer their email
                            if (user == null)
                            {
                                Storage.AddOrUpdateToStorage(MsgId, 7, "userPassword", new GuidHelper().CreateGuid().Substring(0, 6));
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
                                    Storage.AddOrUpdateToStorage(MsgId, 7, "isAskFullName", "1");

                                    return Receiver.Json(RespObject(RespType.Text, "Cho mình xin họ tên người nhận hàng?"));
                                }

                                if (MsgReply.Count(x => x == ' ') == 0)
                                {
                                    return Receiver.Json(RespObject(RespType.Text, "Vui lòng nhập đầy đủ họ tên"));
                                }

                                Storage.AddOrUpdateToStorage(MsgId, 7, "fullName", MsgReply);
                            }

                            //If email is empty, ask for email 
                            if (user.Email == string.Empty)
                            {
                                if (Storage[MsgId, 7, "isAskForEmail"] == null)
                                {
                                    Storage.AddOrUpdateToStorage(MsgId, 7, "isAskForEmail", "1");
                                    return Receiver.Json(MultiResp(RespObject(RespType.Text, "Bạn hãy cho mình biết email nhé"), RespUndo()));
                                }

                                //Undo handling
                                if (IsUndoRequested())
                                {
                                    Storage.AddOrUpdateToStorage(MsgId, 7, "fullName", null);
                                    Storage.AddOrUpdateToStorage(MsgId, 7, "isAskForEmail", null);
                                    return Receiver.Json(RespObject(RespType.Text, "Cho mình xin họ tên người nhận hàng?"));
                                }

                                //Validate email
                                var atInd = MsgReply.IndexOf("@", StringComparison.OrdinalIgnoreCase);
                                if (atInd < 1 || atInd == MsgReply.Length - 1)
                                {
                                    return Receiver.Json(RespObject(RespType.Text, "Email không hợp lệ\nVui lòng nhập lại email"));
                                }

                                user.Email = MsgReply;
                                await userDAO.Context.SaveChangesAsync();
                            }

                            //If address is empty but email is not, MsgReply must be address
                            if (user.Address == string.Empty)
                            {
                                if (Storage[MsgId, 7, "isAskForAddress"] == null)
                                {
                                    Storage.AddOrUpdateToStorage(MsgId, 7, "isAskForAddress", "1");
                                    return Receiver.Json(RespObject(RespType.Text, "Bạn cho mình xin địa chỉ"));
                                }

                                user.Address = MsgReply;
                                await userDAO.Context.SaveChangesAsync();
                            }

                            //Ready to jump into step 8 (if exists) after this
                            Storage.AddOrUpdateToStorage(MsgId, 7, null);

                            using (var onlineOrderProductDAO = new OnlineOrderProductDAO(userDAO.Context))
                            {
                                var orderId = new GuidHelper().CreateGuid();
                                await onlineOrderProductDAO.Create(new OnlineOrder
                                {
                                    OnlineOrderId = orderId,
                                    FirstName = Storage[MsgId, 7, "fullName"].Substring(0, Storage[MsgId, 7, "fullName"].IndexOf(' ')),
                                    LastName = Storage[MsgId, 7, "fullName"].Substring(Storage[MsgId, 7, "fullName"].IndexOf(' ') + 1),
                                    Address = user.Address,
                                    PostCode = "10000",
                                    City = user.City,
                                    PhoneNo = "12345678",
                                    Email = user.Email,
                                    Date = DateTime.Now,
                                    Username = user.Username,
                                    StatusId = 0
                                });
                                await onlineOrderProductDAO.CreateChild(new OnlineOrderProduct
                                {
                                    ProductId = Storage[MsgId, 4],
                                    OnlineOrderId = orderId,
                                    Quantity = int.Parse(Storage[MsgId, 5])
                                });

                                Product buyProduct;
                                using (var productDAO = new ProductDAO())
                                {
                                    buyProduct = await productDAO.Read(Storage[MsgId, 4], false);
                                }
                                var mailProductTable = _mailContent.BuyReq.TableRow.
                                    Replace("{0}", buyProduct.Name)
                                    .Replace("{1}", buyProduct.Description)
                                    .Replace("{2}", Storage[MsgId, 5]);

                                var mailBody = _mailContent.BuyReq.Body
                                    .Replace("{0}", user.Username)
                                    .Replace("{1}", mailProductTable)
                                    .Replace("{2}", "https://cutieshop.azurewebsites.net/api/onlineorder/verify/" + orderId);

                                MailUtils.Send(user.Email, _mailContent.BuyReq.Subject, mailBody);

                                var reply =
                                    $"Mail xác nhận đã được gửi đến {user.Email}. Hãy xác nhận qua mail để hoàn tất đặt hàng nhé!";

                                //Send temporary password if customer create new account
                                if (Storage[MsgId, 7, "userPassword"] != null)
                                {
                                    reply = $"Password tạm thời của bạn là {Storage[MsgId, 7, "userPassword"]}. Bạn nên vào trang chủ để thay đổi mật khẩu mặc định\n" + reply;
                                }

                                //Remove data in storage
                                Storage.RemoveId(MsgId);

                                return Receiver.Json(RespObject(RespType.Text, reply));
                            }
                        }
                    }

                    #endregion
            }

            Storage.RemoveId(MsgId);
            throw new UnhandledChatException();
        }

        private async Task<IActionResult> MessengerProductListResult(Type childType, int minPrice, int maxPrice)
        {
            var msgs = (await new CutieshopContext().Product
                .Include(x => x.ProductForPetType)
                .ThenInclude(x => x.PetType)
                .Include(x => x.Accessory)
                .Include(x => x.Cage)
                .Include(x => x.Food)
                .Include(x => x.Toy)
                .ToArrayAsync())
                .Where(x => ProductEqualTypeNotNull(x, childType)
                && x.Price >= minPrice
                && x.Price <= maxPrice
                && x.ProductForPetType.Any(y => y.PetType.Name == Storage[MsgId, 1]))
                .Select(x => new { x.Name, Price = x.Price.ToString(), x.ProductId, x.ImgUrl, BtnText = "Đặt liền" })
                .Select(ele => (ele.Name, ele.Price, ele.ProductId, ele.ImgUrl, ele.BtnText))
                .ToArray();

            //Return message
            if (msgs.Any())
                return Receiver.Json(RespObject(RespType.Cards, "", cards: msgs));

            //Require user to choose another price
            //Storage.RemoveId(MsgId);
            Storage.StepBack(MsgId);
            return Receiver.Json(RespObject(RespType.QuickReplies,
                "Xin lỗi bạn. Chúng mình tạm thời không còn bán loại hàng này. Bạn vui lòng chọn mức giá khác",
                new[] {"<100000", "100000 - 300000", ">300000 - 500000", ">500000"}));
        }

        private Type GetProductType()
        {
            switch (Storage[MsgId, 2])
            {
                case "Đồ chơi":
                    {
                        return typeof(Toy);
                    }
                case "Thức ăn":
                    {
                        return typeof(Food);
                    }
                case "Lồng":
                    {
                        return typeof(Cage);
                    }
                case "phụ kiện":
                    {
                        return typeof(Accessory);
                    }
                default:
                    {
                        throw new UnhandledChatException();
                    }
            }
        }

        private bool ProductEqualTypeNotNull(Product o, Type t)
        {
            if (t == typeof(Toy) && o.Toy != null
                || t == typeof(Food) && o.Food != null
                || t == typeof(Cage) && o.Cage != null)
                return true;
            return t == typeof(Accessory) && o.Accessory != null;
        }

        private object RespUndo()
        {
            return RespObject(RespType.Button, "Click để quay lại", btnTitle: "Quay lại", btnPayload: "undo");
        }

        private bool IsUndoRequested()
        {
            return MsgQuery == "undo";

        }
    }
}
