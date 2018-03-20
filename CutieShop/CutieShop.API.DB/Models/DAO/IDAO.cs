//ReSharper disable All
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CutieShop.API.DB.Models.DAO
{
    interface IDAO<TId, TObj> : IDisposable
    {
        Task<bool> Create(TObj obj);
        Task<TObj> Read(TId id);
        Task<IEnumerable<TObj>> ReadAll();
        Task<bool> Update(TObj obj);
        Task<bool> Delete(TId id);
    }
}
