using Microsoft.eShopWeb.Web.ViewModels;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        Task UpdateCatalogItem(CatalogItemViewModel viewModel);

        //adicionar item catálogo
        Task AddCatalogItem(CatalogItemCreateModel viewModel);
        
        //adicionar item catálogo
        Task RemoveCatalogItem(CatalogItemViewModel viewModel);
    }
}
