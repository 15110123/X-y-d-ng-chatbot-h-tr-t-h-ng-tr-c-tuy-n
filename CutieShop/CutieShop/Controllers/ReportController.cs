using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelectPdf;
using System.Net.Http;
using System.Threading.Tasks;
//using RazorPDFCore;

namespace CutieShop.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {
        public async Task<IActionResult> index()
        {
            using (var httpClient = new HttpClient()){
                var res = await (await httpClient.GetAsync("http://localhost:53730/api/reportapi/all")).Content.ReadAsStringAsync();
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
