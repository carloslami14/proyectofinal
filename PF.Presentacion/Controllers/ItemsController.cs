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
        public IActionResult PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _itemRepository.Edit(item);

            try
            {
                _itemRepository.Save();
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
            var item = model.CreateItem();
            _itemRepository.Add(item);
            _itemRepository.Save();

            var itemMaterial = model.GetItemsMaterials(item.Id);
            foreach(var im in itemMaterial)
            {
                _itemMaterialRepository.Add(im);
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
