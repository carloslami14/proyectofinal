using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;

namespace PF.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialsController(IMaterialRepository context)
        {
            _materialRepository = context;
        }

        // GET: api/Materials
        [HttpGet]
        public ActionResult<IEnumerable<Material>> GetMaterials()
        {
            return _materialRepository.GetAll().ToList();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public ActionResult<Material> GetMaterial(int id)
        {
            var material = _materialRepository.GetById(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // PUT: api/Materials/5
        [HttpPut("{id}")]
        public IActionResult PutMaterial(int id, Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _materialRepository.Edit(material);

            try
            {
                _materialRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials
        [HttpPost]
        public ActionResult<Material> PostMaterial(Material material)
        {
            _materialRepository.Add(material);
            _materialRepository.Save();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public ActionResult<Material> DeleteMaterial(int id)
        {
            var material = _materialRepository.GetById(id);
            if (material == null)
            {
                return NotFound();
            }

            _materialRepository.Delete(material);
            _materialRepository.Save();

            return material;
        }

        private bool MaterialExists(int id)
        {
            return _materialRepository.GetById(id) != null;
        }
    }
}
