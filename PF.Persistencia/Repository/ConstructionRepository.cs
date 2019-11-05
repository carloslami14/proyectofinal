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
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.Constructions.Add(entity);
        }

        public void Delete(Construction entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Construction entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Construction> GetAll()
        {
            return _context.Constructions.Where(construction => construction.State == State.Enabled);
        }

        public Construction GetById(int Id)
        {
            return _context.Constructions.FirstOrDefault(fl => fl.Id == Id && fl.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
