using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming
// ReSharper disable TypeParameterCanBeVariant

namespace CutieShop.API.Models.DAOs
{
    internal interface IChildDAO<TChildId, TChildEntity>
    {
        Task<bool> CreateChild(TChildEntity childEntity);
        Task<TChildEntity> ReadChild(TChildId id);
        Task<IQueryable<TChildEntity>> ReadAllChild();
        Task<bool> UpdateChild(TChildEntity childEntity);
        Task<bool> DeleteChild(TChildId id);
    }
}
