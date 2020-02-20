using Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.WishListServiceTests
{
    public class DeleteWishList
    {
        private Mock<IAsyncRepository<Wishlist>> _mockWishlistRepo;

        public DeleteWishList()
        {
            _mockWishlistRepo = new Mock<IAsyncRepository<Wishlist>>();
        }

        [Fact]
        public async Task Should_InvokeWishListRepositoryDeleteAsync_Once()
        {
            var wish = new Wishlist();
            wish.AddItem(1);
            wish.AddItem(2);
            _mockWishlistRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(wish);
            var wishListService = new WishlistService(_mockWishlistRepo.Object, null);

            await wishListService.DeleteWishlistAsync(It.IsAny<int>());

            _mockWishlistRepo.Verify(x => x.DeleteAsync(It.IsAny<Wishlist>()), Times.Once);
        }
    }
}