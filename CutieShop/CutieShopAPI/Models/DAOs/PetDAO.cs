﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
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

        public async Task<Pet> ReadChild(string id)
        {
            try
            {
                return await Context.Pet.AsNoTracking().Include(x => x.Product).FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Pet>> ReadAllChild()
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
