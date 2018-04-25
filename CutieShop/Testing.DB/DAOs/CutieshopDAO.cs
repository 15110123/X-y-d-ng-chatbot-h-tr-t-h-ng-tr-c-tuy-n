using System;
using System.Linq;
using System.Threading.Tasks;
using Testing.DB.Entities;

// ReSharper disable InconsistentNaming

namespace Testing.DB.DAOs
{
    public abstract class CutieshopDAO<TID, TEntity> : IDAO<TID, TEntity>, IDisposable
    {
        public CutieshopContext Context { get; }

        protected CutieshopDAO(CutieshopContext context = null)
        {
            Context = context ?? new CutieshopContext();
        }

        public abstract Task<bool> Create(TEntity entity);

        public abstract Task<TEntity> Read(TID id);

        public abstract Task<IQueryable<TEntity>> ReadAll();

        public abstract Task<bool> Update(TEntity entity);

        public abstract Task<bool> Delete(TID id);

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
