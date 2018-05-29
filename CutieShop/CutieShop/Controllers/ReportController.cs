using CutieShop.Models.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SelectPdf;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using static CutieShop.Models.Utils.HtmlConvertUtil;
//using RazorPDFCore;

namespace CutieShop.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {
        [Route("{month}")]
        public async Task<IActionResult> index(int month)
        {
            using (var reportDAO = new ReportDAO())
            {
                dynamic expObj = new ExpandoObject();

                var foundReport = await reportDAO.Context.Report
                .Include(x => x.JoinXx)
                .ThenInclude(x => x.IdJoinNavigation)
                .Include(x => x.JoinXx)
                 .ThenInclude(x => x.IdTdkNavigation)
                 .Include(x => x.JoinXx)
                 .ThenInclude(x => x.IdNtkNavigation)
                 .Include(x => x.JoinXx)
                 .ThenInclude(x => x.IdXtkNavigation)
                 .Include(x => x.JoinXx)
                 .ThenInclude(x => x.IdTckNavigation)
                .FirstOrDefaultAsync(x => x.DateElWarehouse.Value.Month == month);

                expObj.DateElWarehouse = foundReport.DateElWarehouse.Value;

                var lstReportRow = new List<dynamic>();

                foreach (var ele in foundReport.JoinXx)
                {
                    dynamic expEle = new ExpandoObject();
                    expEle.IdProduct = ele.IdJoinNavigation.IdProduct;
                    expEle.ProductName = ele.IdJoinNavigation.ProductName;
                    expEle.Unit = ele.IdJoinNavigation.Unit;
                    expEle.QuantityTdk = ele.IdTdkNavigation.QuantityTdk;
                    expEle.Total1 = ele.IdTdkNavigation.Total;
                    expEle.QuantityNtk = ele.IdNtkNavigation.QuantityNtk;
                    expEle.Total2 = ele.IdNtkNavigation.Total;
                    expEle.QuantityXtk = ele.IdXtkNavigation.QuantityXtk;
                    expEle.Total3 = ele.IdXtkNavigation.Total;
                    expEle.PriceExport = ele.IdXtkNavigation.PriceExport;
                    expEle.QuantityTck = ele.IdTckNavigation.QuantityTck;
                    expEle.Total4 = ele.IdXtkNavigation.Total;
                    lstReportRow.Add(expEle);
                }

                expObj.ReportRow = lstReportRow;

                var html = (View(expObj) as ViewResult).ToHtml(HttpContext);
                var converter = new HtmlToPdf();
                var doc = converter.ConvertHtmlString(html);
                var pdfByte = doc.Save();
                doc.Close();
                return File(pdfByte, "application/pdf");
            }
        }
    }
}

