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
        private readonly IItemConstructionRepository _itemConstructionRepository;

        public ConstructionController(IConstructionRepository contructionRepository,
            IItemConstructionRepository itemConstructionRepository)
        {
            _constructionRepository = contructionRepository;
            _itemConstructionRepository = itemConstructionRepository;
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

        // PUT: api/Construction/5
        [HttpPut("{id}")]
        public ActionResult PutConstruction(int id, Construction construction)
        {
            if (id != construction.Id)
            {
                return BadRequest();
            }

            try
            {
                #region Edit Construction
                var constructionEdited = new Construction()
                {
                    Id = id,
                    Address = construction.Address,
                    Cost = construction.Cost,
                    CreatedDate = construction.CreatedDate,
                    EndDate = construction.EndDate,
                    StartDate = construction.StartDate,
                    Name = construction.Name,
                    Description = construction.Description,
                    State = construction.State
                };
                _constructionRepository.Edit(constructionEdited);
                _constructionRepository.Save();
                #endregion

                #region Edit or Add ItemsConstructions
                var itemsConstructions = _itemConstructionRepository.GetItemConstructionsByConstructionId(id);
                var itemsConstructionsByItemId = construction.Items.GroupBy(i => i.ItemId).ToList();

                if (itemsConstructionsByItemId.Count() == 0)
                {
                    //Delete all items material
                    foreach (var ic in itemsConstructions)
                    {
                        _itemConstructionRepository.Delete(ic);
                    }
                }
                else
                {
                    foreach (var ic in itemsConstructionsByItemId)
                    {
                        var icAux = itemsConstructions.Where(ics => ics.ItemId == ic.Key).FirstOrDefault();
                        if (icAux != null )
                        {
                            //Edit item construction
                            var itemConstruction = new ItemConstruction()
                            {
                                ItemId = icAux.ItemId,
                                ConstructionId = id,
                                Quantity = ic.Sum(i => i.Quantity)
                            };
                            _itemConstructionRepository.Edit(itemConstruction);
                        }
                        else
                        {
                            //Create item construction
                            var itemConstruction = new ItemConstruction()
                            {
                                ItemId = ic.Key,
                                ConstructionId = id,
                                Quantity = ic.Sum(i => i.Quantity)
                            };
                            _itemConstructionRepository.Add(itemConstruction);
                        }
                    }

                    foreach (var ic in itemsConstructions)
                    {
                        //Delete items erased
                        var icDelete = itemsConstructionsByItemId.Where(icc => icc.Key != ic.ItemId).FirstOrDefault();
                        if (icDelete != null)
                        {
                            var itemConstruction = new ItemConstruction()
                            {
                                ItemId = icDelete.Key,
                                ConstructionId = id,
                                Quantity = icDelete.Sum(i => i.Quantity)
                            };
                            _itemConstructionRepository.Delete(itemConstruction);
                        }
                    }
                }

                _itemConstructionRepository.Save();
                #endregion
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