using NailWarehouse.Contracts.Models;

namespace NailWarehouse.ProductManager.Models
{
    /// <inheritdoc cref="IProductStats"/>
    public class ProductStatsModel : IProductStats
    {
        /// <summary>
        /// <inheritdoc cref="IProductStats.TotalAmount"/>
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// <inheritdoc cref="IProductStats.FullPriceNoNDS"/>
        /// </summary>
        public decimal FullPriceNoNDS { get; set; }

        /// <summary>
        /// <inheritdoc cref="IProductStats.FullPriceWithNDS"/>
        /// </summary>
        public decimal FullPriceWithNDS { get; set; }
    }
}
