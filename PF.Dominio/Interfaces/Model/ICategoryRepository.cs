using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Interfaces.Model
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        IEnumerable<Category> GetAllByCategoryId(int familyId);
    }
}
