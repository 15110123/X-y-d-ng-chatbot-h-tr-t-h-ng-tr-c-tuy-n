using CutieShop.API.Models.Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
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

        public override async Task<IEnumerable<PetType>> ReadAll()
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
