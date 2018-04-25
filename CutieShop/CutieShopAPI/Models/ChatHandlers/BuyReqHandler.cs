using CutieShop.API.Models.DAOs;
using CutieShop.API.Models.Exceptions;
using CutieShop.API.Models.JSONEntities.FacebookRichMessages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.ChatHandlers
{
    internal class BuyReqHandler : ChatHandler
    {
        public BuyReqHandler(Controller receiver, dynamic request)
            : base(receiver, (object)request)
        {

        }

        public override async Task<IActionResult> Result()
        {
            switch ((int)Request.result.contexts[0].lifespan)
            {
                #region step 5
                case 5:
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
                #region Step 4
                case 4:
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
                #region Step 3
                case 3:
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

                #region Step 2

                case 2:
                    {
                        Storage.AddOrUpdateToStorage(MsgId, 3, MsgReply);

                        //Find minimum and maximum price from step 3
                        int minimumPrice, maximumPrice;

                        if (Storage[MsgId][3] == "<100000")
                        {
                            minimumPrice = 0;
                            maximumPrice = 99999;
                        }
                        else if (Storage[MsgId][3] == "100000 - 300000")
                        {
                            minimumPrice = 100000;
                            maximumPrice = 300000;
                        }
                        else if (Storage[MsgId][3] == ">300000 - 500000")
                        {
                            minimumPrice = 300001;
                            maximumPrice = 500000;
                        }
                        else
                        {
                            minimumPrice = 500001;
                            maximumPrice = int.MaxValue;
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
                                                        text = "Mua ngay",
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
            }
            throw new UnhandledChatException();
        }
    }
}
