using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Interfaces.Model
{
    public interface IItemConstructionRepository : IGenericRepository<ItemConstruction>
    {
        ICollection<ItemConstruction> GetItemConstructionsByConstructionId(int constructionId);
    }
}
