using System;
using System.Linq;
using System.Linq.Expressions;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;

namespace PF.Persistencia.Repository
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly IFinalProjectContext _context;
        public FamilyRepository(IFinalProjectContext context)
        {
            _context = context;
        }
        public void Add(Family entity)
        {
            _context.Families.Add(entity);
        }

        public void Delete(Family entity)
        {
            _context.Families.Remove(entity);
        }

        public void Edit(Family entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Family> Find(Expression<Func<Family, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Family> GetAll()
        {
            return _context.Families;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}