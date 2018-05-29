using CutieShop.API.Models.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CutieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("accessory/all")]
        public async Task<IActionResult> GetAllAccessory()
        {
            using (var accessoryDAO = new AccessoryDAO())
            {
                return Json((await accessoryDAO.ReadAll(false))
                .ToArray());
            }
        }

        [HttpGet("cage/all")]
        public async Task<IActionResult> GetAllCage()
        {
            using (var cageDAO = new CageDAO())
            {
                return Json((await cageDAO.ReadAll(false))
                .ToArray());
            }
        }

        [HttpGet("pet/all")]
        public async Task<IActionResult> GetPet()
        {
            using (var petDAO = new PetDAO())
            {
                return Json((await petDAO.ReadAll(false))
                .ToArray());
            }
        }

        [HttpGet("service/all")]
        public async Task<IActionResult> GetService()
        {
            using (var serviceDAO = new ServiceDAO())
            {
                return Json((await serviceDAO.ReadAll(false))
                .ToArray());
            }
        }

        [HttpGet("toy/all")]
        public async Task<IActionResult> GetToy()
        {
            using (var toyDAO = new ToyDAO())
            {
                return Json((await toyDAO.ReadAll(false))
                .ToArray());
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchResult([FromHeader]string keyword)
        {
            using (var productDAO = new ProductDAO()){
                return Json(await productDAO.Context.Product
                .Where(x => x.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                .Select(x => new{
                    x.ProductId,
                    x.ImgUrl,
                    x.Name,
                    x.Description,
                    x.Price,
                    x.VendorId
                })
                .ToArrayAsync());
            }
        }

        [HttpGet("accessory/search")]
        public async Task<IActionResult> GetaccessorySearchResult(string keyword)
        {
            using (var accessoryDAO = new AccessoryDAO()){
                return Json((accessoryDAO.Context.Accessory
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("cage/search")]
        public async Task<IActionResult> GetCageSearchResult(string keyword){
            using (var cageDAO = new CageDAO()){
                return Json((cageDAO.Context.Cage
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("pet/search")]
        public async Task<IActionResult> GetPetSearchResult(string keyword){
            using (var petDAO = new PetDAO()){
                return Json((petDAO.Context.Cage
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("service/search")]
        public async Task<IActionResult> GetServiceSearchResult(string keyword){
            using (var serviceDAO = new ServiceDAO()){
                return Json((serviceDAO.Context.Cage
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("toy/search")]
        public async Task<IActionResult> GetToySearchResult(string keyword)
        {
            using (var toyDAO = new ToyDAO()){
                return Json((toyDAO.Context.Toy
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }
    }
}