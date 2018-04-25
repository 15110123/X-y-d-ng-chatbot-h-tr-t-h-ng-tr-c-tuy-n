using System.Diagnostics;
using CutieShop.API.Models.DAOs;
using CutieShop.API.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static CutieShop.API.Models.Utils.ChatRequestUtils;

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
                        Storage.AddOrUpdateToStorage(GetMessengerSenderId(Request), 5, GetMessengerReply(Request));
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
                        Storage.AddOrUpdateToStorage(GetMessengerSenderId(Request), 4, GetMessengerReply(Request));
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
                        Storage.AddOrUpdateToStorage(GetMessengerSenderId(Request), 3, GetMessengerReply(Request));
                        switch (Storage[GetMessengerSenderId(Request)][4])
                        {
                            case "Đồ chơi":
                            {

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
