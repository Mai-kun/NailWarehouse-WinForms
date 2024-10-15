﻿namespace NailWarehouse.Contracts.Models
{
    public interface IProductStats
    {
        /// <summary>
        /// Общее количество товаров на складе
        /// </summary>
        decimal TotalAmount { get; }

        /// <summary>
        /// Общая стоимость всех товаров без НДС
        /// </summary>
        decimal FullPriceNoNDS { get; }

        /// <summary>
        /// Общая стоимость всех товаров с НДС
        /// </summary>
        decimal FullPriceWithNDS { get; }
    }
}