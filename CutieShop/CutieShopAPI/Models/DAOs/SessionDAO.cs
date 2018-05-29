using CutieShop.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public sealed class SessionDAO : AuthDAO, IChildDAO<string, Session>
    {
        public SessionDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Session childEntity)
        {
            try
            {
                await Context.Session.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Session> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Session.FindAsync(id);
                return await Context.Session.AsNoTracking().FirstOrDefaultAsync(x => x.SessionId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Session>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking ? Context.Session : Context.Session.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Session childEntity)
        {
            try
            {
                Context.Session.Update(childEntity);
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
                Context.Session.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
