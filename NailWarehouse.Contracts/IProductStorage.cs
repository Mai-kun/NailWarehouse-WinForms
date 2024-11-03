using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Contracts
{
    /// <summary>
    /// Изменение хранилища продуктов
    /// </summary>
    public interface IProductStorage
    {
        /// <summary>
        /// Получение всех данных
        /// </summary>
        Task<IReadOnlyCollection<Product>> GetAllAsync();

        /// <summary>
        /// Добавление данных
        /// </summary>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// Изменение данных
        /// </summary>
        Task EditAsync(Product product);

        /// <summary>
        /// Удаление данных
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}
