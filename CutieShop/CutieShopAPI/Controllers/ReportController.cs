using System.Dynamic;
using System.Threading.Tasks;
using CutieShop.API.Models.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CutieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        [HttpGet("report/{reportId}")]
        public async Task<IActionResult> GetReport(string reportId)
        {
            using (var reportDAO = new ReportDAO())
            {
                var foundReport = await reportDAO.Context.Report
                .AsNoTracking()
                .Include(x => x.JoinXx)
                .FirstOrDefaultAsync(x => x.IdReport == reportId);

                var joinXX = foundReport.JoinXx.Select(x => new
                {
                    x.IdJoin,
                    x.IdTdk,
                    x.IdNtk,
                    x.IdXtk,
                    x.IdTck
                }).ToArray();

                return Json(new
                {
                    foundReport.DateElWarehouse,
                    joinXX
                }
                );
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllReport()
        {
            using (var reportDAO = new ReportDAO())
            {
                var foundReport = reportDAO.Context.Report
                .AsNoTracking()
                .Include(x => x.JoinXx)
                .ThenInclude(x => x.IdReportNavigation)
                .Select(x => new{
                    x.IdReport,
                    joinXX = x.JoinXx.Select(y => new
                {
                    y.IdReportNavigation.DateElWarehouse,
                    y.IdJoin,
                    y.IdTdk,
                    y.IdNtk,
                    y.IdXtk,
                    y.IdTck
                }).ToArray(),
                    x.DateElWarehouse
                }).ToArray();

                return Json(foundReport);
            }
        }
    }
}