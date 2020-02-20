using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Web.Features.MyOrders
{
    public class GetAdminOrders : IRequest<IEnumerable<OrderViewModel>>
    {
        public string UserName { get; set; }

        public GetAdminOrders(string userName)
        {
            UserName = userName;
        }
    }
}
