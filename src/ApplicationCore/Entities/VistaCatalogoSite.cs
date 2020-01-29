using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class VistaCatalogoSite : BaseEntity, IAggregateRoot
    {
        public string VistaSite { get; set; }
    }
}
