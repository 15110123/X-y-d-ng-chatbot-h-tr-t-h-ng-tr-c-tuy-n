using System.Linq;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming
// ReSharper disable TypeParameterCanBeVariant

namespace CutieShop.API.Models.DAOs
{
    internal interface IDAO<TID, TEntity>
    {
        Task<bool> Create(TEntity entity);
        Task<TEntity> Read(TID id, bool isTracking);
        Task<IQueryable<TEntity>> ReadAll(bool isTracking);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TID id);
    }
}
