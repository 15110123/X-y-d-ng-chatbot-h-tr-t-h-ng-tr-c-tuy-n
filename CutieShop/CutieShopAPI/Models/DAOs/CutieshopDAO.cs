using System;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities;

// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public abstract class CutieshopDAO<TID, TEntity> : IDAO<TID, TEntity>, IDisposable
    {
        public CutieshopContext Context { get; }

        protected CutieshopDAO(CutieshopContext context = null)
        {
            Context = context ?? new CutieshopContext();
        }

        public abstract Task<bool> Create(TEntity entity);

        public abstract Task<TEntity> Read(TID id, bool isTracking);

        public abstract Task<IQueryable<TEntity>> ReadAll(bool isTracking);

        public abstract Task<bool> Update(TEntity entity);

        public abstract Task<bool> Delete(TID id);

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
