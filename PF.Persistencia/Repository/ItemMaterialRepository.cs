using Microsoft.EntityFrameworkCore;
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
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.ItemsMaterials.Add(entity);
        }

        public void Delete(ItemMaterial entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(ItemMaterial entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            var entityToUpdate = _context.ItemsMaterials.Attach(entity);
            entityToUpdate.State = EntityState.Modified;
        }

        public ItemMaterial GetById(int Id)
        {
            return _context.ItemsMaterials.FirstOrDefault(fl => fl.ItemId == Id && fl.State == State.Enabled);
        }

        public IEnumerable<ItemMaterial> GetAll()
        {
            return _context.ItemsMaterials.Where(itemsMaterials => itemsMaterials.State == State.Enabled);
        }

        public IEnumerable<ItemMaterial> GetItemMaterialsByItemId(int itemId)
        {
            return _context.ItemsMaterials.Where(itemsMaterials => itemsMaterials.ItemId == itemId).AsNoTracking().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
