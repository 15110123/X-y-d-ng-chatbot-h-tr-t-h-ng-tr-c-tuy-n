//ReSharper disable All
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CutieShop.API.DB.Models.DAO
{
    public abstract class DAO<TId, TObj> : IDAO<TId, TObj>
    {
        protected dynamic DbContext;

        protected DAO()
        {
        }

        public abstract Task<bool> Create(TObj obj);

        public abstract Task<TObj> Read(TId id);

        public abstract Task<IEnumerable<TObj>> ReadAll();

        public abstract Task<bool> Update(TObj obj);

        public abstract Task<bool> Delete(TId id);

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
