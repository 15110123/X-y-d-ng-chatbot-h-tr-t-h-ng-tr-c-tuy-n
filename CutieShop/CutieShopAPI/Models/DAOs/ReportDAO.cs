using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;
using System;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public sealed class ReportDAO : CutieshopDAO<string, Report>
    {
        public ReportDAO(CutieshopContext context = null) : base(context)
        {
        }

        public override async Task<bool> Create(Report entity)
        {
            try
            {
                await Context.Report.AddAsync(entity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<Report> Read(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Report.FindAsync(id);
                return await Context.Report.AsNoTracking().FirstOrDefaultAsync(x => x.IdReport == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Report>> ReadAll(bool isTracking)
        {
            try
            {
                return isTracking ? Context.Report : Context.Report.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> Update(Report entity)
        {
            try
            {
                Context.Report.Update(entity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<bool> Delete(string id)
        {
            try
            {
                Context.Report.Remove(await Read(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
