using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}