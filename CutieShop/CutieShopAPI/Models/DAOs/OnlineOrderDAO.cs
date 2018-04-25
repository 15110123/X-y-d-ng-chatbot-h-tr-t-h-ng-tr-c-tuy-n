﻿using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public abstract class OnlineOrderDAO : CutieshopDAO<string, OnlineOrder>
    {
        protected OnlineOrderDAO(CutieshopContext context = null) : base(context)
        {
        }

        public override async Task<bool> Create(OnlineOrder entity)
        {
            try
            {
                await Context.OnlineOrder.AddAsync(entity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<OnlineOrder> Read(string id)
        {
            try
            {
                return await Context.OnlineOrder.AsNoTracking().FirstOrDefaultAsync(x => x.OnlineOrderId == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<OnlineOrder>> ReadAll()
        {
            try
            {
                return Context.OnlineOrder.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> Update(OnlineOrder entity)
        {
            try
            {
                Context.OnlineOrder.Update(entity);
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
                Context.OnlineOrder.Remove(await Read(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
