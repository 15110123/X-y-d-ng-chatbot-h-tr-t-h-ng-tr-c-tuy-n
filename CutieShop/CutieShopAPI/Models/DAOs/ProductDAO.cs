using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
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

        public override async Task<Product> Read(string id)
        {
            try
            {
                return await Context.Product.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Product>> ReadAll()
        {
            try
            {
                return Context.Product.AsNoTracking();
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
                Context.Product.Remove(await Read(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
