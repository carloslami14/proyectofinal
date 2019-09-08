using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;

namespace PF.Presentacion.Controllers
{
    [Route("api/[controller]")]
    public class FamilyController: Controller
    {
        public readonly IFamilyRepository _familyRepository;

        public FamilyController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        [HttpPost("[action]")]
        public void Create()
        {
            
        }

        [HttpGet("[action]")]
        public IEnumerable<Family> GetAllFamilies()
        {
            return _familyRepository.GetAll();
        }

        [HttpGet("[action]")]
        public Family GetFamilyById(int id)
        {
            return _familyRepository.GetById(id);
        }
    }
}