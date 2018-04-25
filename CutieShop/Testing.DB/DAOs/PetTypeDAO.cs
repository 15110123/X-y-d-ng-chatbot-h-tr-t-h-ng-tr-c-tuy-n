using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.DB.Entities;

// ReSharper disable InconsistentNaming

namespace Testing.DB.DAOs
{
    public sealed class PetTypeDAO : CutieshopDAO<string, PetType>
    {
        public override async Task<bool> Create(PetType entity)
        {
            try
            {
                await Context.PetType.AddAsync(entity);
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
                Context.PetType.Remove(await Read(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<PetType> Read(string id)
        {
            try
            {
                return await Context.PetType.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<PetType>> ReadAll()
        {
            try
            {
                return Context.PetType.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> Update(PetType entity)
        {
            try
            {
                Context.PetType.Update(entity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
