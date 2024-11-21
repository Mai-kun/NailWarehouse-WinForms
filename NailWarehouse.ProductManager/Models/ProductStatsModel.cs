using NailWarehouse.Contracts.Models;

namespace NailWarehouse.ProductManager.Models
{
    /// <inheritdoc cref="IProductStats"/>
    public class ProductStatsModel : IProductStats
    {
        /// <inheritdoc />
        public decimal TotalAmount { get; set; }

        /// <inheritdoc />
        public decimal FullPriceNoNds { get; set; }

        /// <inheritdoc />
        public decimal FullPriceWithNds { get; set; }
    }
}