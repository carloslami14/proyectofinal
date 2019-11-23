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
    public class MaterialRepository : IMaterialRepository
    {
        private readonly FinalProjectContext _context;
        public MaterialRepository(FinalProjectContext context)
        {
            _context = context;
        }
        
        public void Add(Material entity)
        {
            entity.ProviderId = 1;
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Materials.Add(entity);
        }

        public void Delete(Material entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Removed;
            _context.Update(entity);
        }

        public void Edit(Material entity)
        {
            entity.ModificationDate = DateTime.Now;
            entity.State = State.Enabled;
            _context.Update(entity);
        }

        public Material GetById(int Id)
        {
            return _context.Materials.FirstOrDefault(material => material.Id == Id && material.State == State.Enabled);
        }

        public IEnumerable<Material> GetAll()
        {
            return _context.Materials.Where(materials => materials.State == State.Enabled);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
