using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public sealed class UserDAO : AuthDAO, IChildDAO<string, User>
    {
        public UserDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(User childEntity)
        {
            try
            {
                await Context.User.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.User.FindAsync(id);
                return await Context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Username == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<User>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking ? Context.User : Context.User.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(User childEntity)
        {
            try
            {
                Context.User.Update(childEntity);
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
                Context.User.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
