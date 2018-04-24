using CutieShop.API.Models.Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public abstract class ProductDAO<TChildEntity> : CutieshopDAO<string, Product>
    {
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

        public abstract Task<bool> CreateChild(TChildEntity childEntity);

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

        public abstract Task<TChildEntity> ReadChild(string id);

        public override async Task<IEnumerable<Product>> ReadAll(string id)
        {
            try
            {
                return Context.Product.AsNoTracking().Where(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public abstract Task<IEnumerable<TChildEntity>> ReadAllChild(string id);

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

        public abstract Task<bool> UpdateChild(TChildEntity childEntity);

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

        public abstract Task<bool> DeleteChild(string id);
    }
}
