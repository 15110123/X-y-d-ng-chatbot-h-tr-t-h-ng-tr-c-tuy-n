using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.Models.ChatHandlers
{
    internal interface IChatHandler
    {
        Task<IActionResult> Result();
    }
}
