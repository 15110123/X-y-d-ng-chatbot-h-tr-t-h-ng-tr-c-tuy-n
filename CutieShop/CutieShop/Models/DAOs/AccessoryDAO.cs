// ReSharper disable InconsistentNaming

using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.Models.DAOs
{
    public sealed class AccessoryDAO : ProductDAO, IChildDAO<string, Accessory>
    {
        public AccessoryDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Accessory childEntity)
        {
            try
            {
                await Context.Accessory.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Accessory> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Accessory
                        .Include(x => x.Product)
                        .Include(x => x.Origin)
                        .Include(x => x.Material)
                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.Accessory
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

        public async Task<IQueryable<Accessory>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking
                    ?  Context.Accessory
                    :  Context.Accessory.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Accessory childEntity)
        {
            try
            {
                Context.Accessory.Update(childEntity);
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
                Context.Accessory.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
