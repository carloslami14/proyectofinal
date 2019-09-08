using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;

namespace PF.Presentacion.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IFamilyRepository _familyRepository;

        public SampleDataController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Family> WeatherForecasts()
        {
            return _familyRepository.GetAll();
        }
    }
}
