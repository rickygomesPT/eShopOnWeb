using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class CatalogItemCreateModel
    {
        [Required]
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }
        public bool ShowPrice { get; set; }
        public Currency PriceUnit { get; set; }

        //STOCK
        public int qntStock { get; set; }
    }

}
