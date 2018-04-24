using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutieShop.API.Models.Entities.Models.Entities;
// ReSharper disable InconsistentNaming

namespace CutieShop.API.Models.DAOs
{
    public sealed class PetTypeDAO : CutieshopDAO<string, PetType>
    {
        public override Task<bool> Create(PetType entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<PetType> Read(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<PetType>> ReadAll(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(PetType entity)
        {
            throw new NotImplementedException();
        }
    }
}
