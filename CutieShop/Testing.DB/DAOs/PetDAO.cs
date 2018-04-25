using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.DB.Entities;

// ReSharper disable InconsistentNaming

namespace Testing.DB.DAOs
{
    public sealed class PetDAO : ProductDAO<Pet>
    {
        public override async Task<bool> CreateChild(Pet childEntity)
        {
            try
            {
                //Get the result of creating the product
                if (!await Create(childEntity.Product)) return false;
                await Context.Pet.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<Pet> ReadChild(string id)
        {
            try
            {
                return await Context.Pet.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Pet>> ReadAllChild()
        {
            try
            {
                return Context.Pet.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> UpdateChild(Pet childEntity)
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

        public override async Task<bool> DeleteChild(string id)
        {
            try
            {
                Context.Pet.Remove(await ReadChild(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
