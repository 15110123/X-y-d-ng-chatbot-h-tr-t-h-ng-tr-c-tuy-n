using System;
using CutieShop.API.Models.DAOs;
using CutieShop.API.Models.Exceptions;
using CutieShop.API.Models.JSONEntities.FacebookRichMessages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;
using CutieShop.API.Models.Helpers;
using CutieShop.API.Models.JSONEntities.Settings;
using CutieShop.API.Models.Utils;
#pragma warning disable 4014

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.ChatHandlers
{
    internal class BuyReqHandler : ChatHandler
    {
        private readonly MailContent _mailContent;
        private bool _isSkipValidation;

        public BuyReqHandler(Controller receiver, dynamic request, MailContent mailContent)
            : base(receiver, (object)request)
        {
            _mailContent = mailContent;
        }

        public override async Task<IActionResult> Result()
        {
            var currentStep = Storage.GetCurrentStep(MsgId);

            switch (currentStep + 1)
            {
                #region step 1
                case 1:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 1, null);
                        using (var petTypeDAO = new PetTypeDAO())
                        {
                            return Receiver.Json(new
                            {
                                speech = "",
                                messages = new[]
                                {
                                    new
                                    {
                                        type = 2,
                                        platform = "facebook",
                                        title = "Bạn muốn sản phẩm cho thú cưng nào ạ?",
                                        replies = (await petTypeDAO.ReadAll())
                                            .Select(x => x.Name)
                                            .ToArray()
                                    }
                                }
                            });
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
                                if (await (await petTypeDAO.ReadAll())
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
                        return Receiver.Json(new
                        {
                            speech = "",
                            messages = new[]
                            {
                                new
                                {
                                    type = 2,
                                    platform = "facebook",
                                    title = "Bạn muốn mua gì cho bé ạ?",
                                    replies = new[] {"Đồ chơi", "Thức ăn", "Lồng", "phụ kiện"}
                                }
                            }
                        });
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
                        return Receiver.Json(new
                        {
                            speech = "",
                            messages = new[]
                            {
                                new
                                {
                                    type = 2,
                                    platform = "facebook",
                                    title = "Bạn có thể cho mình biết mức giá bạn muốn tìm kiếm?",
                                    replies = new[] {"<100000", "100000 - 300000", ">300000 - 500000", ">500000"}
                                }
                            }
                        });
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

                        switch (Storage[MsgId][3])
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
                        dynamic dao;
                        switch (Storage[MsgId][2])
                        {
                            case "Đồ chơi":
                                {
                                    dao = new ToyDAO();
                                    break;
                                }
                            case "Thức ăn":
                                {

                                    break;
                                }
                        }

                        break;
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
                                if (await productDAO.Read(MsgQuery) == null)
                                {
                                    _isSkipValidation = true;
                                    goto case 4;
                                }
                            }
                        }

                        Storage.AddOrUpdateToStorage(MsgId, 5, null);
                        Storage.AddOrUpdateToStorage(MsgId, 4, MsgQuery);
                        return Receiver.Json(new
                        {
                            speech = "Bạn có thể cho mình biết tên đăng nhập trên hệ thống Cutieshop được không ạ?\nNếu không có, bạn có thể gõ tên đăng nhập mới để chúng mình tạo tài khoản cho bạn"
                        });
                    }
                #endregion
                #region Step 6

                case 6:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 6, null);
                        Storage.AddOrUpdateToStorage(MsgId, 5, MsgReply);
                        using (var userDAO = new UserDAO())
                        {
                            var user = await userDAO.ReadChild(Storage[MsgId][5]);
                            if (user == null)
                            {
                                throw new UnhandledChatException();
                            }

                            using (var onlineOrderProductDAO = new OnlineOrderProductDAO(userDAO.Context))
                            {
                                var orderId = new GuidHelper().CreateGuid();
                                await onlineOrderProductDAO.Create(new OnlineOrder
                                {
                                    OnlineOrderId = orderId,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
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
                                    ProductId = Storage[MsgId][4],
                                    OnlineOrderId = orderId
                                });
                                MailUtils.Send(user.Email, _mailContent.BuyReq.Subject, _mailContent.BuyReq.Body);

                                Storage.RemoveId(MsgId);

                                return Receiver.Json(new
                                {
                                    speech =
                                        $"Mail xác nhận đã được gửi đến {user.Email}. Hãy xác nhận qua mail để hoàn tất đặt hàng nhé!"
                                });
                            }
                        }
                    }

                    #endregion
            }

            Storage.RemoveId(MsgId);
            throw new UnhandledChatException();
        }
    }
}
