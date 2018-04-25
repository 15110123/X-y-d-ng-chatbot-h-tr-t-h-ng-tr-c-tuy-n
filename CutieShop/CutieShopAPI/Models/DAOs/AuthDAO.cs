using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
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

        public override async Task<Auth> Read(string id)
        {
            try
            {
                return await Context.Auth.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<Auth>> ReadAll()
        {
            try
            {
                return Context.Auth.AsNoTracking();
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
                Context.Auth.Remove(await Read(id));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
