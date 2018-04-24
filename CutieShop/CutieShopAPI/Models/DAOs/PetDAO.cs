using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
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

        public override async Task<IEnumerable<Pet>> ReadAllChild(string id)
        {
            try
            {
                return Context.Pet.AsNoTracking().Where(x => x.ProductId == id);
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
                Context.Pet.Remove(await Context.Pet.FindAsync(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
