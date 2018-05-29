using System;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.DAOs;
using CutieShop.Models.Entities;
using CutieShop.Models.Exceptions;
using CutieShop.Models.Helpers;
using CutieShop.Models.JSONEntities.FacebookRichMessages;
using CutieShop.Models.JSONEntities.Settings;
using CutieShop.Models.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 4014

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.ChatHandlers
{
    internal class BuyReqHandler : ChatHandler
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
                                        replies = (await petTypeDAO.ReadAll(false))
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
                        return Receiver.Json(new
                        {
                            speech = "Bạn có thể cho mình biết tên đăng nhập trên hệ thống Cutieshop được không ạ?\nNếu chưa có, bạn có thể gõ tên đăng nhập mới để chúng mình tạo tài khoản cho bạn"
                        });
                    }
                #endregion
                #region Step 6

                case 6:
                    {
                        //This step receive username first, then the email and address. So we need to keep the username to the storage for further uses, email will be used once in this step and can be queried by DAO easily in the future. 
                        //Checking null will prevent email from being overwritten to username in Storage
                        if (Storage[MsgId, 5] == null)
                        {
                            Storage.AddOrUpdateToStorage(MsgId, 5, MsgReply);
                        }

                        using (var userDAO = new UserDAO())
                        {
                            var user = await userDAO.ReadChild(Storage[MsgId, 5], true);
                            //If user is null, create a user, then ask customer their email
                            if (user == null)
                            {
                                Storage.AddOrUpdateToStorage(MsgId, 6, "userPassword", new GuidHelper().CreateGuid());
                                await userDAO.Create(new Auth
                                {
                                    Username = Storage[MsgId, 5],
                                    Password = Storage[MsgId, 6, "userPassword"]
                                });
                                await userDAO.CreateChild(new User
                                {
                                    Username = Storage[MsgId, 5],
                                    Email = string.Empty,
                                    Address = string.Empty
                                });

                                await userDAO.Context.SaveChangesAsync();
                            }

                            user = await userDAO.ReadChild(Storage[MsgId, 5], true);
                            //If email is empty, as for email 
                            if (user.Email == string.Empty)
                            {
                                if (Storage[MsgId, 6, "isAskForEmail"] == null)
                                {
                                    Storage.AddOrUpdateToStorage(MsgId, 6, "isAskForEmail", "1");
                                    return Receiver.Json(new
                                    {
                                        speech = "Bạn hãy cho mình biết email nhé"
                                    });
                                }

                                user.Email = MsgReply;
                                await userDAO.Context.SaveChangesAsync();
                            }

                            //If address is empty but email is not, MsgReply must be address
                            if (user.Address == string.Empty)
                            {
                                if (Storage[MsgId, 6, "isAskForAddress"] == null)
                                {
                                    Storage.AddOrUpdateToStorage(MsgId, 6, "isAskForAddress", "1");
                                    return Receiver.Json(new
                                    {
                                        speech = "Bạn cho mình xin địa chỉ"
                                    });
                                }

                                user.Address = MsgReply;
                                await userDAO.Context.SaveChangesAsync();
                            }

                            //Ready to jump into step 7 after this
                            Storage.AddOrUpdateToStorage(MsgId, 6, null);

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
                                    ProductId = Storage[MsgId, 4],
                                    OnlineOrderId = orderId,
                                    Quantity = 1
                                });

                                Product buyProduct;
                                using (var productDAO = new ProductDAO())
                                {
                                    buyProduct = await productDAO.Read(Storage[MsgId, 4], false);
                                }
                                var mailProductTable = _mailContent.BuyReq.TableRow.
                                    Replace("{0}", buyProduct.Name)
                                    .Replace("{1}", buyProduct.Description)
                                    .Replace("{2}", "1");

                                var mailBody = _mailContent.BuyReq.Body
                                    .Replace("{0}", user.Username)
                                    .Replace("{1}", mailProductTable)
                                    .Replace("{2}", "http://cutieshopapi.azurewebsites.net/verify?id=" + orderId);

                                MailUtils.Send(user.Email, _mailContent.BuyReq.Subject, mailBody);

                                var reply =
                                    $"Mail xác nhận đã được gửi đến {user.Email}. Hãy xác nhận qua mail để hoàn tất đặt hàng nhé!";

                                //Send temporary password if customer create new account
                                if (Storage[MsgId, 6, "userPassword"] != null)
                                {
                                    reply = $"Password tạm thời của bạn là {Storage[MsgId, 6, "userPassword"]}. Bạn nên vào trang chủ để thay đổi mật khẩu mặc định\n" + reply;
                                }

                                //Remove data in storage
                                Storage.RemoveId(MsgId);

                                return Receiver.Json(new
                                {
                                    speech = reply
                                });
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
            MessCard[] messages;
            if (childType == typeof(Toy))
            {
                messages = (await new ToyDAO().ReadAllChild(false))
                    .Include(x => x.Product)
                    .Include(x => x.Product.ProductForPetType)
                    .Where(x => x.Product.Price >= minPrice
                                && x.Product.Price <= maxPrice
                                && x.Product.ProductForPetType.Any(y => y.PetType.Name == Storage[MsgId, 1, ""]))
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
            }
            else if (childType == typeof(Food))
            {
                messages = (await new FoodDAO().ReadAllChild(false))
                    .Include(x => x.Product)
                    .Include(x => x.Product.ProductForPetType)
                    .Where(x => x.Product.Price >= minPrice
                                && x.Product.Price <= maxPrice
                                && x.Product.ProductForPetType.Any(y => y.PetType.Name == Storage[MsgId, 1, ""]))
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
            }
            else if (childType == typeof(Cage))
            {
                messages = (await new CageDAO().ReadAllChild(false))
                    .Include(x => x.Product)
                    .Include(x => x.Product.ProductForPetType)
                    .Where(x => x.Product.Price >= minPrice
                                && x.Product.Price <= maxPrice
                                && x.Product.ProductForPetType.Any(y => y.PetType.Name == Storage[MsgId, 1, ""]))
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
            }
            else
            {
                messages = (await new AccessoryDAO().ReadAllChild(false))
                    .Include(x => x.Product)
                    .Include(x => x.Product.ProductForPetType)
                    .Where(x => x.Product.Price >= minPrice
                                && x.Product.Price <= maxPrice
                                && x.Product.ProductForPetType.Any(y => y.PetType.Name == Storage[MsgId, 1, ""]))
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
            }

            //Return message
            if (messages.Any())
                return Receiver.Json(new
                {
                    speech = "",
                    messages
                });

            //Delete data when no products found
            Storage.RemoveId(MsgId);
            return Receiver.Json(new
            {
                speech = "Xin lỗi bạn. Chúng mình tạm thời không còn bán loại hàng này."
            });

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
    }
}
