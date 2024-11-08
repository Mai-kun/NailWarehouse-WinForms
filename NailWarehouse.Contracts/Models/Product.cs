﻿using System.ComponentModel;
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
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Размер товара
        /// </summary>
        [DisplayName("Размер")]
        [Range(0d, double.MaxValue)]
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
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [DisplayName("Минимальное количество")]
        [Range(0, int.MaxValue)]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Цена (без НДС)
        /// </summary>
        [DisplayName("Цена")]
        [Range(0d, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
