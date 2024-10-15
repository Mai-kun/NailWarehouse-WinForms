using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Contracts
{
    /// <summary>
    /// Управления хранилищем продуктов
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// Асинхронное получение всех данных
        /// </summary>
        Task<IReadOnlyCollection<Product>> GetAllAsync();

        /// <summary>
        /// Асинхронное добавление данных
        /// </summary>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// Асинхронный изменение данных
        /// </summary>
        Task EditAsync(Product product);

        /// <summary>
        /// Асинхронный удаление данных
        /// </summary>
        Task<bool> DeleteAsync(Guid id);

        /// <inheritdoc cref="IProductStats"/>
        Task<IProductStats> GetStatsAsync();
    }
}
