using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Persistencia.Context;
using PF.Persistencia.Repository;

namespace PF.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyRepository _familyRepository;

        public FamiliesController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        // GET: api/Families
        [HttpGet]
        public ActionResult<IEnumerable<Family>> GetFamilies()
        {
            return _familyRepository.GetAll().ToList();
        }

        // GET: api/Families/5
        [HttpGet("{id}")]
        public ActionResult<Family> GetFamily(int id)
        {
            var family = _familyRepository.GetById(id);

            if (family == null)
            {
                return NotFound();
            }

            return family;
        }

        // PUT: api/Families/5
        [HttpPut("{id}")]
        public IActionResult PutFamily(int id, Family family)
        {
            if (id != family.Id)
            {
                return BadRequest();
            }

            _familyRepository.Edit(family);

            try
            {
                _familyRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Families
        [HttpPost]
        public ActionResult<Family> PostFamily(Family family)
        {
            _familyRepository.Add(family);
            _familyRepository.Save();

            return CreatedAtAction("GetFamily", new { id = family.Id }, family);
        }

        // DELETE: api/Families/5
        [HttpDelete("{id}")]
        public ActionResult<Family> DeleteFamily(int id)
        {
            var family = _familyRepository.GetById(id);
            if (family == null)
            {
                return NotFound();
            }

            _familyRepository.Delete(family);
            _familyRepository.Save();

            return family;
        }

        private bool FamilyExists(int id)
        {
            return _familyRepository.GetAll().Any(family => family.Id == id);
        }
    }
}
