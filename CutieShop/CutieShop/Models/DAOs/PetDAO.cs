using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public sealed class PetDAO : ProductDAO, IChildDAO<string, Pet>
    {
        public PetDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Pet childEntity)
        {
            try
            {
                await Context.Pet.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Pet> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Pet
                        .Include(x => x.Product)
                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.Pet
                    .AsNoTracking()
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Pet>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking 
                    ?  Context.Pet 
                    :  Context.Pet.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Pet childEntity)
        {
            try
            {
                Context.Pet.Update(childEntity);
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
                Context.Pet.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
