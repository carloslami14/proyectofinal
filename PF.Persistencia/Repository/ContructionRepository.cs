using PF.Dominio;
using PF.Dominio.Interfaces;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Persistencia.Repository
{
    class ContructionRepository : IContructionRepository
    {
        private readonly FinalProjectContext _context;

        public ContructionRepository(FinalProjectContext context)
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
            throw new NotImplementedException();
        }

        public Construction GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
