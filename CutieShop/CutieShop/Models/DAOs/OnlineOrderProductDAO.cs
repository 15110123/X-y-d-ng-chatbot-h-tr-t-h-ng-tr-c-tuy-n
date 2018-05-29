using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public sealed class OnlineOrderProductDAO : OnlineOrderDAO, IChildDAO<string, OnlineOrderProduct>
    {
        public OnlineOrderProductDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(OnlineOrderProduct childEntity)
        {
            try
            {
                await Context.OnlineOrderProduct.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<OnlineOrderProduct> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.OnlineOrderProduct
                        .Include(x => x.OnlineOrder)
                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.OnlineOrderProduct
                    .AsNoTracking()
                    .Include(x => x.OnlineOrder)
                    .FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<OnlineOrderProduct>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking 
                    ? Context.OnlineOrderProduct 
                    : Context.OnlineOrderProduct.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(OnlineOrderProduct childEntity)
        {
            try
            {
                await Context.OnlineOrderProduct.AddAsync(childEntity);
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
                Context.OnlineOrderProduct.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
