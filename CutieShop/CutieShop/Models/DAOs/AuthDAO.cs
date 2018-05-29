using System;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public abstract class AuthDAO : CutieshopDAO<string, Auth>
    {
        protected AuthDAO(CutieshopContext context = null) : base(context)
        {
        }

        public override async Task<bool> Create(Auth entity)
        {
            try
            {
                await Context.Auth.AddAsync(entity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<Auth> Read(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Auth.FindAsync(id);
                return await Context.Auth.AsNoTracking().FirstOrDefaultAsync(x => x.Username == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Auth>> ReadAll(bool isTracking)
        {
            try
            {
                return isTracking ? Context.Auth : Context.Auth.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public override async Task<bool> Update(Auth entity)
        {
            try
            {
                Context.Auth.Update(entity);
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
                Context.Auth.Remove(await Read(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> CreateSession(string id)
        {
            var guid = Guid.NewGuid().ToString();
            await Context.Session.AddAsync(new Session
            {
                Username = id,
                SessionId = guid,
                IsDeleted = false
            });
            await Context.SaveChangesAsync();
            return guid;
        }
    }
}
