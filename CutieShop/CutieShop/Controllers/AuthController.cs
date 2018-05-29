using System;
using System.Dynamic;
using System.Threading.Tasks;
using CutieShop.Models.DAOs;
using CutieShop.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            try
            {
                using (var userDAO = new UserDAO())
                {
                    dynamic jsonObj = new ExpandoObject();

                    var resultUser = await userDAO.Context.User
                        .Include(x => x.UsernameNavigation)
                        .Include(x => x.UserPoint)
                        .FirstOrDefaultAsync(x => x.Username == username && x.UsernameNavigation.Password == password);

                    if (resultUser == null)
                    {
                        using (var employeeDAO = new EmployeeDAO())
                        {
                            var resultEmp = await employeeDAO.Context.Employee
                                .Include(x => x.UsernameNavigation)
                                .FirstOrDefaultAsync(x => x.Username == username && x.UsernameNavigation.Password == password);
                            jsonObj.sessionId = await employeeDAO.CreateSession(resultEmp.Username);
                            jsonObj.employee = new
                            {
                                roleId = resultEmp.RoleId,
                                email = resultEmp.Email
                            };
                        }
                    }

                    else
                    {
                        jsonObj.sessionId = await userDAO.CreateSession(resultUser.Username);
                        jsonObj.user = new
                        {
                            firstName = resultUser.FirstName,
                            lastName = resultUser.LastName,
                            birthDate = resultUser.BirthDate,
                            address = resultUser.Address,
                            district = resultUser.District,
                            city = resultUser.City,
                            email = resultUser.Email,
                            point = resultUser.UserPoint == null ? 0 : resultUser.UserPoint.Value
                        };
                    }
                    return Json(jsonObj);
                }
            }
            catch
            {
                return Json(null);
            }
        }

        [Route("session")]
        [HttpPost]
        public async Task<IActionResult> Session(string sessionId)
        {
            using (var sessionDAO = new SessionDAO())
            {
                var result = await sessionDAO.Context.Session
                    .Include(x => x.UsernameNavigation)
                    .FirstOrDefaultAsync(x => x.SessionId == sessionId);
                if (result == null) return Json(null);

                return await Index(result.UsernameNavigation.Username, result.UsernameNavigation.Password);
            }
        }

        [Route("Signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(string username, string password, string firstName, string lastName, DateTime? birthDate, string address, string district, string city, string email)
        {
            using (var userDAO = new UserDAO())
            {
                //Create auth
                await userDAO.Create(new Auth
                {
                    Username = username,
                    Password = password
                });

                //Create user
                await userDAO.CreateChild(new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate,
                    Address = address,
                    District = district,
                    City = city,
                    Email = email
                });
            }
            return Json(new
            {
                success = true
            });
        }
    }
}