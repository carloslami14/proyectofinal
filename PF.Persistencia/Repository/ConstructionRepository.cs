using PF.Dominio;
using PF.Dominio.Interfaces;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PF.Persistencia.Repository
{
    public class ConstructionRepository : IConstructionRepository
    {
        private readonly FinalProjectContext _context;

        public ConstructionRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public void Add(Construction entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Constructions.Add(entity);
        }

        public void Delete(Construction entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(Construction entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Update(entity);
        }

        public IEnumerable<Construction> GetAll()
        {
            return _context.Constructions.Where(c => c.State == State.Enabled);
        }

        public Construction GetById(int Id)
        {
            return _context.Constructions.FirstOrDefault(c => c.Id == Id && c.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
