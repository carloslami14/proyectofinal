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
    public class UnitRepository : IUnitRepository
    {
        private readonly FinalProjectContext _context;

        public UnitRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public void Add(Unit entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.Units.Add(entity);
        }

        public void Delete(Unit entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(Unit entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.Update(entity);
        }

        public Unit GetById(int Id)
        {
            return _context.Units.FirstOrDefault(fl => fl.Id == Id && fl.State == State.Enabled);
        }

        public IEnumerable<Unit> GetAll()
        {
            return _context.Units.Where(units => units.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
