using PF.Dominio;
using PF.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF.Presentacion.ViewModels
{
    public class ItemModel
    {
        #region Constructor
        public ItemModel()
        {
        }

        public ItemModel(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            ItemsMaterials = item.Materials.Where(im => im.State == State.Enabled).ToList();
            Materials = ItemsMaterials.Select(im => 
                new Material() 
                { 
                    Id = im.MaterialId,
                    Name = im.Material.Name,
                    Price = im.Material.Price
                }).ToList();
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<ItemMaterial> ItemsMaterials { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        #endregion

        #region Methods
        public Item GetItem()
        {
            return new Item()
            {
                Name = Name,
                Price = Price
            };
        }

        public List<ItemMaterial> GetItemsMaterials(int id)
        {
            List<ItemMaterial> itemsMaterials = new List<ItemMaterial>();

            foreach (var im in Materials)
            {
                itemsMaterials.Add(new ItemMaterial() { MaterialId = im.Id, ItemId = id });
            }

            return itemsMaterials;
        }
        #endregion
    }
}
