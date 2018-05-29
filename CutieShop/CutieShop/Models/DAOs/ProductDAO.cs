using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public class ProductDAO : CutieshopDAO<string, Product>
    {
        public ProductDAO(CutieshopContext context = null) : base(context)
        {
        }

        public override async Task<bool> Create(Product entity)
        {
            try
            {
                await Context.Product.AddAsync(entity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<Product> Read(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Product.FindAsync(id);
                return await Context.Product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Product>> ReadAll(bool isTracking)
        {
            try
            {
                return isTracking ? Context.Product : Context.Product.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> Update(Product entity)
        {
            try
            {
                Context.Product.Update(entity);
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
                Context.Product.Remove(await Read(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
