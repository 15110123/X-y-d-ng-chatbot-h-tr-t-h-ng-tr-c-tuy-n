using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.Models.ChatHandlers
{
    public interface IChatHandler
    {
        Task<IActionResult> Result();
    }
}
