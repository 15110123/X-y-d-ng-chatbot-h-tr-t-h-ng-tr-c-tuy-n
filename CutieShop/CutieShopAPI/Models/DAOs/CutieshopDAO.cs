using CutieShop.API.Models.Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public abstract Task<TEntity> Read(TID id);

        public abstract Task<IEnumerable<TEntity>> ReadAll();

        public abstract Task<bool> Update(TEntity entity);

        public abstract Task<bool> Delete(TID id);

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
