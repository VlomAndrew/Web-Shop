using System;
using System.Collections.Generic;
using System.Linq;

namespace Web_Shop.Models
{
    public class ShopCart : IDisposable
    {
        public List<ItemToBuy> Items = new List<ItemToBuy>();

        public Guid Id { get; set; }

        public ShopCart()
        {
            Id = Guid.NewGuid();
        }
        public void Add(ItemToBuy item)
        {
            var ItemInCart = Items.FirstOrDefault(i => i.Item.Id == item.Item.Id);

            if (ItemInCart == null)
            {
                Items.Add(item);
            }
            else
            {
                ItemInCart.Quantity += item.Quantity;
            }
        }

        public void RemoveItem(ItemToBuy item)
        {
            Items.RemoveAll(i => i.Item.Id == item.Item.Id);
        }

        public void Dispose()
        {
            Items.Clear();
        }
    }
}