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
    public class ConstructionController : ControllerBase
    {
        private readonly IConstructionRepository _constructionRepository;

        public ConstructionController(IConstructionRepository contructionRepository)
        {
            _constructionRepository = contructionRepository;
        }

        // GET: api/Construction
        [HttpGet]
        public ActionResult<IEnumerable<Construction>> GetConstructions()
        {
            return _constructionRepository.GetAll().ToList();
        }

        // GET: api/Construction/5
        [HttpGet("{id}")]
        public ActionResult<Construction> GetConstruction(int id)
        {
            var construction = _constructionRepository.GetById(id);

            if (construction == null)
            {
                return NotFound();
            }

            return construction;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult PutConstruction(int id, Construction construction)
        {
            if (id != construction.Id)
            {
                return BadRequest();
            }

            _constructionRepository.Edit(construction);

            try
            {
                _constructionRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionExists(id))
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

        // POST: api/Construction
        [HttpPost]
        public ActionResult<Construction> PostConstruction(Construction construction)
        {
            try
            {
                _constructionRepository.Add(construction);
                _constructionRepository.Save();
            }
            catch (Exception ex)
            {
                throw;
            }

            return CreatedAtAction("GetConstruction", new { id = construction.Id }, construction);
        }

        private bool ConstructionExists(int id)
        {
            return _constructionRepository.GetById(id) != null;
        }
    }
}