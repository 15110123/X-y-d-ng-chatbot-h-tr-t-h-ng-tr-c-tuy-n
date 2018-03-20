using System.Dynamic;
using System.Threading.Tasks;
using CutieShop.API.DB.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace CutieShop.API.DB.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            using (var authDAO = new AuthDAO())
            {
                var result = await authDAO.Read(username, password);
                if (result == null) return Json(null);
                var sessionId = await authDAO.CreateSession(result.Id);

                dynamic jsonObj = new ExpandoObject();

                jsonObj.sessionId = sessionId;
                jsonObj.name = result.Name;
                jsonObj.profileImg = result.ProfileImg;

                if (result.Employee != null)
                {
                    jsonObj.customer = null;
                    jsonObj.employee = new
                    {
                        address = result.Employee.Address,
                        dateOfBirth = result.Employee.DateOfBirth,
                        homeTown = result.Employee.HomeTown,
                        phoneNumber = result.Employee.PhoneNumber,
                        email = result.Employee.Email,
                        type = result.Employee.Type,
                        store = result.Employee.Store
                    };
                }
                else
                {
                    jsonObj.customer = new
                    {
                        address = result.Customer.Address,
                        phoneNumber = result.Customer.PhoneNumber,
                        email = result.Customer.Email,
                        point = result.Customer.Point.Value
                    };
                    jsonObj.employee = null;
                }

                return Json(jsonObj);
            }
        }

        [Route("session")]
        [HttpPost]
        public async Task<IActionResult> Session(string sessionId)
        {
            using (var authDAO = new AuthDAO())
            {
                var result = await authDAO.ReadFromSession(sessionId);
                if (result == null) return Json(null);

                dynamic jsonObj = new ExpandoObject();

                jsonObj.sessionId = sessionId;
                jsonObj.name = result.Name;
                jsonObj.profileImg = result.ProfileImg;

                if (result.Employee != null)
                {
                    jsonObj.customer = null;
                    jsonObj.employee = new
                    {
                        address = result.Employee.Address,
                        dateOfBirth = result.Employee.DateOfBirth,
                        homeTown = result.Employee.HomeTown,
                        phoneNumber = result.Employee.PhoneNumber,
                        email = result.Employee.Email,
                        type = result.Employee.Type,
                        store = result.Employee.Store
                    };
                }
                else
                {
                    jsonObj.customer = new
                    {
                        address = result.Customer.Address,
                        phoneNumber = result.Customer.PhoneNumber,
                        email = result.Customer.Email,
                        point = result.Customer.Point.Value
                    };
                    jsonObj.employee = null;
                }

                return Json(jsonObj);
            }
        }
    }
}