using System.Dynamic;
using System.Threading.Tasks;
using CutieShop.API.Models.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using CutieShop.API.Models.Entities;
using System.Linq;
using static CutieShop.API.Models.Utils.CookiesUtils;
using System.Collections.Generic;

namespace CutieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class OnlineOrderController : Controller
    {
        [HttpGet("user")]
        public async Task<IActionResult> UserProductOrder()
        {
            //find username with session Id
            using (var sessionDAO = new SessionDAO())
            {
                var foundUsername = (await sessionDAO.Read(this.SessionId(), false)).Username;

                using (var onlineOrderDAO = new OnlineOrderProductDAO(sessionDAO.Context))
                {
                    var result = onlineOrderDAO.Context.OnlineOrder
                    .Include(x => x.Status)
                    .Include(x => x.OnlineOrderProduct)
                    .Where(x => x.Username == foundUsername)
                    .Select(x => new
                    {
                        onlineOrderId = x.OnlineOrderId,
                        lastName = x.LastName,
                        firstName = x.FirstName,
                        address = x.Address,
                        postCode = x.PostCode,
                        city = x.City,
                        phoneNo = x.PhoneNo,
                        email = x.Email,
                        date = x.Date,
                        statusId = x.StatusId,
                        statusName = x.Status.Name,
                        statusDescription = x.Status.Description,
                        products = x.OnlineOrderProduct.Select(y => new
                        {
                            productId = y.ProductId,
                            quantity = y.Quantity
                        })
                    })
                    .ToArray();
                    return Json(result);
                }
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllProductOrder()
        {
            using (var onlineOrderProductDAO = new OnlineOrderProductDAO())
            {
                var result = onlineOrderProductDAO.Context.OnlineOrder
                .Include(x => x.Status)
                .Include(x => x.OnlineOrderProduct)
                .ThenInclude(x => x.Product)
                .Include(x => x.ServiceOnlineOrder)
                .Where(x => x.ServiceOnlineOrder == null)
                .Select(x => new
                {
                    username = x.Username,
                    onlineOrderId = x.OnlineOrderId,
                    lastName = x.LastName,
                    firstName = x.FirstName,
                    address = x.Address,
                    postCode = x.PostCode,
                    city = x.City,
                    phoneNo = x.PhoneNo,
                    email = x.Email,
                    date = x.Date,
                    statusId = x.StatusId,
                    statusName = x.Status.Name,
                    statusDescription = x.Status.Description,
                    products = x.OnlineOrderProduct.Select(y => new
                    {
                        productId = y.ProductId,
                        quantity = y.Quantity
                    }),
                    totalPrice = x.OnlineOrderProduct
                        .Sum(y => y.Product.Price * y.Quantity)
                }).ToArray();
                return Json(result);
            }
        }
    }
}