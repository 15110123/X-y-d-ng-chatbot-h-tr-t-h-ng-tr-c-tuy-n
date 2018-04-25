using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.API.Models.ChatHandlers
{
    internal interface IChatHandler
    {
        Task<IActionResult> Result();
    }
}
