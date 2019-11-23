using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Interfaces.Model
{
    public interface IItemMaterialRepository: IGenericRepository<ItemMaterial>
    {
        IEnumerable<ItemMaterial> GetItemMaterialsByItemId(int itemId);
    }
}
