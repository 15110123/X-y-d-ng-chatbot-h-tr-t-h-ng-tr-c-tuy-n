using System.Linq;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace Testing.DB.DAOs
{
    internal interface IDAO<in TID, TEntity>
    {
        Task<bool> Create(TEntity entity);
        Task<TEntity> Read(TID id);
        Task<IQueryable<TEntity>> ReadAll();
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TID id);
    }
}
