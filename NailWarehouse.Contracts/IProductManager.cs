using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Contracts
{
    /// <summary>
    /// Описание методов для управления хранилищем продуктов
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// Асинхронное получение всех данных данных
        /// </summary>
        Task<IReadOnlyCollection<Product>> GetAllAsync();

        /// <summary>
        /// Асинхронный метод добавления данных
        /// </summary>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// Асинхронный метод изменения данных
        /// </summary>
        Task EditAsync(Product product);

        /// <summary>
        /// Асинхронный метод удаления данных
        /// </summary>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Асинхронный метод получения статистики по всем товарам
        /// </summary>
        Task<IProductStats> GetStatsAsync();
    }
}
