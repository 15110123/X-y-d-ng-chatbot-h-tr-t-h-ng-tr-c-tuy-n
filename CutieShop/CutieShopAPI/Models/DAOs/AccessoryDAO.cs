// ReSharper disable InconsistentNaming

using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.API.Models.DAOs
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

        public async Task<Accessory> ReadChild(string id)
        {
            try
            {
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

        public async Task<IQueryable<Accessory>> ReadAllChild()
        {
            try
            {
                return Context.Accessory
                    .AsNoTracking()
                    .Include(x => x.Product)
                    .Include(x => x.Origin)
                    .Include(x => x.Material);
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
                Context.Accessory.Remove(await ReadChild(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
