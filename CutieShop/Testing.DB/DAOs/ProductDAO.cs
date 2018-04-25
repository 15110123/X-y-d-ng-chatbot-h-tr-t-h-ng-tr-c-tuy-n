using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.DB.Entities;

// ReSharper disable InconsistentNaming

namespace Testing.DB.DAOs
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

        public abstract Task<IQueryable<TChildEntity>> ReadAllChild();

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
