using CutieShop.Models.JSONEntities.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;

namespace CutieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly APISettings _apiSettings;

        public HomeController(IOptions<APISettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            dynamic model = new ExpandoObject();
            model.MainAPI = _apiSettings.Url.MainUrl;
            model.DbAPI = _apiSettings.Url.DbUrl;

            model.SessionId = HttpContext.Request.Cookies["sessionId"] ?? HttpContext.Session.GetString("sessionId");
            string userRawData = null;

            if (model.SessionId != null)
            {
                var client = new RestClient(_apiSettings.Url.DbUrl + "/api/auth/session");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Postman-Token", model.SessionId);
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
                request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"sessionId\"\r\n\r\n07f8833b-674e-4226-b164-d35c40a40105\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
                var response = client.Execute(request);
                userRawData = response.Content;
            }

            model.User = null;

            //If user has logged in
            if (!string.IsNullOrEmpty(userRawData))
            {
                model.User = JsonConvert.DeserializeObject(userRawData);
            }

            return View(model);
        }

        //Saving session action
        [HttpPost("savesession")]
        public void SaveSession(string sessionId)
        {
            HttpContext.Session.SetString("sessionId", sessionId);
        }

        //Removing session action
        [HttpPost("removesession")]
        public void RemoveSession(string sessionId)
        {
            HttpContext.Session.Remove("sessionId");
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
