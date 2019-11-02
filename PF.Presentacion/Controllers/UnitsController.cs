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
    public class UnitsController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;

        public UnitsController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        // GET: api/Units
        [HttpGet]
        public ActionResult<IEnumerable<Unit>> GetUnits()
        {
            return _unitRepository.GetAll().ToList();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public ActionResult<Unit> GetUnit(int id)
        {
            var unit = _unitRepository.GetById(id);

            if (unit == null)
            {
                return NotFound();
            }

            return unit;
        }

        #region WE DON'T NEED IT, FOR NOW
        // PUT: api/Units/5
        //[HttpPut("{id}")]
        //public IActionResult PutUnit(int id, Unit unit)
        //{
        //    if (id != unit.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _unitRepository.Edit(unit);

        //    try
        //    {
        //        _unitRepository.Save();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UnitExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Units
        //[HttpPost]
        //public ActionResult<Unit> PostUnit(Unit unit)
        //{
        //    _unitRepository.Add(unit);
        //    _unitRepository.Save();

        //    return CreatedAtAction("GetUnit", new { id = unit.Id }, unit);
        //}

        //// DELETE: api/Units/5
        //[HttpDelete("{id}")]
        //public ActionResult<Unit> DeleteUnit(int id)
        //{
        //    var unit = _unitRepository.GetById(id);
        //    if (unit == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitRepository.Delete(unit);
        //    _unitRepository.Save();

        //    return unit;
        //}

        //private bool UnitExists(int id)
        //{
        //    return _unitRepository.GetById(id) != null;
        //}
        #endregion
    }
}
