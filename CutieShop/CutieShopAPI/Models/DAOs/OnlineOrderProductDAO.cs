using CutieShop.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
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

        public async Task<OnlineOrderProduct> ReadChild(string id)
        {
            try
            {
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

        public async Task<IQueryable<OnlineOrderProduct>> ReadAllChild()
        {
            try
            {
                return Context.OnlineOrderProduct.AsNoTracking();
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
                Context.OnlineOrderProduct.Remove(await ReadChild(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
