// ReSharper disable InconsistentNaming

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.DB.Entities;

namespace Testing.DB.DAOs
{
    public class ToyDAO : ProductDAO<Toy>
    {
        public override async Task<bool> CreateChild(Toy childEntity)
        {
            try
            {
                if (!await Create(childEntity.Product)) return false;
                await Context.Toy.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<Toy> ReadChild(string id)
        {
            try
            {
                return await Context.Toy.Include(x => x.Product).FirstAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Toy>> ReadAllChild()
        {
            try
            {
                return Context.Toy.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> UpdateChild(Toy childEntity)
        {
            try
            {
                Context.Toy.Update(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<bool> DeleteChild(string id)
        {
            try
            {
                Context.Toy.Remove(await ReadChild(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
