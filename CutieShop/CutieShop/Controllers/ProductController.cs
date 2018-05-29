using System;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.Controllers
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

        [HttpGet("pet/all/type")]
        public async Task<IActionResult> GetPetType()
        {
            using (var petTypeDAO = new PetTypeDAO())
            {
                return Json((await petTypeDAO.ReadAll(false))
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

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> GetSearchResult(string keyword)
        {
            using (var productDAO = new ProductDAO())
            {
                return Json(await productDAO.Context.Product
                .Where(x => x.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                .Select(x => new
                {
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

        [HttpGet("search/filter/{keyword}")]
        public async Task<IActionResult> GetSearchFilteredResult(string keyword, [FromHeader]int productType, string petType)
        {
            using (var productDAO = new ProductDAO())
            {
                if (productType == -1)
                {
                    return Json(await productDAO.Context.Product
                    .Include(x => x.ProductForPetType)
                    .Where(x => x.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1
                    && x.ProductForPetType.Any(y => string.IsNullOrEmpty(petType) || y.PetTypeId == petType))
                    .Select(x => new
                    {
                        x.ProductId,
                        x.ImgUrl,
                        x.Name,
                        x.Description,
                        x.Price,
                        x.VendorId
                    })
                    .ToArrayAsync());
                }
                if (productType == 0)
                {
                    return Json(await productDAO.Context.Accessory
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductForPetType)
                    .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1
                    && x.Product.ProductForPetType.Any(y => string.IsNullOrEmpty(petType) || y.PetTypeId == petType))
                    .Select(x => new
                    {
                        x.ProductId,
                        x.Product.ImgUrl,
                        x.Product.Name,
                        x.Product.Description,
                        x.Product.Price,
                        x.Product.VendorId
                    })
                    .ToArrayAsync());
                }
                if (productType == 1)
                {
                    return Json(await productDAO.Context.Cage
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductForPetType)
                    .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1
                    && x.Product.ProductForPetType.Any(y => string.IsNullOrEmpty(petType) || y.PetTypeId == petType))
                    .Select(x => new
                    {
                        x.ProductId,
                        x.Product.ImgUrl,
                        x.Product.Name,
                        x.Product.Description,
                        x.Product.Price,
                        x.Product.VendorId
                    })
                    .ToArrayAsync());
                }
                if (productType == 2)
                {
                    return Json(await productDAO.Context.Pet
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductForPetType)
                    .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                    .Select(x => new
                    {
                        x.ProductId,
                        x.Product.ImgUrl,
                        x.Product.Name,
                        x.Product.Description,
                        x.Product.Price,
                        x.Product.VendorId
                    })
                    .ToArrayAsync());
                }
                if (productType == 3)
                {
                    return Json(await productDAO.Context.Service
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductForPetType)
                    .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1
                    && x.Product.ProductForPetType.Any(y => string.IsNullOrEmpty(petType) || y.PetTypeId == petType))
                    .Select(x => new
                    {
                        x.ProductId,
                        x.Product.ImgUrl,
                        x.Product.Name,
                        x.Product.Description,
                        x.Product.Price,
                        x.Product.VendorId
                    })
                    .ToArrayAsync());
                }
                if (productType == 4)
                {
                    return Json(await productDAO.Context.Toy
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductForPetType)
                    .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1
                    && x.Product.ProductForPetType.Any(y => string.IsNullOrEmpty(petType) || y.PetTypeId == petType))
                    .Select(x => new
                    {
                        x.ProductId,
                        x.Product.ImgUrl,
                        x.Product.Name,
                        x.Product.Description,
                        x.Product.Price,
                        x.Product.VendorId
                    })
                    .ToArrayAsync());
                }
                return Json(await productDAO.Context.Food
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductForPetType)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1
                && x.Product.ProductForPetType.Any(y => string.IsNullOrEmpty(petType) || y.PetTypeId == petType))
                .Select(x => new
                {
                    x.ProductId,
                    x.Product.ImgUrl,
                    x.Product.Name,
                    x.Product.Description,
                    x.Product.Price,
                    x.Product.VendorId
                })
                .ToArrayAsync());
            }
        }

        [HttpGet("accessory/search/{keyword}")]
        public async Task<IActionResult> GetaccessorySearchResult(string keyword)
        {
            using (var accessoryDAO = new AccessoryDAO())
            {
                return Json((accessoryDAO.Context.Accessory
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("cage/search/{keyword}")]
        public async Task<IActionResult> GetCageSearchResult(string keyword)
        {
            using (var cageDAO = new CageDAO())
            {
                return Json((cageDAO.Context.Cage
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("pet/search/{keyword}")]
        public async Task<IActionResult> GetPetSearchResult(string keyword)
        {
            using (var petDAO = new PetDAO())
            {
                return Json((petDAO.Context.Cage
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("service/search/{keyword}")]
        public async Task<IActionResult> GetServiceSearchResult(string keyword)
        {
            using (var serviceDAO = new ServiceDAO())
            {
                return Json((serviceDAO.Context.Cage
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }

        [HttpGet("toy/search/{keyword}")]
        public async Task<IActionResult> GetToySearchResult(string keyword)
        {
            using (var toyDAO = new ToyDAO())
            {
                return Json((toyDAO.Context.Toy
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }


        [HttpGet("food/search/{keyword}")]
        public async Task<IActionResult> GetFoodSearchResult(string keyword)
        {
            using (var foodDAO = new FoodDAO())
            {
                return Json((foodDAO.Context.Food
                .Include(x => x.Product)
                .Where(x => x.Product.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1))
                .ToArray());
            }
        }
    }
}