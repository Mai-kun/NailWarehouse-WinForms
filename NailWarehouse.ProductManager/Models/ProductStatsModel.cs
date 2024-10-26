using NailWarehouse.Contracts.Models;

namespace NailWarehouse.ProductManager.Models
{
    /// <inheritdoc cref="IProductStats"/>
    public class ProductStatsModel : IProductStats
    {
        /// <inheritdoc cref="IProductStats.TotalAmount"/>
        public decimal TotalAmount { get; set; }

        /// <inheritdoc cref="IProductStats.FullPriceNoNds"/>
        public decimal FullPriceNoNds { get; set; }

        /// <inheritdoc cref="IProductStats.FullPriceWithNds"/>
        public decimal FullPriceWithNds { get; set; }
    }
}
