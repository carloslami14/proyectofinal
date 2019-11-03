using PF.Dominio;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PF.Persistencia.Repository
{
    public class ItemMaterialRepository : IItemMaterialRepository
    {
        private readonly FinalProjectContext _context;
        public ItemMaterialRepository(FinalProjectContext context)
        {
            _context = context;
        }
        public void Add(ItemMaterial entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.ItemsMaterials.Add(entity);
        }

        public void Delete(ItemMaterial entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(ItemMaterial entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.Update(entity);
        }

        public ItemMaterial GetById(int Id)
        {
            return _context.ItemsMaterials.FirstOrDefault(fl => fl.ItemId == Id && fl.State == State.Enabled);
        }

        public IEnumerable<ItemMaterial> GetAll()
        {
            return _context.ItemsMaterials.Where(itemsMaterias => itemsMaterias.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
