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

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.ChatHandlers
{
    internal class BuyReqHandler : ChatHandler
    {
        private readonly MailContent _mailContent;

        public BuyReqHandler(Controller receiver, dynamic request, MailContent mailContent)
            : base(receiver, (object)request)
        {
            _mailContent = mailContent;
        }

        public override async Task<IActionResult> Result()
        {
            switch ((int)Request.result.contexts[0].lifespan)
            {
                #region step 6
                case 6:
                    {
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
                #region Step 5
                case 5:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 5, MsgReply);
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
                #region Step 4
                case 4:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 4, MsgReply);
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
                #region Step 3

                case 3:
                    {
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

                        //Find product in step 4, for pet in step 5

                        switch (Storage[MsgId][4])
                        {
                            case "Đồ chơi":
                                {
                                    using (var toyDAO = new ToyDAO())
                                    {
                                        var messages = (await toyDAO.ReadAllChild())
                                        .Include(x => x.Product)
                                        .Include(x => x.Product.ProductForPetType)
                                        .Where(x => x.Product.Price >= minimumPrice
                                        && x.Product.Price <= maximumPrice
                                        && x.Product.ProductForPetType.Any(y => y.PetType.Name == Storage[MsgId][5]))
                                        .Select(x => new MessCard
                                        {
                                            type = 1,
                                            platform = "facebook",
                                            title = x.Product.Name,
                                            subtitle = x.Product.Price.ToString(),
                                            imageUrl = x.Product.ImgUrl,
                                            buttons = new[]
                                                {
                                                    new Button
                                                    {
                                                        text = "Đặt liền",
                                                        postback = x.ProductId
                                                    }
                                                }
                                        }).ToArray();
                                        if (!messages.Any())
                                            return Receiver.Json(new
                                            {
                                                speech = "Xin lỗi bạn. Chúng mình tạm thời không còn bán loại hàng này."
                                            });
                                        return Receiver.Json(new
                                        {
                                            speech = "",
                                            messages
                                        });
                                    }
                                }
                        }

                        break;
                    }
                #endregion
                #region Step 2
                case 2:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 2, MsgQuery);
                        return Receiver.Json(new
                        {
                            speech = "Bạn có thể cho mình biết tên đăng nhập trên hệ thống Cutieshop được không ạ?"
                        });
                    }
                #endregion
                #region Step 1
                case 1:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 1, MsgReply);
                        using (var userDAO = new UserDAO())
                        {
                            var user = await userDAO.ReadChild(Storage[MsgId][1]);
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
                                    ProductId = Storage[MsgId][2],
                                    OnlineOrderId = orderId
                                });
                                return Receiver.Json(new
                                {
                                    speech = $"Mail xác nhận đã được gửi đến {user.Email}. Hãy xác nhận qua mail để hoàn tất đặt hàng nhé!"
                                });
                            }
                        }
                    }
                    #endregion
            }
            throw new UnhandledChatException();
        }
    }
}
