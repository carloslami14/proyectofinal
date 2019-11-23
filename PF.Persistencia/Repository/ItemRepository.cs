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
    public class ItemRepository : IItemRepository
    {
        private readonly FinalProjectContext _context;

        public ItemRepository(FinalProjectContext context)
        {
            this._context = context;
        }

        public void Add(Item entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Items.Add(entity);
        }

        public void Delete(Item entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(Item entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Update(entity);
        }

        public Item GetById(int Id)
        {
            return _context.Items.FirstOrDefault(item => item.Id == Id && item.State == State.Enabled);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.Where(items => items.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
