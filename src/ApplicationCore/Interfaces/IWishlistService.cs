using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IWishlistService
    {
        Task<int> GetWishlistItemCountAsync(string userName);
        Task TransferWishlistAsync(string anonymousId, string userName);
        Task AddItemToWishlist(int wishlistId, int catalogItemId);
        Task DeleteWishlistAsync(int wishlistId);
    }
}
