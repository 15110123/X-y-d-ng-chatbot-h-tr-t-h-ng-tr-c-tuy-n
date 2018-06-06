using CutieShop.Models.Entities;
using CutieShop.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using static CutieShop.Models.Utils.RespBuilderUtils;

namespace CutieShop.Models.ChatHandlers
{
    public partial class BuyReqHandler
    {
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
                return Recv.Json(RespObj(RespType.Cards, "", cards: msgs));

            //Require user to choose another price
            //Storage.RemoveId(MsgId);
            Storage.StepBack(MsgId);
            return Recv.Json(RespObj(RespType.QuickReplies,
                "Xin lỗi bạn. Chúng mình tạm thời không còn bán loại hàng này. Bạn vui lòng chọn mức giá khác",
                new[] { "<100000", "100000 - 300000", ">300000 - 500000", ">500000" }));
        }

        private Type GetProductType()
        {
            switch (Storage[MsgId, 2])
            {
                case "Đồ chơi":
                    return typeof(Toy);
                case "Thức ăn":
                    return typeof(Food);
                case "Lồng":
                    return typeof(Cage);
                case "phụ kiện":
                    return typeof(Accessory);
                default:
                    throw new UnhandledChatException();
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
            return RespObj(RespType.Button, "Click để quay lại", btnTitle: "Quay lại", btnPayload: "undo");
        }
    }
}
