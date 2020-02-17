using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Web.Features.MyOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using IronPdf;
using Microsoft.eShopWeb.Web.Services;
using System;
using Microsoft.eShopWeb.Webn.Services;

namespace Microsoft.eShopWeb.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IViewRenderService _viewRenderService;

        public OrderController(IMediator mediator, IViewRenderService viewRenderService, IStringLocalizer<OrderController> stringLocalizer)
        {
            _mediator = mediator;
            _viewRenderService = viewRenderService;
        }

        [HttpGet()]
        public async Task<IActionResult> MyOrders()
        {
            var viewModel = await _mediator.Send(new GetMyOrders(User.Identity.Name));

            return View(viewModel);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Detail(int orderId)
        {
            var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId));

            if (viewModel == null)
            {
                return BadRequest("No such order found for this user.");
            }

            return View(viewModel);
        }

        //HTTPtoPDF
        [HttpGet("{orderId}/pdf")]
        public async Task<IActionResult> DetailPdf(int orderId)
        {
            var viewResult = await Detail(orderId) as ViewResult;
            var viewName = "Order/Detail_Doc";
            var html = await _viewRenderService.RenderToStringAsync(viewName, viewResult.Model);
            //var uri = new Uri(Url.Action("Detail", "Order", new { orderId = orderId }));

            // Create a PDF from any existing web page
            var Renderer = new IronPdf.HtmlToPdf();
            //var PDF1 = await Renderer.RenderUrlAsPdfAsync(uri);
            var PDF = await Renderer.RenderHtmlAsPdfAsync(html);


            return File(PDF.BinaryData, "application/pdf", "Catalog.pdf");
        }
    }
}
