using NailWarehouse.Contracts.Models;

namespace NailWarehouse.Contracts
{
    /// <summary>
    /// Фукнционал для работа с хранилищем продуктов
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
        Task EditAsync(Product newProduct);

        /// <summary>
        /// Удаление данных
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}