using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;
using System;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Services
{
    public class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IAsyncRepository<CatalogItem> _catalogItemRepository;

        public CatalogItemViewModelService(IAsyncRepository<CatalogItem> catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task UpdateCatalogItem(CatalogItemViewModel viewModel)
        {
            //Get existing CatalogItem
            var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(viewModel.Id);
            if (existingCatalogItem == null)
            {
                throw new Exception($"O produto não existe");
            }

            //Build updated CatalogItem
            existingCatalogItem.Name = viewModel.Name;
            existingCatalogItem.Price = viewModel.Price;
            existingCatalogItem.ShowPrice = viewModel.ShowPrice;
            existingCatalogItem.qntStock = viewModel.qntStock;

            await _catalogItemRepository.UpdateAsync(existingCatalogItem);
        }

        //ADICIONAR PRODUTO
        public async Task AddCatalogItem(CatalogItemCreateModel viewModel)
        {
            var newCatalogItem = new CatalogItem
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                ShowPrice = viewModel.ShowPrice,
                qntStock = viewModel.qntStock
            };
            newCatalogItem = await _catalogItemRepository.AddAsync(newCatalogItem);

        }

        //REMOVER PRODUTO
        public async Task RemoveCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(viewModel.Id);

            var removeCatalogItem = existingCatalogItem;
            removeCatalogItem.Name = viewModel.Name;

            await _catalogItemRepository.DeleteAsync(removeCatalogItem);

        }
    }
}
