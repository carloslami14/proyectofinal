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
    public class ItemsConstructionsRepository : IItemConstructionRepository
    {
        private readonly FinalProjectContext _context;
        public ItemsConstructionsRepository(FinalProjectContext context)
        {
            _context = context;
        }
        public void Add(ItemConstruction entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.ItemsConstructions.Add(entity);
        }

        public void Delete(ItemConstruction entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(ItemConstruction entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            var entityToUpdate = _context.ItemsConstructions.Attach(entity);
            entityToUpdate.State = EntityState.Modified;
        }

        public ItemConstruction GetById(int Id)
        {
            return _context.ItemsConstructions.FirstOrDefault(ic => ic.ItemId == Id && ic.State == State.Enabled);
        }

        public IEnumerable<ItemConstruction> GetAll()
        {
            return _context.ItemsConstructions.Where(itemConstruction => itemConstruction.State == State.Enabled);
        }

        public ICollection<ItemConstruction> GetItemConstructionsByConstructionId(int constructionId)
        {
            return _context.ItemsConstructions.Where(itemConstruction => itemConstruction.ConstructionId == constructionId).AsNoTracking().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
