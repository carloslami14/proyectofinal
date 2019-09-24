using System.Collections.Generic;
using System.Threading.Tasks;
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

        // GET: api/Families
        [HttpGet]
        public async Task<IActionResult> GetFamilies()
        {
            var families = await _familyRepository.GetAll();
            return Ok(families);
        }

        // GET: api/Family/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var family = await _familyRepository.GetById(id);

            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        // POST: api/Bancos
        [HttpPost]
        public async Task<IActionResult> PostFamily([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanco", new { id = banco.BancoId }, banco);
        }
    }
}