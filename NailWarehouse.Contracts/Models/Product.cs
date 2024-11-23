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
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Минимальная длина строки составляет 3 символа, а максимальная - 50")]
        public string Name { get; set; }

        /// <summary>
        /// Размер товара
        /// </summary>
        [DisplayName("Размер")]
        [Range(0d, double.MaxValue,
            ErrorMessage = "Число должно быть больше 0")]
        public decimal? Size { get; set; }

        /// <summary>
        /// Материал товара
        /// </summary>
        [DisplayName("Материал")]
        public string? Material { get; set; }

        /// <summary>
        /// Количество товаров на складе
        /// </summary>
        [DisplayName("Количество")]
        [Range(0, int.MaxValue,
            ErrorMessage = "Число должно быть больше 0")]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [DisplayName("Минимальное количество")]
        [Range(0, int.MaxValue,
            ErrorMessage = "Число должно быть больше 0")]
        public int? MinimumQuantity { get; set; }

        /// <summary>
        /// Цена (без НДС)
        /// </summary>
        [DisplayName("Цена")]
        [Range(0d, double.MaxValue,
            ErrorMessage = "Число должно быть больше 0")]
        public decimal Price { get; set; }

        /// <summary>
        /// Создает новый объект, который является копией текущего экземпляра
        /// </summary>
        public Product Clone()
        {
            return (Product)MemberwiseClone();
        }
    }
}
