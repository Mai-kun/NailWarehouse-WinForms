using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Contracts
{
    /// <summary>
    /// Описание методов для изменения хранилища продуктов
    /// </summary>
    public interface IProductStorage
    {
        /// <summary>
        /// Асинхронное получение всех данных
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
    }
}
