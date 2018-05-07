using System.Linq;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming
// ReSharper disable TypeParameterCanBeVariant

namespace CutieShop.API.Models.DAOs
{
    internal interface IChildDAO<TChildId, TChildEntity>
    {
        Task<bool> CreateChild(TChildEntity childEntity);
        Task<TChildEntity> ReadChild(TChildId id, bool isTracking);
        Task<IQueryable<TChildEntity>> ReadAllChild(bool isTracking);
        Task<bool> UpdateChild(TChildEntity childEntity);
        Task<bool> DeleteChild(TChildId id);
    }
}
