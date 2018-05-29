using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public sealed class PetTypeDAO : CutieshopDAO<string, PetType>
    {
        public PetTypeDAO(CutieshopContext context = null) : base(context)
        {
        }

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
                Context.PetType.Remove(await Read(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<PetType> Read(string id, bool isTracking)
        {
            try
            {
                if (isTracking) return await Context.PetType.FindAsync(id);
                return await Context.PetType.AsNoTracking().FirstOrDefaultAsync(x => x.PetTypeId == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<PetType>> ReadAll(bool isTracking)
        {
            try
            {
                return isTracking 
                    ? Context.PetType 
                    : Context.PetType.AsNoTracking();
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
