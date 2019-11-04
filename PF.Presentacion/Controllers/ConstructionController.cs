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
    public class ContructionController : ControllerBase
    {
        private readonly IContructionRepository _contructionRepository;

        public ContructionController(IContructionRepository contructionRepository)
        {
            _contructionRepository = contructionRepository;
        }

        // Agregar contruction
        // POST: api/Families
        [HttpPost]
        public ActionResult<Construction> PostFamily(Construction construction)
        {
            _contructionRepository.Add(construction);
            _contructionRepository.Save();

            return CreatedAtAction("GetConstruction", new { id = construction.Id }, construction);
        }

    }
}