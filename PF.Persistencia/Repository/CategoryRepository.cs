using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PF.Dominio;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;

namespace PF.Persistencia.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinalProjectContext _context;

        public CategoryRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.Categories.Add(entity);
        }

        public void Delete(Category entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(Category entity)
        {
            entity.ModificationDate = DateTime.Today;
            entity.State = State.Enabled;
            _context.Update(entity);
        }

        public Category GetById(int Id)
        {
            return _context.Categories.FirstOrDefault(fl => fl.Id == Id && fl.State == State.Enabled);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Where(categories => categories.State == State.Enabled);
        }

        public IEnumerable<Category> GetAllByCategoryId(int familyId)
        {
            return _context.Categories.Where(categories => categories.State == State.Enabled && categories.FamilyId == familyId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
