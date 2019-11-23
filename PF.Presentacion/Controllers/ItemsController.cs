using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF.Dominio.Interfaces.Model;
using PF.Dominio.Model;
using PF.Presentacion.ViewModels;

namespace PF.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemMaterialRepository _itemMaterialRepository;

        public ItemsController(IItemRepository itemRepository,
            IItemMaterialRepository itemMaterialRepository)
        {
            _itemRepository = itemRepository;
            _itemMaterialRepository = itemMaterialRepository;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<ItemModel> GetItems()
        {
            return _itemRepository.GetAll().ToList().Select(i => new ItemModel(i));
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public ActionResult<ItemModel> GetItem(int id)
        {
            var item = new ItemModel(_itemRepository.GetById(id));

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, ItemModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                #region Edit Item
                //Edit item
                var item = model.GetItem();
                item.Id = id;
                _itemRepository.Edit(item);
                _itemRepository.Save();
                #endregion

                #region Edit Item Material
                var itemsMaterials = _itemMaterialRepository.GetItemMaterialsByItemId(id);
                var itemsMaterialsByMaterialId = model.ItemsMaterials.GroupBy(im => im.MaterialId).ToList();
                
                if (itemsMaterialsByMaterialId.Count() == 0)
                {
                    //Delete all items material
                    foreach (var im in itemsMaterials)
                    {
                        _itemMaterialRepository.Delete(im);
                    }
                }
                else
                {
                    foreach (var im in itemsMaterialsByMaterialId)
                    {
                        var imAux = itemsMaterials.Where(ims => ims.MaterialId == im.Key).FirstOrDefault();
                        if (item != null)
                        {
                            //Edit item material
                            var itemMaterial = new ItemMaterial()
                            {
                                ItemId = imAux.ItemId,
                                MaterialId = imAux.MaterialId,
                                Quantity = im.Sum(i => i.Quantity)
                            };
                            _itemMaterialRepository.Edit(itemMaterial);
                        }
                        else
                        {
                            //Create item material
                            var itemMaterial = new ItemMaterial()
                            {
                                ItemId = item.Id,
                                MaterialId = im.Key,
                                Quantity = im.Sum(i => i.Quantity)
                            };
                            _itemMaterialRepository.Add(itemMaterial);
                        }
                    }

                    foreach (var im in itemsMaterials)
                    {
                        //Delete items erased
                        var imDelete = itemsMaterialsByMaterialId.Where(imm => imm.Key != im.MaterialId).FirstOrDefault();
                        if (imDelete != null)
                        {
                            var itemMaterial = new ItemMaterial()
                            {
                                ItemId = item.Id,
                                MaterialId = imDelete.Key,
                                Quantity = imDelete.Sum(i => i.Quantity)
                            };
                            _itemMaterialRepository.Delete(itemMaterial);
                        }
                    }
                }

                _itemMaterialRepository.Save();
                #endregion
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        [HttpPost]
        public ActionResult<Item> PostItem(ItemModel model)
        {
            //Create new item and save it
            var item = model.GetItem();
            _itemRepository.Add(item);
            _itemRepository.Save();

            //Create new ItemMaterial and save it
            foreach(var im in model.ItemsMaterials.GroupBy(im => im.MaterialId))
            {
                var itemMaterial = new ItemMaterial()
                {
                    ItemId = item.Id,
                    MaterialId = im.Key,
                    Quantity = im.Sum( i=> i.Quantity)
                };
                _itemMaterialRepository.Add(itemMaterial);
            }
            _itemMaterialRepository.Save();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _itemRepository.Delete(item);
            _itemRepository.Save();

            return item;
        }

        private bool ItemExists(int id)
        {
            return _itemRepository.GetById(id) != null;
        }
    }
}
