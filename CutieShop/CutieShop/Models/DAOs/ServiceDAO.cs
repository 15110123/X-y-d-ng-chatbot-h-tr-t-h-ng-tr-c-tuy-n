using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public sealed class ServiceDAO : ProductDAO, IChildDAO<string, Service>
    {
        public ServiceDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Service childEntity)
        {
            try
            {
                await Context.Service.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Service> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Service
                        .Include(x => x.Product)
                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.Service
                    .AsNoTracking()
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Service>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking 
                    ?  Context.Service 
                    :  Context.Service.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Service childEntity)
        {
            try
            {
                Context.Service.Update(childEntity);
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
                Context.Service.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
