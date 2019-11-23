using System;
using System.Linq;
using System.Linq.Expressions;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using PF.Dominio.Interfaces;
using System.Collections.Generic;
using PF.Dominio;

namespace PF.Persistencia.Repository
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FinalProjectContext _context;
        public FamilyRepository(FinalProjectContext context)
        {
            _context = context;
        }
        public void Add(Family entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Families.Add(entity);
        }

        public void Delete(Family entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(Family entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Update(entity);
        }
        
        public Family GetById(int Id)
        {
            return _context.Families.FirstOrDefault(fl => fl.Id == Id && fl.State == State.Enabled);
        }

        public IEnumerable<Family> GetAll()
        {
            return _context.Families.Where(families => families.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}