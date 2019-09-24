using System;
using System.Linq;
using System.Linq.Expressions;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PF.Dominio.Interfaces;
using System.Collections.Generic;

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
            entity.ModificationDate = DateTime.Today;
            _context.Families.Add(entity);
        }

        public void Delete(Family entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = Dominio.State.Removed;
            _context.Update(entity);
            Save();
        }

        public void Edit(Family entity)
        {
            _context.Update(entity);
            Save();
        }
        
        public async Task<Family> GetById(int Id)
        {
            return await _context.Families.FirstOrDefaultAsync(fl => fl.FamilyId == Id);
        }

        public async Task<IEnumerable<Family>> GetAll()
        {
            return await _context.Families.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}