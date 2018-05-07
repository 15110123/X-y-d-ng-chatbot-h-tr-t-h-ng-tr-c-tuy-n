// ReSharper disable InconsistentNaming

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;

namespace CutieShop.API.Models.DAOs
{
    public class ToyDAO : ProductDAO, IChildDAO<string, Toy>
    {
        public ToyDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Toy childEntity)
        {
            try
            {
                await Context.Toy.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Toy> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Toy
                        .Include(x => x.Product)
                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.Toy
                    .AsNoTracking()
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Toy>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking
                    ? Context.Toy
                    : Context.Toy.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Toy childEntity)
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

        public async Task<bool> DeleteChild(string id)
        {
            try
            {
                Context.Toy.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
