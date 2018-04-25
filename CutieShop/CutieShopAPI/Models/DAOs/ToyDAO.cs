// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.API.Models.DAOs
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
                return await Context.Toy.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IEnumerable<Toy>> ReadAllChild()
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
