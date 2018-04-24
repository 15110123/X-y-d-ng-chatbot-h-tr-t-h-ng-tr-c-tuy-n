using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    internal interface IDAO<in TID, TEntity>
    {
        Task<bool> Create(TEntity entity);
        Task<TEntity> Read(TID id);
        Task<IEnumerable<TEntity>> ReadAll(TID id);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TID id);
    }
}
