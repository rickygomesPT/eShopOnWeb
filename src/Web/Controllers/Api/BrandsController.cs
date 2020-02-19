using Microsoft.eShopWeb.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.eShopWeb.Web.ViewModels;
using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Linq;
using System;

namespace Microsoft.eShopWeb.Web.Controllers.Api
{
    public class BrandsController : BaseApiController
    {
        private readonly IAsyncRepository<CatalogBrand> _brandRepository;

        public BrandsController(IAsyncRepository<CatalogBrand> brandRepository) => _brandRepository = brandRepository;

        /// return catalog brands list
        [HttpGet]
        public async Task<ActionResult<CatalogBrand>> List()
        {
            var brands = await _brandRepository.ListAllAsync();
            return Ok(brands);
        }

        /// Get catalog brand by id
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<CatalogBrand>> GetById(int id){
            try {
                var brand = await _brandRepository.GetByIdAsync(id);
                return Ok(brand);
            } catch (ModelNotFoundException){
                return NotFound();
            }
        }

        /// Insert new catalog brand
        [HttpPost]
        public async Task<ActionResult<CatalogBrand>> AddBrand(CatalogBrand catalogBrand) {
            try {
                var brands = await _brandRepository.ListAllAsync();
                await _brandRepository.AddAsync(catalogBrand);
                return Ok();
            } catch (ModelNotFoundException){
                return NotFound();
            }
        }

        /// Update Catalog brand (por acabar)
        [HttpPut("{id}")]
        public async Task<ActionResult<CatalogBrand>> Put(int id, string brand){
            try {
                var brands = await _brandRepository.GetByIdAsync(id);
                brands.Brand = brand;
                await _brandRepository.UpdateAsync(brands);
                return Ok();
            } catch (ModelNotFoundException) {
                return NotFound();
            }
        }

        /// Delete Catalog Brand By id
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatalogBrand>> Delete(int id) {
            try{
                var brand = await _brandRepository.GetByIdAsync(id);
                if (brand == null) { return NotFound(); }
                await _brandRepository.DeleteAsync(brand);
                return Ok(brand);
            } catch (ModelNotFoundException) {
                return NotFound();
            }
        }
    }
}