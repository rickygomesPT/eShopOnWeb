using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests
{
    public class WishlistWithItems
    {
        private int _testWishlistId = 123;

        [Fact]
        public void MatchesWishlistWithGivenId()
        {
            var spec = new WishlistWithItemsSpecification(_testWishlistId);

            var result = GetTestWishlistCollection()
                .AsQueryable()
                .FirstOrDefault(spec.Criteria);

            Assert.NotNull(result);
            Assert.Equal(_testWishlistId, result.Id);
        }

        public List<Wishlist> GetTestWishlistCollection()
        {
            return new List<Wishlist>()
            {
                new Wishlist() { Id = 1 },
                new Wishlist() { Id = 2 },
                new Wishlist() { Id = _testWishlistId }
            };
        }
    }
}
