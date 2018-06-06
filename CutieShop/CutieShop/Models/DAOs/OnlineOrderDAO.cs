using System;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static CutieShop.Models.Extensions.StringExtension;

// ReSharper disable InconsistentNaming

namespace CutieShop.Models.DAOs
{
    public abstract class OnlineOrderDAO : CutieshopDAO<string, OnlineOrder>
    {
        protected OnlineOrderDAO(CutieshopContext context = null) : base(context)
        {
        }

        public override async Task<bool> Create(OnlineOrder entity)
        {
            await Context.OnlineOrder.AddAsync(entity);
            return await Context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Create(string onlineOrderId, string fullName, string address, string postCode, string city, string phoneNo, string email, string username, int statusId)
        {
            return await Create(new OnlineOrder
            {
                OnlineOrderId = onlineOrderId,
                FirstName = fullName.FirstName(),
                LastName = fullName.LastName(),
                Address = address,
                PostCode = postCode,
                City = city,
                PhoneNo = phoneNo,
                Email = email,
                Date = DateTime.Now,
                Username = username,
                StatusId = statusId
            });
        }

        public override async Task<OnlineOrder> Read(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.OnlineOrder.FindAsync(id);
                return await Context.OnlineOrder.AsNoTracking().FirstOrDefaultAsync(x => x.OnlineOrderId == id);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<IQueryable<OnlineOrder>> ReadAll(bool isTracking)
        {
            try
            {
                return isTracking
                    ? Context.OnlineOrder
                    : Context.OnlineOrder.AsNoTracking();
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
                Context.OnlineOrder.Remove(await Read(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
