using System.Diagnostics;
using FluentAssertions;
using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;
using Xunit;

namespace NailWarehouse.Storage.Memory.Tests;

/// <summary>
/// Тесты для <see cref="MemoryProductStorage"/>
/// </summary>
public class MemoryProductStorageTests
{
    private readonly IProductStorage productStorage;

    public MemoryProductStorageTests()
    {
        productStorage = new MemoryProductStorage();
    }

    /// <summary>
    /// При пустом списке нет ошибок
    /// </summary>
    [Fact]
    public async Task GetAllAsyncShouldNotThrow()
    {
        // Assert
        Func<Task> act = productStorage.Awaiting(x => x.GetAllAsync());

        // Assert
        await act.Should().NotThrowAsync();
    }

    /// <summary>
    /// Получение пустого списка
    /// </summary>
    [Fact]
    public async Task GetAllAsyncShouldReturnEmpty()
    {
        // Assert
        var result = await productStorage.GetAllAsync();

        // Assert
        result.Should()
            .NotBeNull()
            .And.BeEmpty();
    }

    [Fact]
    public async Task AddAsyncShouldReturnValue()
    {
        // Arrange
        var model = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "qwe",
            Size = 2,
            Material = Materials.Copper.ToString(),
            Quantity = 11,
            MinimumQuantity = 1,
            Price = 10,
        };

        // Assert
        var result = await productStorage.AddAsync(model);

        // Assert
        result.Should()
            .NotBeNull()
            .And.BeEquivalentTo(new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Size = model.Size,
                Material = model.Material,
                Quantity = model.Quantity,
                MinimumQuantity = model.MinimumQuantity,
                Price = model.Price,
            });
    }
}
