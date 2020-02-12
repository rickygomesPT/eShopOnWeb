using Microsoft.eShopWeb.ApplicationCore.Exceptions;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;

namespace Ardalis.GuardClauses
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }
    }
    public static class WishlistGuards
    {
        public static void NullWishlist(this IGuardClause guardClause, int wishlistId, Wishlist wishlist)
        {
            if (wishlist == null)
                throw new WishlistNotFoundException(wishlistId);
        }
    }
}