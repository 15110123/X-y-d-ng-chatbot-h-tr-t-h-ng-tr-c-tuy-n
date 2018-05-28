using CutieShop.Models.JSONEntities.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Diagnostics;
using SelectPdf;
using CutieShop.Models.Utils;
//using RazorPDFCore;

namespace CutieShop.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {
        public async Task<IActionResult> index()
        {
            using (var httpClient = new HttpClient()){
                var res = await (await httpClient.GetAsync("http://localhost:51992/api/report/all")).Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<dynamic>(res);
                var IdReportNavigation_DateElWarehouse = obj[0].DateElWarehouse;
                string IdJoin = obj.joinXX[1].idJoin;
                string IdTdk = obj.joinXX[2].idTdk;
                string IdNtk = obj.joinXX[3].idNtk;
                string IdXtk = obj.joinXX[4].idXtk;
                string IdTck = obj.joinXX[5].idTck;

                var html = View(obj).ToHtml(HttpContext);
                var converter = new HtmlToPdf();
                var doc = converter.ConvertHtmlString(html);
                var pdfByte = doc.Save();
                doc.Close();
            return File(pdfByte, "application/pdf");
            //return ViewPdf(null, "report.pdf", "index", false);
                        }
        }
    }
}
