using Microsoft.eShopWeb.ApplicationCore.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class TransferWishlist
    {
        [Fact]
        public async Task ThrowsGivenNullAnonymousId()
        {
            var wishlistService = new WishlistService(null, null);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await wishlistService.TransferWishlistAsync(null, "utilizador"));
        }

        [Fact]
        public async Task ThrowsGivenNullUserId()
        {
            var wishlistService = new WishlistService(null, null);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await wishlistService.TransferWishlistAsync("1", null));
        }
    }
}
