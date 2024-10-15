using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NailWarehouse.Contracts.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [DisplayName("Имя")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Размер товара
        /// </summary>
        [DisplayName("Размер")]
        public decimal Size { get; set; }

        /// <summary>
        /// Материал товара
        /// </summary>
        [DisplayName("Материал")]
        public string Material { get; set; }

        /// <summary>
        /// Количество товаров на складе
        /// </summary>
        [DisplayName("Количество")]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [DisplayName("Минимальное количество")]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Цена (без НДС)
        /// </summary>
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        /// <summary>
        /// Проверка валидности данных
        /// </summary>
        public bool IsValid()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(this, context, results, validateAllProperties: true);
        }
    }
}
