using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate
{
    public class Wishlist : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; set; }
        private readonly List<WishlistItem> _items = new List<WishlistItem>();
        public IReadOnlyCollection<WishlistItem> Items => _items.AsReadOnly();

        public void AddItem(int catalogItemId)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new WishlistItem()
                {
                    CatalogItemId = catalogItemId
                });
                return;
            }
        }
    }
}
