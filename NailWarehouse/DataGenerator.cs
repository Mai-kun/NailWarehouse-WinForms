using NailWarehouse.Contracts.Models;

namespace NailWarehouse
{
    internal class DataGenerator
    {
        /// <summary>
        /// Создание новый экземпляр класса <see cref="Product"/>
        /// </summary>
        public static Product CreateDefaultProduct(Action<Product> addInfo = null)
        {
            var newNail = new Product
            {
                Id = Guid.NewGuid(),
                Name = "",
                Size = 1.0M,
                Material = EnumHelper.GetEnumDescription(Materials.Copper),
                Quantity = 1,
                MinimumQuantity = 1,
                Price = 0
            };

            addInfo?.Invoke(newNail);

            return newNail;
        }
    }
}
