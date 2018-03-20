using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.DB.Models.Entities;
using CutieShop.API.DB.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.API.DB.Models.DAO
{
    public sealed class AuthDAO : DAO<string, Auth>
    {
        public AuthDAO()
        {
            DbContext = new CutieshopContext();
        }

        public override Task<bool> Create(Auth obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateSession(string id)
        {
            if (!(DbContext is CutieshopContext context)) throw new FormatException();
            var guid = await GuidHelper.CreateGuid();
            await context.AuthSessions.AddAsync(new AuthSession
            {
                Auth = id,
                Id = guid,
                IsDeleted = false
            });
            await context.SaveChangesAsync();
            return guid;
        }

        public override Task<Auth> Read(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Auth> Read(string username, string password)
        {
            if (!(DbContext is CutieshopContext context)) throw new FormatException();
            var result = await context.Auths
                .AsNoTracking()
                .Include(x => x.Employee)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Point)
                .FirstOrDefaultAsync(x =>
                x.Username == username && x.Password == password && x.IsDeleted == false);
            return result;
        }

        public async Task<Auth> ReadFromSession(string sessionId)
        {
            if (!(DbContext is CutieshopContext context)) throw new FormatException();
            var result = await context.Auths
                .AsNoTracking()
                .Include(x => x.Employee)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Point)
                .FirstOrDefaultAsync(x =>
                    x.AuthSessions
                        .Any(y => y.Id == sessionId));
            return result;
        }

        public override Task<IEnumerable<Auth>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(Auth obj)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
