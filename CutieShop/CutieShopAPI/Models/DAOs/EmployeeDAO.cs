using CutieShop.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public sealed class EmployeeDAO : AuthDAO, IChildDAO<string, Employee>
    {
        public EmployeeDAO(CutieshopContext context = null) : base(context)
        {
        }

        public async Task<bool> CreateChild(Employee childEntity)
        {
            try
            {
                await Context.Employee.AddAsync(childEntity);
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Employee> ReadChild(string id, bool isTracking)
        {
            try
            {
                if (isTracking)
                    return await Context.Employee.FindAsync(id);
                return await Context.Employee.AsNoTracking().FirstOrDefaultAsync(x => x.Username == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IQueryable<Employee>> ReadAllChild(bool isTracking)
        {
            try
            {
                return isTracking ? Context.Employee : Context.Employee.AsNoTracking();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateChild(Employee childEntity)
        {
            try
            {
                Context.Employee.Update(childEntity);
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
                Context.Employee.Remove(await ReadChild(id, true));
                return await Context.SaveChangesAsync() != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
