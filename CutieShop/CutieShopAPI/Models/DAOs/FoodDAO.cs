// ReSharper disable InconsistentNaming

using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CutieShop.API.Models.DAOs
{
    public sealed class FoodDAO : ProductDAO, IChildDAO<string, Food>
    {
        public FoodDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Food childEntity)
        {
            try
            {
                await Context.Food.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Food> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Food
                                        .Include(x => x.Product)
                                        .Include(x => x.Nutrition)
                                        .FirstOrDefaultAsync(x => x.ProductId == id);
                return await Context.Food
                    .AsNoTracking()
                    .Include(x => x.Product)
                    .Include(x => x.Nutrition)
                    .FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Food>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking
                    ? Context.Food
                    : Context.Food.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Food childEntity)
        {
            try
            {
                Context.Food.Update(childEntity);
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
                Context.Food.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
