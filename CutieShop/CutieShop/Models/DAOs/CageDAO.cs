// ReSharper disable InconsistentNaming

using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.Models.DAOs
{
    public sealed class CageDAO : ProductDAO, IChildDAO<string, Cage>
    {
        public CageDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Cage childEntity)
        {
            try
            {
                await Context.Cage.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Cage> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Cage
                                        .Include(x => x.Product)
                                        .Include(x => x.Origin)
                                        .Include(x => x.Material)
                                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.Cage
                                    .AsNoTracking()
                                    .Include(x => x.Product)
                                    .Include(x => x.Origin)
                                    .Include(x => x.Material)
                                    .FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Cage>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking
                    ? Context.Cage
                    : Context.Cage.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Cage childEntity)
        {
            try
            {
                Context.Cage.Update(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteChild(string id)
        {
            try
            {
                Context.Cage.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
