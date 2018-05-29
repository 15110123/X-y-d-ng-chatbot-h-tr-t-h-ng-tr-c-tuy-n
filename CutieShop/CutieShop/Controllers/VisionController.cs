using System.IO;
using System.Threading.Tasks;
using CutieShop.Models.JSONEntities.Settings;
using CutieShop.Models.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CutieShop.Controllers
{
    [Route("api/[controller]")]
    public sealed class VisionController : Controller
    {
        private readonly AzureSettings _azureSettings;

        public VisionController(IOptions<AzureSettings> azureSettings)
        {
            _azureSettings = azureSettings.Value;
        }

        [HttpPost]
        public async Task<JsonResult> Index(string imageUrl)
        {
            var visionUtil = new VisionUtils(_azureSettings);
            return Json(await visionUtil.GetResult(imageUrl));
        }

        [HttpPost("fromfile")]
        public async Task<JsonResult> FromFile(IFormFile imgFile)
        {
            using (var stream = new MemoryStream())
            {
                await imgFile.CopyToAsync(stream);
                var visionUtil = new VisionUtils(_azureSettings);
                return Json(await visionUtil.GetResult(stream));
            }
        }
    }
}